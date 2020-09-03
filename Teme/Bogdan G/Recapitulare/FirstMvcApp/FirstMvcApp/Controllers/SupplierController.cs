using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Models;
using PagedList.Mvc;
using PagedList;
using FirstMvcApp.ViewModels;
using FirstMvcApp.ActionFilters;

namespace FirstMvcApp.Controllers
{
    public class SupplierController : Controller
    {
        private CRMEntities db = new CRMEntities();
        public int ItemsPerPage { get; set; }
        // GET: Supplier
        [LogActionFiter]
        public ActionResult Index(int page = 1)
        {
            string lang = this.RouteData.Values["lang"].ToString() != "" ? this.RouteData.Values["lang"].ToString() : "en";
            SupplierIndexViewModel model = new SupplierIndexViewModel();
            CRMEntities db = new CRMEntities();
            model.PageInfo.CurrentPage = page;
            model.SupplierList = (ICollection<SupplierIndexViewModel>)db.Supplier.Select(
                    s => new SupplierViewModel
                    {
                        Id = s.Id,
                        CompanyName = s.CompanyName,
                        ContactName = s.ContactName,
                        Phone = s.Phone
                    }
                )
                .OrderBy(s => s.CompanyName)
                .Skip(ItemsPerPage * (page - 1))
                .Take(ItemsPerPage)
                .ToList();
            model.PageInfo.MaxPage = Math.Ceiling(db.Supplier.Count() / (double)ItemsPerPage);
            model.Translations.Translations = (ICollection<Translation>)db.Translations.Where(t => t.Code.Contains("Supplier_Index_") && t.Lang == lang).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier model = db.Supplier.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,ContactName,ContactTitle,City,Country,Phone,Fax")] Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,ContactName,ContactTitle,City,Country,Phone,Fax")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Supplier.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if(supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if(supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            db.Supplier.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}