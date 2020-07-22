using LambdaQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaQuery
{
    public class OrdersManager
    {
        public void SelectByTA(int totalAmount)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> toBeSelected = db.Orders.Where(e => e.TotalAmount > totalAmount).ToList();
        }
    }
}
