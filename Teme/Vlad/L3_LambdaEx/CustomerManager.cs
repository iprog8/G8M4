using Lab03_LambdaEx.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_LambdaEx
{
    public class CustomerManager
    {
        public void Insert (int id, string firstName, string lastName, string city, string country)
        {
            CRMEntities db = new CRMEntities();
            Customer customer = new Customer();
            customer.Id = id;
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.City = city;
            customer.Country = country;
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public void UpdateFirstLastName(int id, string firstName, string lastName)
        {
            CRMEntities db = new CRMEntities();
            Customer customer = new Customer();
            var customerUpdated = db.Customers.Find(5);

            if (customerUpdated != null)
            {
                customerUpdated.FirstName = firstName;
                customerUpdated.LastName = lastName;
                db.SaveChanges();
            }
        }

        public ICollection<Customer> GetAllByCity(string city)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.Where(c => c.City == city).ToList();
            return customers;
        }
    }
}
