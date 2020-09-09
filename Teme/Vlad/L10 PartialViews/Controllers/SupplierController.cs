using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L7CrmManager_MVC_.Models;

namespace L7CrmManager_MVC_.Controllers
{
    //De terminat:
    public class SupplierController : Controller
    {
        [HttpGet]
        public ActionResult Index(int nrPagina)
        {   
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers
                .OrderBy(s => s.CompanyName)
                .Skip(nrPagina)
                .Take(10)
                .ToList();
            return View(suppliers);
        }
    }
}