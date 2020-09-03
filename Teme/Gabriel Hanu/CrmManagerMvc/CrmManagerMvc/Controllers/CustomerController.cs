using CrmManagerMvc.Models;
using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class CustomerController : Controller
    {
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
    }
}