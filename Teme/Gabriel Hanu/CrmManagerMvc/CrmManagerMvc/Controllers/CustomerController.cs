using CrmManagerMvc.ActionFilters;
using CrmManagerMvc.Models;
using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class CustomerController : Controller
    {
        private CRMEntities db = new CRMEntities();
        // GET: Customer
        public ActionResult Index(int page = 1)
        {
            string lang = this.RouteData.Values["language"].ToString() != "" ? this.RouteData.Values["language"].ToString() : "en";
            CustomerIndexViewModel model = new CustomerIndexViewModel();
            CRMEntities db = new CRMEntities();
            int TotalCustomers = db.Customers.Count();
            model.PageInfo.MaxPage = model.PageInfo.GetMaxPage(TotalCustomers);
            if (model.PageInfo.MaxPage < page || page < 0) return HttpNotFound();
            model.PageInfo.CurentPage = page;
            model.CustomerList = db.Customers.Select(
                c => new CustomerViewModel
                {
                    Id = c.Id,
                    FullName = c.FirstName + c.LastName,
                    Country = c.Country,
                    Phone = c.Phone
                })
                .OrderBy(c => c.FullName)
                .Skip(model.PageInfo.ItemsPerPage * page--)
                .Take(model.PageInfo.ItemsPerPage)
                .ToList();
            model.Translations.GetTranslations(db, this.RouteData);
            return View(model);
        }
        // GET: Details
        public ActionResult Details(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer model = db.Customers.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        //GET: Total Customers
        public ActionResult _NumarTotalClienti()
        {
            var model = new CustomersDetails();
            CRMEntities db = new CRMEntities();
            model.TotalCustomers = db.Customers.Count();
            model.Translations.GetTranslations(db, this.RouteData);
            return PartialView(model);
        }
        // GET: Customers/Create
        [UserAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,City,Country,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        // GET: Customers/Edit/5
        [UserAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,City,Country,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        [UserAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}