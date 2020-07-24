using EagerLazyLoading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EagerLazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {

            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;
            Customer customer = db.Customers.SingleOrDefault(c => c.FirstName == "Carine");
            var customers = db.Customers
                .Where(c => c.Country == "USA")
                .OrderByDescending(c => c.City)
                .ThenByDescending(c => c.FirstName)
                .ThenBy(c => c.LastName).ToList();

            EagerLazy();
            Console.ReadKey();
        }

        private static void EagerLazy()
        {
            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;
            IQueryable<Customer> cs = db.Customers;
            //.....
            cs = cs.Where(c => c.City == "London");

            //ICollection<Customer> customers = db.Customers.ToList();
            Customer customer = cs.FirstOrDefault();
            cs = cs.Include(c => c.Orders);
            IOrderedQueryable<Customer> customersLonSort = cs.OrderBy(c => c.LastName);
            //....
            ICollection<Customer> customersLon = customersLonSort.ToList();

            bool exist = customersLon.Contains(customer);
            int ntCustomers = customersLonSort.Count();

            foreach (var cc in customersLon)
            {
                Console.WriteLine($"{cc.LastName} + {cc.FirstName}: {cc.Orders.Count} comenzi");
            }
        }
    }
}
