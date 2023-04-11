using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tutor_SP23_BL2_NET104.Models;

using Tutor_SP23_BL2_NET104.Services.Implements;
using Tutor_SP23_BL2_NET104.Services.Interfaces;

namespace Tutor_SP23_BL2_NET104.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillServices _billServices;
        private readonly IProductBillServices _productBillServices;
        private readonly IProductServices _productServices;
        private readonly ICartDetailsServices _cartDetailsServices;

        public BillController()
        {
            _billServices = new BillServices();
            _productBillServices = new ProductBillServices();
            _productServices = new ProductServices();
            _cartDetailsServices = new CartDetailsServices();
        }

        // GET: BillController
        public async Task<ActionResult> Index(Guid idUser)
        {
            idUser = Guid.Parse("8871AD42-6960-473D-AA75-AABC6EDF5014");
            // Hiển thị list các hóa đơn của người dùng
            var listBill = await _billServices.GetAllOfUserAsync(idUser);
            var listProductBill = await _productBillServices.GetAllAsync();
            var listProduct = await _productServices.GetAllAsync();

            ViewBag.listBill = listBill;
            ViewBag.listProductBill = listProductBill;
            ViewBag.listProduct = listProduct;

            return View();
        }

        // GET: BillController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid idBill)
        {
            // Xem chi tiết thông tin hóa đơn
            Bill bill = await _billServices.GetByIdAsync(idBill);
            ViewBag.bill = bill;

            var listProductBill = await _productBillServices.GetAllAsync();
            ViewBag.listProductBill = listProductBill.Where(c => c.IdBill == bill.Id).ToList();

            var listProduct = await _productServices.GetAllAsync();
            ViewBag.listProduct = listProduct.Where(c => listProductBill.Any(x => x.IdProduct == c.Id)).ToList();

            return View();
        }

        // GET: BillController/Create
        public async Task<ActionResult> Create(Guid idUser)
        {
            // Tạo 1 hóa đơn mới cho người dùng
            Bill objBill = new()
            {
                Id = Guid.NewGuid(),
                IdUser = idUser,
                Status = 0
            };
            var resultCreateBill = await _billServices.AddAsync(objBill);
            var resultCreateProductBill = false;

            int countError = 0;// đếm những sản phẩm không thêm được thành công vào hóa đơn
            List<CartDetails> listCartDetails = await _cartDetailsServices.GetAllOfUserAsync(idUser);
            var listProduct = await _productServices.GetAllAsync();
            
            // Nếu tạo hóa đơn thành công
            if (resultCreateBill)
            {
                // Tạo các sản phẩm trong hóa đơn = các sản phẩm trong giỏ hàng
                foreach (var cartDetails in listCartDetails)
                {
                    ProductBill productBill = new ProductBill()
                    {
                        IdBill = objBill.Id,
                        IdProduct = cartDetails.IdProduct,
                        Amount = cartDetails.Amount,
                        Price = (double)listProduct.FirstOrDefault(c => c.Id == cartDetails.IdProduct).Price,
                        ReducedPrice = (double)listProduct.FirstOrDefault(c => c.Id == cartDetails.IdProduct).ReducedPrice
                    };

                    resultCreateProductBill = await _productBillServices.AddAsync(productBill);

                    if (!resultCreateProductBill)
                    {
                        countError++;
                    }
                }

                // Xóa các sản phẩm trong giỏ hàng
                foreach (var cartDetails in listCartDetails)
                {
                    await _cartDetailsServices.RemoveAsync(cartDetails.IdProduct, cartDetails.IdUser);
                }

                if (countError == 0)
                {
                    return RedirectToAction("Details", new { idBill = objBill.Id });
                }
            }

            return RedirectToAction("Index", idUser);
        }

        // GET: BillController/Delete/5
        public async Task<ActionResult> Delete(Guid idBill)
        {
            // Xóa hóa đơn (Xóa mềm: Thay đổi trạng thái thành "Đã hủy")
            await _billServices.RemoveAsync(idBill);

            return RedirectToAction("Index");
        }
    }
}
