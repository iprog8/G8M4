using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
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