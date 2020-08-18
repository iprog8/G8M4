using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMVC;
using CustomerMVC.Models;

namespace CustomerMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var language = this.RouteData.Values.FirstOrDefault(s => s.Key == "lang");

            if (language.Value.ToString() == "ro")
            {
                ViewBag.Title = "Lista Clienti";
                ViewBag.FirstName = "First name";

            }
            else if (language.Value.ToString() == "en")
            {
                ViewBag.Title = "Customer List";
                ViewBag.FirstName = "First name";
            }
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.ToList();

            return View(customers);
        }

        public ActionResult Index2()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.ToList();

            return View(customers);
        }
    }
}