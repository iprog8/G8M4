using CrmManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.Managers
{
    public class SupplierManager
    {
        public void Display()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Supplier> suppliers = db.Suppliers.ToList();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Id-ul: {supplier.Id} \nNumele companiei: {supplier.CompanyName} \nNumele de contact: {supplier.ContactName} \nTara: {supplier.Country} \nOrasul: {supplier.City}");
            }
        }
        public void Add(Supplier supplier)
        {
            CRMEntities db = new CRMEntities();
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier toBeDeleted = db.Suppliers.Find(id);
            if (toBeDeleted == null) return;
            db.Suppliers.Remove(toBeDeleted);
            db.SaveChanges();
        }
        public bool VerifyId(string id)
        {
            if(int.TryParse(id, out int newId))
            {
                if (newId < 1) return false;
                else if(new CRMEntities().Suppliers.Find(newId) != null)
                return true;
            }
            return false;
        }
        public void Modify(int id, string companyName, string contactName, string contactTitle, string city, string country, string phone)
        {
            CRMEntities db = new CRMEntities();
            Supplier toBeUpdated = db.Suppliers.Find(id);
            if (toBeUpdated == null) return;
            toBeUpdated.CompanyName = companyName;
            toBeUpdated.ContactName = contactName;
            toBeUpdated.ContactTitle = contactTitle;
            toBeUpdated.City = city;
            toBeUpdated.Country = country;
            toBeUpdated.Phone = phone;
            db.SaveChanges();
        }
    }
}
