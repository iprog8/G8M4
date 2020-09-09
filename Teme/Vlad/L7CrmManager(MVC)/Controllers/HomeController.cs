using L7CrmManager_MVC_.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L7CrmManager_MVC_.Controllers
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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _GlumaZilei()
        {
            var db = new CRMEntities();
            Random randomNumber = new Random();
            int skipRow = randomNumber.Next(0, db.GlumaZileis.Count());
            var model = db.GlumaZileis
                .Select(g => g.Text)
                .OrderBy(g => g.Length)
                .Skip(skipRow)
                .Take(1)
                .FirstOrDefault();
            return PartialView("_GlumaZilei",model);
        }
    }
}