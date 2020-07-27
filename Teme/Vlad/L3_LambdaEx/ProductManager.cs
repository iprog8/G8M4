using Lab03_LambdaEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_LambdaEx
{
    public class ProductManager
    {
        public ICollection<Product> GetTopXMostExpensive(int x)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Product> products = db.Products.OrderByDescending(p => p.UnitPrice).Take(x).ToList(); //Icollection nu merge. De ce?
            return products;
        }
    }
}
