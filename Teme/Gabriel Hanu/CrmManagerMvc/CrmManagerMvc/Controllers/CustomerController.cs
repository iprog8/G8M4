using CrmManagerMvc.Models;
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
        public ActionResult Index()
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
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.ToList();
            return View(customers);
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
    }
}