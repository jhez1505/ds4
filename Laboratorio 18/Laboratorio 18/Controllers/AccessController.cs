using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio18.Controllers
{
    public class AccessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enter(string user, string password)
        {
            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error :( " + ex.Message);
            }
        }
    }
}
