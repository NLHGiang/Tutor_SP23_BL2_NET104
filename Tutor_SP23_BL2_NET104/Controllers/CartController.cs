using Tutor_SP23_BL2_NET104.Services.Implements;
using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tutor_SP23_BL2_NET104.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartDetailsServices _cartDetailsServices;
        private readonly IProductServices _productServices;

        public CartController()
        {
            _cartDetailsServices = new CartDetailsServices();
            _productServices = new ProductServices();
        }

        public async Task<IActionResult> Index(Guid idUser)
        {
            idUser = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014");
            //if (idUser == Guid.Empty)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            var listCartDetails = await _cartDetailsServices.GetAllAsync();
            ViewBag.listCartDetails = listCartDetails.Where(c => c.IdUser == idUser && c.Status == 0).ToList();
            ViewBag.listProduct = await _productServices.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> Details(Guid idProduct, Guid idUser)
        {
            ViewBag.cartDetails = await _cartDetailsServices.GetByIdAsync(idProduct, idUser);

            return View();
        }

        public async Task<IActionResult> Create(Guid idProduct, Guid idUser)
        {
            List<CartDetails> cartDetails = await _cartDetailsServices.GetAllAsync();

            CartDetails obj = new()
            {
                IdUser = idUser,
                IdProduct = idProduct,
                Amount = 1
            };

            // Check sản phẩm đã có trong giỏ hàng hay chưa
            // Nếu có => Update +1 cho Amount
            // Nếu không => Create
            if (cartDetails.Any(c => c.IdUser == idUser && c.IdProduct == idProduct))
            {
                // Update
                if(cartDetails.FirstOrDefault(c => c.IdUser == idUser && c.IdProduct == idProduct).Status == 0)
                {
                    obj.Amount = cartDetails.FirstOrDefault(c => c.IdUser == idUser && c.IdProduct == idProduct).Amount + 1;
                }

                var resultUpdate = await _cartDetailsServices.UpdateAsync(obj.IdProduct, obj.IdUser, obj);

                if (resultUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result = await _cartDetailsServices.AddAsync(obj);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Update(CartDetails obj)
        {
            obj.IdUser = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014");

            var result = await _cartDetailsServices.UpdateAsync(obj.IdProduct, obj.IdUser, obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid idProduct, Guid idUser)
        {
            var result = await _cartDetailsServices.RemoveAsync(idProduct, idUser);

            return RedirectToAction("Index", new { idUser = Guid.Empty });
        }
    }
}
