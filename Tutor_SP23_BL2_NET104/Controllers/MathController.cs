using Buoi_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi_2.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Index()
        {
            // Menu các bài toán

            return View();
        }

        [Route("/{actionIndex:int}")]
        public IActionResult Action(int actionIndex)
        {
            switch (actionIndex)
            {
                case 1:
                    return RedirectToAction("Action1");
                case 2:
                    return RedirectToAction("Action2");
                case 3:
                    return RedirectToAction("Action3");
                default:
                    return RedirectToAction("Index");
            }
        }

        public IActionResult Action1(ModelForAction1 request)
        {
            int ketQua = 0;

            if (request != null)
            {
                switch (request.PhepTinh)
                {
                    case 1:
                        ketQua = request.So1 + request.So2;
                        break;
                    case 2:
                        ketQua = request.So1 - request.So2;
                        break;
                    case 3:
                        ketQua = request.So1 * request.So2;
                        break;
                    case 4:
                        ketQua = request.So1 / request.So2;
                        break;
                }
            }

            ViewBag.KetQua = ketQua;

            return View();
        }

        public IActionResult Action2(ModelForAction2 request)
        {
            float x = 0;

            if (request != null)
            {
                if (request.a == 0)
                {
                    x = -9999999999999;
                }
                else
                {
                    x = -(float)request.b / request.a;
                }
            }

            ViewBag.x = x;

            return View();
        }

        public IActionResult Action3(ModelForAction3 request)
        {
            float ketQua = 0;

            if (request != null)
            {
                ketQua = request.canh * request.canh;
            }

            ViewBag.KetQua = ketQua;

            return View();
        }
    }
}
