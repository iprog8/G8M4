using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Models;

namespace FirstMvcApp.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> model = db.Suppliers.Where(s => s.CompanyName.Contains("a")).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier model = db.Suppliers.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        public void Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                CRMEntities db = new CRMEntities();
                if(db.Suppliers.Any(s => s.Id == supplier.Id)) {
                    db.Entry<Supplier>(supplier).State = EntityState.Modified;
                    db.SaveChanges();
                    RedirectToAction("Index");
                }
            }
            else
            {
                //return ModelState.
            }
        }
    }
}