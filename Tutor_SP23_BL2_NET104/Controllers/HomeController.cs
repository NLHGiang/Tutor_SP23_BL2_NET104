using Tutor_SP23_BL2_NET104.Services.Implements;
using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Tutor_SP23_BL2_NET104.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;

        public HomeController()
        {
            _productServices = new ProductServices();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetAllAsync();
            ViewBag.listProduct = list.Where(c => c.Status != 1 && c.Amount > 5).Take(4).ToList();

            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult CartDetails()
        {
            return View();
        }

        public IActionResult BillList()
        {
            return View();
        }
    }
}