using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrmManagerMvc.Models;

namespace CrmManagerMvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customer = db.Customer.ToList();
            return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer model = db.Customer.Find(id);
            if(model == null)
                return HttpNotFound();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer model = db.Customer.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        public void Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                CRMEntities db = new CRMEntities();
                if(db.Customer.Any(c => c.Id == customer.Id))
                {
                    db.Entry<Customer>(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    RedirectToAction("Index");
                }
                else
                {
                    //return ModelState.
                }
            }
        }
    }
}