using L3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3.Managers
{
    public class ProductsManager
    {
        public IEnumerable<Product> GetTop(int numberOfProducts)
        {
            CRMEntities db = new CRMEntities();
            IEnumerable<Product> products = db.Products.OrderByDescending(u => u.UnitPrice).Take(numberOfProducts);
            return products;
        }
    }
}
