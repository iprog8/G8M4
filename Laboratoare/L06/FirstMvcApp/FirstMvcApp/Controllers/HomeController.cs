using FirstMvcApp.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact2()
        {
            int numar = new Random().Next(1, 100);
            if (numar % 2 == 0)
            {
                return View("afiseazaLacuste");
            }
            else
            {
                return View("afiseazaBroaste");
            }
        }
            public ActionResult Contact()
        {
            var language = this.RouteData.Values.FirstOrDefault(s => s.Key == "lang");
            if (language.Value.ToString() == "ro")
            {
                ViewBag.Title = "Contact Neata!";
                ViewBag.Message = "Pagina ta de contact";
            }
            else if(language.Value.ToString() == "en")
            {
                ViewBag.Title = "Good morning!";
                ViewBag.Message = "Your contact page.";
            }
            else if (language.Value.ToString() == "fr")
            {
                ViewBag.Title = "Bon matine!";
                ViewBag.Message = "NU stiu franceza";
            }

            return View();
        }
    }
}