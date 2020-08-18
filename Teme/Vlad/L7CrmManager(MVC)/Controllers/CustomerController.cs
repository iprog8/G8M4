using L7CrmManager_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L7CrmManager_MVC_.Models;

namespace L7CrmManager_MVC_.Controllers
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

        public ActionResult Details(int id) 
        {
            CRMEntities db = new CRMEntities();
            Customer model = db.Customers.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }

    }

}