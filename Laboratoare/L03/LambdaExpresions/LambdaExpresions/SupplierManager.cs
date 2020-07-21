using LambdaExpresions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpresions
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
            supplier.ContactTitle = "Dl";
            supplier.Country = country;
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }

        public void Insert(Supplier supplier)
        {
            CRMEntities db = new CRMEntities();
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

        public void Update(int id, string company, string contact, string city, string country)
        {
            CRMEntities db = new CRMEntities();
            Supplier toBeUpdated = db.Suppliers.Find(id);
            if(toBeUpdated != null)
            {
                toBeUpdated.CompanyName = company;
                toBeUpdated.ContactName = contact;
                toBeUpdated.ContactTitle = "Dl";
                toBeUpdated.City = city;
                toBeUpdated.Country = country;
                db.SaveChanges();
            }
        }

        public ICollection<Supplier> GetAll()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.ToList();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Supliee {supplier.CompanyName} - {supplier.ContactName}");
            }
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier supplier = db.Suppliers.Find(id);
            return supplier;
        }

        public Supplier GetByName(string companyName)
        {
            CRMEntities db = new CRMEntities();
            Supplier supp = db.Suppliers.FirstOrDefault(s => s.CompanyName == companyName);
            return supp;
        }

        public ICollection<Supplier> GetAllByName(string companyName)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.Where(s => s.CompanyName == companyName).ToList();
            return suppliers;
        }

        public int DeleteAllByName(string companyName)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.Where(s => s.CompanyName == companyName).ToList();
            if(suppliers.Count > 0)
            {
                db.Suppliers.RemoveRange(suppliers);
                return db.SaveChanges();
            }
            return 0;
        }

        public Supplier GetByNameAndContact(string companyName, string contact)
        {
            CRMEntities db = new CRMEntities();
            Supplier supplier = db.Suppliers.FirstOrDefault(s => s.CompanyName == companyName && s.ContactName == contact);
            return supplier;
        }

        public ICollection<Supplier> GetAllByCityAndCountry(string city, string country){
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.Where(s => s.City == city && s.Country == country).ToList();
            return suppliers;
        }

        public ICollection<Product> GetProductsBySupplierId(int supplierId)
        {
            CRMEntities db = new CRMEntities();
            ICollection < Product > products = db.Products.Where(p => p.SupplierId == supplierId).ToList();
            return products;
        }
    }
}
