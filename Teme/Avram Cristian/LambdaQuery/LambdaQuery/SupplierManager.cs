using LambdaQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaQuery
{
    public class SupplierManager
    {
        public void Insert(string company, string contact, string city, string country)
        {
            CRMEntities db = new CRMEntities();
            Supplier supplier = new Supplier();
            supplier.City = city;
            supplier.CompanyName = company;
            supplier.ContactName = contact;
            supplier.Country = country;
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier toBeDeleted = db.Suppliers.FirstOrDefault(s => s.Id == id);
            if (toBeDeleted != null)
            {
                db.Suppliers.Remove(toBeDeleted);
                db.SaveChanges();
            }
        }

        
    }
}
