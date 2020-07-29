using L4_EagerLazyLoading.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_EagerLazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;
            //Sa selectati toti furnizorii din UK si sa afisati si cate produse vinde fiecare. Nu uitati de eager-lazy loading;
            ICollection<Product> productsLessThan5 = db.Products.Include(p => p.OrderItems).Where(p => p.UnitPrice < 5).ToList();
            foreach (var prd in productsLessThan5)
            {
                Console.WriteLine($"The product {prd.ProductName} appears on {prd.OrderItems.Count()} orders ");
            }

            //Sa selectati toti furnizorii din UK si sa afisati si cate produse vinde fiecare. Nu uitati de eager-lazy loading;
            ICollection<Supplier> suppliersFromUk = db.Suppliers.Include(sp => sp.Products).Where(sp => sp.Country == "UK").ToList();
            foreach (var spl in suppliersFromUk)
            {
                Console.WriteLine($"The UK supplier {spl.ContactName} sells {spl.Products.Count()} products.");
            }

            /*CRM trebuie sa faca un site in care sa se afiseze lista de produse. Pentru fiecare produs trebuie sa se afiseze: denumirea produsului,
            pretul, daca este in stoc (is discontinued), si numele furnizorului.
            Creati un query folosind lambda expression. Nu uitati de eager-lazy loading;*/
            ICollection<Product> productList = db.Products.Include(p => p.Supplier).ToList();
            foreach ( var prd in productList)
            {
                Console.WriteLine($"Product's name : {prd.ProductName} , product's price: {prd.UnitPrice}, In Stock/Out of stock:  {prd.IsDiscontinued} , Supplier's name : {prd.Supplier.CompanyName}");
            }

            /*CRM trebuie sa faca un site in care sa includa o pagina in care administratorul 
            site-ului sa vada lista de de clienti si numarul de comenzi pe care acestia le-au facut. 
            Creati un query folosind lambda expression. Nu uitati de eager-lazy loading;*/
            ICollection<Customer> customers = db.Customers.Include(o => o.Orders).ToList();
            foreach ( var cst in customers)
            {
                Console.WriteLine($"The client, {cst.FirstName} {cst.LastName} has placed {cst.Orders.Count()} orders");
            }
            //Sa selectati toate produsele mai ieftine de 5 lei si sa afisati si cate produse au fost vandute. Nu uitati de eager-lazy loading;
            ICollection<Product> productsLessThan5Sold = db.Products.Include(o => o.OrderItems).Where(p => p.UnitPrice < 5).ToList();
            foreach (var prd in productsLessThan5Sold)
            {
                Console.WriteLine($"The product {prd.ProductName} was sold in {prd.OrderItems.Sum(s => s.Quantity)} units");
            }

            Console.ReadKey();
        }
    }
}
