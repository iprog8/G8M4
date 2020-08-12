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
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.ToList();

            return View(customers);
        }
    }
}