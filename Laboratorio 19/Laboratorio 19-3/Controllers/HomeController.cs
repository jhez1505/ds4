using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Laboratorio19_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = "https://localhost:44352/api/values/get/2"; 

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            string responseBody = "";

            using (WebResponse response = request.GetResponse())
            using (Stream strReader = response.GetResponseStream())
            using (StreamReader objReader = new StreamReader(strReader))
            {
                responseBody = objReader.ReadToEnd();
            }

            ViewBag.Resultado = responseBody;

            return View();
        }
    }
}
