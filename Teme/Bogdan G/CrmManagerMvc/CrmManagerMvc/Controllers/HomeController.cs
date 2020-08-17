using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var language = this.RouteData.Values.FirstOrDefault(s => s.Key == "lang");
            if(language.Value.ToString() == "ro")
            {
                ViewBag.Title = "Salut!";
                ViewBag.Message = "Pagina ta de contact.";
            }
            else if (language.Value.ToString() == "en")
            {
                ViewBag.Title = "Hello!";
                ViewBag.Message = "Your contact page.";
            }
            else if (language.Value.ToString() == "fr")
            {
                ViewBag.Title = "Bonjour!";
                ViewBag.Message = "Omelette au fromage.";
            }

            return View();
        }
    }
}