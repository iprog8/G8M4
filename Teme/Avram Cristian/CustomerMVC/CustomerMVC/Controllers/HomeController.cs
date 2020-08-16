using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerMVC.Controllers
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

        public ActionResult Contact()
        {
            var language = this.RouteData.Values.FirstOrDefault(s => s.Key == "lang");

            if (language.Value.ToString() == "ro")
            {
                ViewBag.Title = "Contact Neata";
                ViewBag.Message = "romaneste";
            } 
            else if (language.Value.ToString() == "en") 
            {
                ViewBag.Title = "Godd morning!!!";
                ViewBag.Message = "engleza";
            }
            else if (language.Value.ToString() == "fr")
            {
                ViewBag.Title = "Tres bon";
                ViewBag.Message = "franceza";
            }


               

            return View();
        }
    }
}