using EFandLambdaExpressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFandLambdaExpressions
{
    public class Produse
    {
        public ICollection<Product> CeleMaiScumpe()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Product> produse = db.Product.ToList();
            ushort maxProduse = 4;
            foreach (var costProdus in produse.Where(p => p.UnitPrice > p.UnitPrice))
            {
                if(db.Product.ToList().Count <= maxProduse)
                {
                    db.Product.ToList().Add(costProdus);
                }
                else
                {
                    db.Product.ToList().RemoveAt(0);
                    db.Product.ToList().Add(costProdus);
                }
            }
            return produse;
        }
    }
}
