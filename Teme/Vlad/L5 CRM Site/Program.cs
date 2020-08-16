using L5_CRM_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

namespace L5_CRM_Site
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMEntities db = new CRMEntities();
            db.Database.Log += Console.WriteLine;

            /*1.CRM trebuie sa faca un site in care sa includa o pagina in care administratorul site - ului sa vada lista de furnizori si numarul de produse pe care acestia le detin.
            Creati un query folosind lambda expression care sa afiseze doar 10 elemente pe pagina.*/
            /*var suppliers = db.Suppliers
                .Include(p => p.Products)
                .Select(s => new SuppliersManager()
                {
                    companyName = s.CompanyName,
                    products = s.Products.Count()
                })
                .Take(10)
                .ToList();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"The company {supplier.companyName} has {supplier.products}  products");
            }*/
            

            //2.Plecand de la punctul 1 afisati pagina 3.
            var suppliers2 = db.Suppliers
                .Include(p => p.Products)  
                .Select(s => new SuppliersManager()
                {
                    companyName = s.CompanyName,
                    products = s.Products.Count()
                })
                .OrderBy(s => s.companyName)
                .Skip(20)
                .Take(10)
                .ToList();
            foreach (var supplier2 in suppliers2)
            {
                Console.WriteLine($"The company {supplier2.companyName} has {supplier2.products}  products");
            }
          

            //*3.Selectati toate comenzile si afisati la fiecare comanda cate produse s-au vandut. Sa se afiseze cate 20 se elemente pe pagina pentru paginele 2 si 4.

            var orders = db.Orders
                .Include(oi => oi.OrderItems)
                .OrderBy(o => o.Id)
                .Skip(20)
                .Take(20)
                .ToList();
            foreach (var order in orders) {
                Console.WriteLine($"Order number {order.Id} has a total of {order.OrderItems.Sum(oi => oi.Quantity)} products sold");
            }
            Console.ReadKey();

            var orders2 = db.Orders
                .Include(oi => oi.OrderItems)
                .OrderBy(o => o.Id)
                .Skip(60)
                .Take(20)
                .ToList();
            foreach (var order2 in orders2)
            {
                Console.WriteLine($"Order number {order2.Id} has a total of {order2.OrderItems.Sum(oi => oi.Quantity)} products sold");
            }
            //4.Sa selectati toti furnizorii si sa afisati si cate produse vinde fiecare. Sa se afiseze cate 10 se elemente pe pagina pentru prima si ultima Pagina*/
            var suppliers4 = db.Suppliers
                .Include(s => s.Products)
                .Include(s => s.Products.Select(p => p.OrderItems))
                .OrderBy(s => s.CompanyName)
                .Skip(10)
                .Take(10)
                .ToList();
            foreach (var supplier in suppliers4)
            {
                Console.WriteLine($"The Supplier {supplier.CompanyName} has sold {supplier.Products.Sum(p=>p.OrderItems.Sum(oi => oi.Quantity))} products");
            }
            Console.ReadKey();

        }
    }
}
