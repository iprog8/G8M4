using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        [HttpGet]
        public ActionResult Index(int nrPagina)
        {
            int elemsToTake = 10;
            CRMEntities db = new CRMEntities();
            if(db.Suppliers.Count() / 10 < nrPagina || nrPagina < 0) return HttpNotFound();
            ICollection<Supplier> model = db.Suppliers
                .OrderBy(s => s.CompanyName)
                .Skip(nrPagina - 1)
                .Take(elemsToTake)
                .ToList();
            return View(model);
        }
    }
}