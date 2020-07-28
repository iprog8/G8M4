using EagerLazyLoading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using EagerLazyLoading.CustomModels;

namespace EagerLazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {

            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;

            //Linq sql 
            ICollection<Order> orders2 = (from o in db.Orders
                                          where o.TotalAmount > 1000
                                          select o).ToList();
            var orders4 = (from o in db.Orders
                           join c in db.Customers
                           on o.CustomerId equals c.Id
                                          where o.TotalAmount > 1000
                                          select new { Customer = c, Order = o }).ToList();
            var orders3 = (from o in db.Orders
                                          where o.TotalAmount > 1000
                                          select new { o.Id, o.OrderNumber }).ToList();

            orders2 = db.Orders.Where(o => o.TotalAmount > 1000).ToList();

            //sum
            decimal totalVanzari = db.Orders.Sum(o => o.TotalAmount).GetValueOrDefault();
            //count
            int nrComenziMaiMariDe1000 = db.Orders.Count(o => o.TotalAmount > 1000);
            //nrComenziMaiMariDe1000 = db.Orders.Where(o => o.TotalAmount > 1000).Count();
            //min
            decimal celMaiIefttinProdus = db.Products.Min(p => p.UnitPrice).GetValueOrDefault();
            //max
            decimal celMaiScumProdus = db.Products.Max(p => p.UnitPrice).GetValueOrDefault();
            //average
            decimal valoareaMedieAComenzii = db.Orders.Average(o => o.TotalAmount).GetValueOrDefault();


            //comenzile clientului cu id-ul 12
            ICollection<Order> orders = db.Orders.Where(o => o.CustomerId < 12).ToList();

            ICollection<Order> orders1 = db.Customers
                .Include(c => c.Orders)
                .Where(c => c.Id < 12)
                .Where(c => c.Country == "UK")
                .SelectMany(c => c.Orders).ToList();
            
            var customers1 = db.Customers
                .Take(12)
                .Select(c => new { c.FirstName, c.LastName, c.Phone }).ToList();

            ICollection<CustomerInfo> customers2 = db.Customers
                .Take(12)
                .Select(c => new CustomerInfo() { FirstName = c.FirstName, LastName = c.LastName, Phone = c.Phone }).ToList();

            Customer customer1 = new Customer();
            Customer customer2 = db.Customers.Create();

            /*5.Sa selectati toate produsele mai ieftine de 5 lei si sa afisati
            si cate produse au fost vandute.Nu uitati de eager-lazy loading;*/
            // 
            Console.WriteLine("Page 1");
            ICollection<Product> products2 = db.Products
                .Include(p => p.OrderItems)
                .Where(p => p.UnitPrice > 5)
                .OrderBy(p => p.UnitPrice)
                .Distinct() // asigura unicitatea inregistrarilor
                .Take(12)
                .ToList();
            foreach (var product in products2)
            {
                Console.WriteLine($"Numele produsului: {product.ProductName} apare pe {product.OrderItems.Count} si s-au vandut {product.OrderItems.Sum(p => p.Quantity)}");
            }
            Console.WriteLine("Page 2");
            products2 = db.Products
                .Include(p => p.OrderItems)
                .Where(p => p.UnitPrice > 5)
                .OrderBy(p => p.UnitPrice)
                .Skip(12)
                .Take(12)
                .ToList();
            foreach (var product in products2)
            {
                Console.WriteLine($"Numele produsului: {product.ProductName} apare pe {product.OrderItems.Count} si s-au vandut {product.OrderItems.Sum(p => p.Quantity)}");
            }

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
