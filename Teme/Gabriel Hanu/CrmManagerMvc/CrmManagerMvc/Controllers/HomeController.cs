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
            var lang = this.RouteData.Values.FirstOrDefault(s => s.Key == "language");
            switch (lang.Value.ToString())
            {
                case "en":
                    ViewBag.Title = "Home page";
                    break;
                case "ro":
                    ViewBag.Title = "Acasa";
                    break;
                default:
                    break;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}