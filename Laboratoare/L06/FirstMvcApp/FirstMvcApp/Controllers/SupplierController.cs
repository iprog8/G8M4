﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Models;
using FirstMvcApp.ViewModels;

namespace FirstMvcApp.Controllers
{
    public class SupplierController : Controller
    {
        public int ItemsPerPage { get; set; } = 10;

        //public SupplierController()
        //{
        //    ItemsPerPage = 10;
        //}

        // GET: Supplier
        public ActionResult Index(int page = 1)
        {
            SupplierIndexViewModel model = new SupplierIndexViewModel();
            CRMEntities db = new CRMEntities();
            model.PageInfo.CurrentPage = page;
            model.SupplierList = db.Suppliers.Select(
                    s => new SupplierViewModel
                    {
                        Id = s.Id,
                        CompanyName = s.CompanyName,
                        ContactName = s.ContactName,
                        Phone = s.Phone
                    }
                )
                .OrderBy(s => s.CompanyName)
                .Skip(ItemsPerPage * (page-1))
                .Take(ItemsPerPage)
                .ToList();
            model.PageInfo.MaxPage = Math.Ceiling(db.Suppliers.Count() / (double)ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier model = db.Suppliers.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        public void Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                CRMEntities db = new CRMEntities();
                if(db.Suppliers.Any(s => s.Id == supplier.Id)) {
                    db.Entry<Supplier>(supplier).State = EntityState.Modified;
                    db.SaveChanges();
                    RedirectToAction("Index");
                }
            }
            else
            {
                //return ModelState.
            }
        }
    }
}