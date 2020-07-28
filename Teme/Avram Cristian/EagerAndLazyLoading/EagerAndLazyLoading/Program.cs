using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EagerAndLazyLoading;
using EagerAndLazyLoading.Models;
using System.Data.Entity;

namespace EagerAndLazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;
            //1
            IQueryable<Product> products = db.Products.Include(c => c.OrderItems);
            products = products.Where(p => p.UnitPrice > 5);
            ICollection<Product> productsOver5 = products.ToList();
            Console.WriteLine($"{productsOver5.Count} de produse cu pretul mai mare de 5 lei");

            //2
            IQueryable<Supplier> supliers = db.Suppliers.Where(s => s.Country == "UK").Include(s => s.Products);
            ICollection<Supplier> supliersUK = supliers.ToList();
            foreach (var suplier in supliersUK)
            {
                Console.WriteLine($"Furnizorul {suplier.ContactName} din {suplier.Country} vinde {suplier.Products.Count} produse");
            }

            //3
            IQueryable<Product> products2 = db.Products.Include(s => s.Supplier);
            ICollection<Product> produseSite = products2.ToList();
            foreach (var p in produseSite)
            {
                Console.WriteLine($" Nume produs {p.ProductName} /  Pret produs {p.UnitPrice} / Exista pe stoc { p.IsDiscontinued} / Nume furnizor {p.Supplier.CompanyName}");
            }

            //4
            IQueryable<Customer> customers = db.Customers.Include(c => c.Orders);

            foreach (var c in customers)
            {
                Console.WriteLine($" {c.FirstName} {c.LastName} {c.Orders.Count}");
            }







            Console.ReadKey();

        }
    }
}
