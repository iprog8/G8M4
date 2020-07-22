using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierManager supplierManager = new SupplierManager();
            CustomersManager customersManager = new CustomersManager();
            OrdersManager ordersManager = new OrdersManager();
            ProductsManager productsManager = new ProductsManager();
            //supplierManager.Insert("Client1", "Client1Name", "Craiova", "Romania");
            //supplierManager.Insert("Client2", "Client2Name", "Constanta", "Romania");
            supplierManager.Delete(35);
            customersManager.UpdateByID(5, "Cristianie", "Ronaldo");
            ordersManager.SelectByTA(5000);
            customersManager.SelectByCustomerId(14);
            customersManager.SelectByCity("Paris");
            //productsManager.GetTop(4);




            Console.ReadKey();

        }
    }
}
