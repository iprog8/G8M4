using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrmManagerMvc.Models;

namespace CrmManagerMvc.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> customer = db.Supplier.ToList();
            return View(customer);
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

        public ActionResult Details(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier model = db.Supplier.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
    }
}