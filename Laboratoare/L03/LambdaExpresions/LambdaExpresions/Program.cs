using LambdaExpresions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpresions
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierManager supplierManager = new SupplierManager();

            var products = supplierManager.GetProductsBySupplierId(1);

            var suppliers2 = supplierManager.GetAllByCityAndCountry("Bucuresti", "Romania");

            var s1 = supplierManager.GetByNameAndContact("da", "Ion Ion");

            var suppliers = supplierManager.GetAllByName("Da");
            Supplier s = supplierManager.GetByName("Da");

            s = supplierManager.GetById(35);
            supplierManager.GetAll();

            supplierManager.Update(37, "Da", "Ion Popa", "Bucuresti", "Romania");
            supplierManager.Delete(34);
            supplierManager.Insert("IpRO", "Io", "Buc", "Romania");

            Console.ReadKey();
        }

        public string Mananca(string felMancare)
        {
            return $"X mananca {felMancare}.";
        }


        // felMancare => $"X mananca {felMancare}."
    }
}
