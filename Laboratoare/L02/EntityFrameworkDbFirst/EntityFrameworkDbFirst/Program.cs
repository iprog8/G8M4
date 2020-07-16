using EntityFrameworkDbFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //Supplier s = new Supplier();
            CRMEntities db = new CRMEntities();
            db.Database.Log += logQuery;

            List<Supplier> suppliers = db.Suppliers.ToList();

            List<Customer> customers = db.Customers.ToList();

            List<Order> ordersOver1000 = db.Orders.Where(o => o.TotalAmount > 1000).ToList();

            Supplier s1 = db.Suppliers.FirstOrDefault();

            Console.ReadKey();
        }

        private static void logQuery(string log)
        {
            Console.WriteLine(log);
        }
    }
}
