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
            SetTitle();
            int elemsToTake = 10;
            CRMEntities db = new CRMEntities();
            if (db.Suppliers.Count() / 10 < nrPagina || nrPagina < 0) return HttpNotFound();
            ICollection<Supplier> model = db.Suppliers
                .OrderBy(s => s.CompanyName)
                .Skip(nrPagina - 1)
                .Take(elemsToTake)
                .ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Paging(int pageNumber)
        {
            SetTitle();
            int pageSize = 10;
            CRMEntities db = new CRMEntities();
            if (db.Suppliers.Count() / 10 < pageNumber || pageNumber < 0) return HttpNotFound();
            ICollection<Supplier> model = db.Suppliers.ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        private void SetTitle()
        {
            string lang = this.RouteData.Values.FirstOrDefault(v => v.Key == "language").Value.ToString();
            switch (lang)
            {
                case "ro":
                    ViewBag.Title = "Lista furnizori";
                    break;
                case "en":
                    ViewBag.Title = "List of suppliers";
                    break;
                default:
                    break;
            }
        }
    }
}