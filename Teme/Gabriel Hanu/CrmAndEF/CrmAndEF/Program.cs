using CrmAndEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

namespace CrmAndEF
{
    class Program
    {
        static string delimitator = "-----------------------------------------------------------------";
        static void Main(string[] args)
        {
            CRMEntities db = new CRMEntities();
            //db.Database.Log += Console.WriteLine;

            /*1. CRM trebuie sa faca un site in care sa includa o pagina in care administratorul site - ului 
            sa vada lista de furnizori si numarul de produse pe care acestia le detin. Creati un query 
            folosind lambda expression care sa afiseze doar 10 elemente pe pagina.*/

            displayListOfSuppInPage(db,1,10);

            /*2. Plecand de la punctul 1 afisati pagina 3*/

            displayListOfSuppInPage(db,3,10);

            /*3. Selectati toate comenzile si afisati la fiecare comanda cate produse s - au vandut.
            Sa se afiseze cate 20 se elemente pe pagina pentru paginele 2 si 4.*/

            displayOrdersAndItemsOnPage(db, 2, 20);
            displayOrdersAndItemsOnPage(db, 4, 20);

            /*4. Sa selectati toti furnizorii si sa afisati si cate produse vinde fiecare.
            Sa se afiseze cate 10 elemente pe pagina pentru prima si ultima Pagina*/

            displaySuppAndQuantityOfProducts(db, 1, 10);
            displaySuppAndQuantityOfProducts(db, 0, 10);
            Console.ReadKey();
        }

        private static void displayListOfSuppInPage(CRMEntities dataBase ,int numOfPage, int elemsInPage)
        {
            if (numOfPage < 1 || elemsInPage < 1) return;
            int elemsToSkip = (numOfPage - 1) * elemsInPage;
            var suppliers = dataBase.Suppliers
                .Include(s => s.Products)
                .Select(s => new { s.CompanyName, s.ContactName, s.Country, s.Products })
                .OrderBy(s => s.Country)
                .Skip(elemsToSkip)
                .Take(elemsInPage)
                .ToList();
            Console.WriteLine($"\nPagina cu numarul: {numOfPage}\n");
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Numele companiei: {supplier.CompanyName} \nNumele de contact: {supplier.ContactName} \nTara: {supplier.Country} \nNumar produse: {supplier.Products.Count} \n{delimitator}");
            }
        }
        private static void displayOrdersAndItemsOnPage(CRMEntities dataBase, int numOfPage, int elemsInPage)
        {
            if (numOfPage < 1 || elemsInPage < 1) return;
            int elemsToSkip = (numOfPage - 1) * elemsInPage;
            Console.WriteLine($"\nPagina: {numOfPage}:\n");
            var orders = dataBase.Orders
                .Include(o => o.OrderItems)
                .Select(o => new { o.OrderNumber, o.TotalAmount, o.OrderDate, o.OrderItems })
                .OrderBy(o => o.TotalAmount)
                .Skip(elemsToSkip)
                .Take(elemsInPage)
                .ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Numarul comenzii: {order.OrderNumber} \nData comenzii: {order.OrderDate} \nSuma totala: {order.TotalAmount} \nProduse vandute: {order.OrderItems.Count} \n{delimitator}");
            }
        }
        private static void displaySupp(dynamic supp)
        {
            foreach (var supplier in supp)
            {
                Console.WriteLine($"Numele companiei: {supplier.CompanyName} \nProduse vandute: {supplier.Quantity} \n{delimitator}");
            }
        }
        private static void displaySuppAndQuantityOfProducts(CRMEntities dataBase, int numOfPage, int elemsInPage)
        {
            if (numOfPage < 0 || elemsInPage < 1) return;
            int elemsToSkip = (numOfPage - 1) * elemsInPage;
            var supp = (
                from s in dataBase.Suppliers
                join p in dataBase.Products
                on s.Id equals p.SupplierId
                join oi in dataBase.OrderItems
                on p.Id equals oi.ProductId
                select new
                {
                    companyName = s.CompanyName,
                    quantity = p.OrderItems.Sum(o => o.Quantity)
                })
                .Distinct()
                .GroupBy(s => s.companyName)
                .Select(g => new
                {
                    Quantity = g.Sum(s => s.quantity),
                    CompanyName = g.FirstOrDefault().companyName
                })
                .OrderBy(s => s.CompanyName);
            if (numOfPage == 0)
            {
                Console.WriteLine("\nUltima pagina");
                if (supp.Count() < elemsInPage)
                {
                    Console.WriteLine($"Numarul de elemente introdus de tine este mai mare decat elementele din baza de date, iti vom afisa primele 10 elemnte...");
                    var suppliers = supp
                        .Take(10)
                        .ToList();
                    displaySupp(suppliers);
                }
                else if (supp.Count() % elemsInPage == 0)
                {
                    var suppliers = supp
                        .Reverse()
                        .Take(elemsInPage)
                        .ToList();
                    displaySupp(suppliers);
                }
                else
                {
                    var suppliers = supp
                        .Skip(supp.Count() - (supp.Count() % elemsInPage))//din totalul elementelor scad restul impartirii a totalul elementelor cu cate elemente sunt pe pagina
                        .Take(supp.Count() % elemsInPage)
                        .ToList();
                    displaySupp(suppliers);
                }
            }
            else
            {
                Console.WriteLine($"\nPagina cu numarul: {numOfPage}");
                var suppliers = supp
                    .Skip(elemsToSkip)
                    .Take(elemsInPage)
                    .ToList();
                displaySupp(suppliers);
            }
        }
    }
}
