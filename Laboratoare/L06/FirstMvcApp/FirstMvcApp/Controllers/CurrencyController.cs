using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult _CursValutar()
        {
            var db = new CRMEntities();
            var model = db.Currencies.ToList();
            return PartialView(model);
        }
    }
}