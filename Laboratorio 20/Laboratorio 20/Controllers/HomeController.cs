using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio_20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int numero)
        {
            List<string> tabla = new List<string>();

            for (int i = 1; i <= 25; i++)
            {
                tabla.Add($"{numero} x {i} = {numero * i}");
            }

            ViewBag.Tabla = tabla;

            return View();
        }
    }

}