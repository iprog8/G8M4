using L3.Managers;
using L3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersManager customerManager = new CustomersManager();
            OrdersManager ordersManager = new OrdersManager();
            ProductsManager productsManager = new ProductsManager();
       
            //customerManager.Insert("Hanu", "Gabriel", "Focsani", "Romania", "071234");
            //customerManager.Insert("Gigel", "Alexandru", "Buzau", "Romania", "074321");
            //customerManager.Update(5,"Marcel","Marius");
            var customers = customerManager.GetAllByCity("Paris");
            var ordersOfCustomer = customerManager.GetAllOrdersById(14);

            var ordersOverBy = ordersManager.GetAllByTAOver(5000);

            var topProducts = productsManager.GetTop(5);
            Console.ReadKey();
        }
    }
}
