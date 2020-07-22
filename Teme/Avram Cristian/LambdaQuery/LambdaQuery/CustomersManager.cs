using LambdaQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaQuery
{
    public class CustomersManager
    {
        public void UpdateByID(int id, string firstNme, string lastName)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customers.Find(id);
            if (toBeUpdated != null)
            {
                toBeUpdated.FirstName = firstNme;
                toBeUpdated.LastName = lastName;
                db.SaveChanges();
            }
        }

        public ICollection<Order> SelectByCustomerId(int customerId)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> orders = db.Orders.Where(s => s.CustomerId == customerId).ToList();
            return orders;
        }

        public ICollection<Customer> SelectByCity(string city)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.Where(a => a.City == city).ToList();
            return customers;
        }
    }
}
