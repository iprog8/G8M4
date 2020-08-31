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
            string lang = this.RouteData.Values["language"].ToString();
            switch (lang)
            {
                case "en":
                    ViewBag.Title = "List of customers";
                    break;
                case "ro":
                    ViewBag.Title = "Lista de clienti";
                    break;
                default:
                    break;
            }

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
            model.TotalCustomers = new CRMEntities().Customers.Count();
            return PartialView(model);
        }
    }
}