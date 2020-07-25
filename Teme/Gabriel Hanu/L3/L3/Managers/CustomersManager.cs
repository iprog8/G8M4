using L3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace L3.Managers
{
    public class CustomersManager
    {
        public void Insert(string firstName, string lastName, string city, string country, string phone)
        {
            CRMEntities db = new CRMEntities();
            Customer tempCustomer = new Customer();
            tempCustomer.FirstName = firstName;
            tempCustomer.LastName = lastName;
            tempCustomer.City = city;
            tempCustomer.Country = country;
            tempCustomer.Phone = phone;
            db.Customers.Add(tempCustomer);
            db.SaveChanges();
        }
        public void Update(int id, string firstName, string lastName)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customers.Find(id);
            if (toBeUpdated == null) return;
            toBeUpdated.FirstName = firstName;
            toBeUpdated.LastName = lastName;
            db.SaveChanges();
        }
        public ICollection<Customer> GetAllByCity(string city)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.Where(c => c.City == city).ToList();
            return customers;
        }
        public ICollection<Order> GetAllOrdersById(int customerId)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> orders = db.Orders.Where(o => o.CustomerId == customerId).ToList();
            return orders;
        }
    }
}
