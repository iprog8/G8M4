using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestWebApi.Models;
using TestWebApi.ViewModels;

namespace TestWebApi.Controllers
{
    public class SupplierController : ApiController
    {
        private CRMEntities db = new CRMEntities();

        // GET: api/Supplier
        public ICollection<SupplierViewModel> GetSuppliers()
        {
            return db.Suppliers
                .Select(s => new SupplierViewModel(s))//nu merge cu constructorul cu parametrii, imi da o eroare legata de linq
                    //Id = s.Id,
                    //City = s.City,
                    //CompanyName = s.CompanyName,
                    //ContactName = s.ContactName,
                    //ContactTitle = s.ContactTitle,
                    //Country = s.Country,
                    //Phone = s.Phone
                .ToList();
        }

        // GET: api/Supplier/5
        [ResponseType(typeof(SupplierViewModel))]
        public IHttpActionResult GetSupplier(int id)
        {
            SupplierViewModel supplier = db.Suppliers
                .Select(s => new SupplierViewModel
                {
                    Id = s.Id,
                    City = s.City,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    ContactTitle = s.ContactTitle,
                    Country = s.Country,
                    Phone = s.Phone
                }).FirstOrDefault(c => c.Id == id);
                //.Select(s => new SupplierViewModel(s)).FirstOrDefault(c => c.Id == id);//la fel si aici
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // PUT: api/Supplier/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, SupplierViewModel supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.Id)
            {
                return BadRequest();
            }

            Supplier supp = new Supplier(supplier);

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Supplier
        [ResponseType(typeof(SupplierViewModel))]
        public IHttpActionResult PostSupplier(SupplierViewModel supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Supplier supp = new Supplier(supplier);
            db.Suppliers.Add(supp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplier.Id }, supplier);
        }

        // DELETE: api/Supplier/5
        [ResponseType(typeof(SupplierViewModel))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            db.Suppliers.Remove(supplier);
            db.SaveChanges();

            SupplierViewModel supp = new SupplierViewModel(supplier);

            return Ok(supp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.Id == id) > 0;
        }
    }
}