using Lab03_LambdaEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_LambdaEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager cust1 = new CustomerManager();
            //CustomerManager cust2 = new CustomerManager();
            //cust1.Insert(1, "Sandu", "Mardare", "Pantelimon", "Romania");
            //cust2.Insert(2, "Mircea", "Nebunu", "Ferentari", "Romania");

            CustomerManager customerManager = new CustomerManager();
            customerManager.UpdateFirstLastName(5, "Vitoria", "Lipan");
            OrdersManager ordersManager = new OrdersManager();
            var ord1 = ordersManager.GetAllByAmount(5000);
            Console.WriteLine($"The total number of orders of over 5000$ is : {ord1.Count}");

            var ord2 = ordersManager.GetAllByCustomerId(14);
            Console.WriteLine($"The customer with id = 14 has placed : {ord2.Count} orders");

            var cust1 = customerManager.GetAllByCity("Paris");
            Console.WriteLine($"The total number of customers living in Paris is : {cust1.Count}");

            ProductManager productManager = new ProductManager();
            var prd1 = productManager.GetTopXMostExpensive(5);

            Console.WriteLine($"The most expensive product costs {prd1.ElementAt(0).UnitPrice}"); 
            Console.ReadKey();

        }
    }
}
