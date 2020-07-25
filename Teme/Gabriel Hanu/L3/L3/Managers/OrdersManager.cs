using L3.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3.Managers
{
    public class OrdersManager
    {
        public ICollection<Order> GetAllByTAOver(int totalAmount)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> toBeSelected = db.Orders.Where(o => o.TotalAmount > totalAmount).ToList();
            return toBeSelected;
        }
    }
}
