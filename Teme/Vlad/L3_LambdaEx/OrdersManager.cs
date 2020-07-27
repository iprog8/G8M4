using Lab03_LambdaEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_LambdaEx
{
    class OrdersManager
    {
        public ICollection<Order> GetAllByAmount (int totalAmount)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> orders = db.Orders.Where(o => o.TotalAmount >= totalAmount).ToList();
            return orders;
        }

        public ICollection<Order> GetAllByCustomerId (int customerID)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> orders = db.Orders.Where(o => o.CustomerId == customerID).ToList();
            return orders;
        }
    }
}
