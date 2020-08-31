using CrmManagerMvc.Models;
using CrmManagerMvc.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            SetTitle();
            SupplierIndexViewModel model = new SupplierIndexViewModel();
            CRMEntities db = new CRMEntities();
            int TotalSuppliers = db.Suppliers.Count();
            model.PageInfo.MaxPage = model.PageInfo.GetMaxPage(TotalSuppliers);
            if (model.PageInfo.MaxPage < page || page < 0) return HttpNotFound();
            model.PageInfo.CurentPage = page;
            model.SupplierList = db.Suppliers
                .Select(s => new SupplierViewModel {
                    Id = s.Id,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    Country = s.Country,
                    Phone = s.Phone
                })
                .OrderBy(s => s.CompanyName)
                .Skip(model.PageInfo.ItemsPerPage * page--)
                .Take(model.PageInfo.ItemsPerPage)
                .ToList();
            return View(model);
        }
        private void SetTitle()
        {
            string lang = this.RouteData.Values.FirstOrDefault(v => v.Key == "language").Value.ToString();
            switch (lang)
            {
                case "ro":
                    ViewBag.Title = "Lista furnizori";
                    break;
                case "en":
                    ViewBag.Title = "List of suppliers";
                    break;
                default:
                    break;
            }
        }
    }
}