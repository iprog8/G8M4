using CrmManagerMvc.Models;
using PagedList;
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
            if (db.Supplier.Count() / 10 < nrPagina || nrPagina < 0) return HttpNotFound();
            ICollection<Supplier> model = db.Supplier
                .OrderBy(s => s.CompanyName)
                .Skip(nrPagina*elemsToTake - 1)
                .Take(elemsToTake)
                .ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Paging(int pageNumber)
        {
            int pageSize = 10;
            CRMEntities db = new CRMEntities();
            if (db.Supplier.Count() / 10 < pageNumber || pageNumber < 0) return HttpNotFound();
            ICollection<Supplier> model = db.Supplier.ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}