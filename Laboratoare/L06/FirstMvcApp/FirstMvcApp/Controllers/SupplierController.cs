using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Models;

namespace FirstMvcApp.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.ToList();

            return View(suppliers);
        }
    }
}