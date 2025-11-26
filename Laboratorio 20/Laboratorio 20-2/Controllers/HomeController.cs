using System;
using System.Web.Mvc;

namespace Laboratorio_20_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int n)
        {

            int[,] matriz = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matriz[i, (n - 1) - i] = 1;
            }

            ViewBag.Matriz = matriz;
            ViewBag.N = n;

            return View();
        }
    }
}
