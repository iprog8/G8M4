using Crm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;
            IQueryable<Product> products = db.Products;
            IQueryable<Product> productsWithValueLessThan5 = products.Where(p => p.UnitPrice < 5);


            //Primul punct
            ICollection<Product> productsWithOrders = productsWithValueLessThan5.Include(p => p.OrderItems).ToList();
            ICollection<Product> prds = db.Products
                .Include(p => p.OrderItems)
                .Where(p => p.UnitPrice < 5)
                .ToList();
            foreach (var product in productsWithOrders)
            {
                Console.WriteLine($"Numele produsului: {product.ProductName} \nNumar comenzi: {product.OrderItems.Count()}");
            }


            //Al doilea punct
            IQueryable<Supplier> suppliersInUK = db.Suppliers.Where(s => s.Country == "UK");
            ICollection<Supplier> suppliersWithProducts = suppliersInUK.Include(s => s.Products).ToList();
            foreach (var supplier in suppliersWithProducts)
            {
                Console.WriteLine($"Furnizorul: {supplier.ContactName} \nNumar produse: {supplier.Products.Count()}");
            }


            //Al treilea punct
            ICollection<Product> productsList = products.Include(p => p.Supplier).ToList();
            foreach (var product in productsList)
            {
                Console.WriteLine($"Numele produsului: {product.ProductName} \nPretul: {product.UnitPrice} \nIn stoc: {product.IsDiscontinued} \nNume furnizor: {product.Supplier.ContactName}");
            }


            //Al patrulea punct 
            IQueryable<Customer> customers = db.Customers.Include(c => c.Orders);
            ICollection<Customer> customersWithOrders = customers.ToList();
            foreach (var customer in customersWithOrders)
            {
                Console.WriteLine($"Clientul: {customer.FirstName} \nNumarul de comenzi: {customer.Orders.Count()}");
            }


            //Ultimul punct
            /*5.Sa selectati toate produsele mai ieftine de 5 lei si sa afisati
            si cate produse au fost vandute.Nu uitati de eager-lazy loading;*/
            // 
            ICollection<Product> products2 = db.Products
                .Include(p => p.OrderItems)
                .Where(p => p.UnitPrice < 5)
                .ToList();
            foreach (var product in products2)
            {
                Console.WriteLine($"Numele produsului: {product.ProductName} apare pe {product.OrderItems.Count} si s-au vandut {product.OrderItems.Sum(p => p.Quantity)}");
            }
            Console.ReadKey();
        }
    }
}
