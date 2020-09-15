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
using Api2.Models;
using Api2.ViewModels;

namespace Api2.Controllers
{
    public class CustomerController : ApiController
    {
        private CRMEntities db = new CRMEntities();

        // GET: api/Customer
        public ICollection<CustomerVM> GetCustomers()
        {
            return db.Customers
                .Select(c => new CustomerVM(c))
                .ToList();
        }

        // GET: api/Customer/5
        [ResponseType(typeof(CustomerVM))]
        [Authorize]
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerVM customer = db.Customers
               .Select(c => new CustomerVM(c))
               .FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerVM customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            Customer cm = new Customer(customer);

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        [ResponseType(typeof(CustomerVM))]
        public IHttpActionResult PostCustomer(CustomerVM customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer cm = new Customer(customer);

            db.Customers.Add(cm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(CustomerVM))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            CustomerVM cmVm = new CustomerVM();
            cmVm.Id = customer.Id;
            cmVm.City = customer.City;
            cmVm.Country = customer.Country;
            cmVm.FirstName = customer.FirstName;
            cmVm.LastName = customer.LastName;
            cmVm.Phone = customer.Phone;

            return Ok(cmVm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}