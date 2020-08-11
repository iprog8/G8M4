using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.Managers
{
    public class SupplierManager
    {
        public SupplierManager()
        {
            BasicSupplier = new Supplier();
            BasicSupplier.CompanyName = BasicSupplier.ContactName = BasicSupplier.ContactTitle = BasicSupplier.City = BasicSupplier.Country = BasicSupplier.Phone = BasicSupplier.Fax = string.Empty;
        }
        private Supplier BasicSupplier { get; set; }
        public void GetNew(Supplier newSupplier)
        {
            BasicSupplier.CompanyName = newSupplier.CompanyName;
            BasicSupplier.ContactName = newSupplier.ContactName;
            BasicSupplier.ContactTitle = newSupplier.ContactTitle;
            BasicSupplier.City = newSupplier.City;
            BasicSupplier.Country = newSupplier.Country;
            BasicSupplier.Phone = newSupplier.Phone;
            BasicSupplier.Fax = newSupplier.Fax;
        }
        public IEnumerable<string> GetProps() 
        {
            return new string[] { $"Numele companiei: {BasicSupplier.CompanyName}", $"Nume de contact: {BasicSupplier.ContactName}",
                $"Titlu de contact: {BasicSupplier.ContactTitle}", $"Oras: {BasicSupplier.City}",
                $"Tara: {BasicSupplier.Country}", $"Numar de telefon: {BasicSupplier.Phone}",
                $"Fax: {BasicSupplier.Fax}"};
        }
        public void Update(string selectedProp, string value, int id)
        {
            CRMEntities db = new CRMEntities();
            Supplier toBeUpdated = db.Suppliers.Find(id);
            switch (selectedProp)
            {
                case "Numele companiei":
                    toBeUpdated.CompanyName = value;
                    break;
                case "Nume de contact":
                    toBeUpdated.ContactName = value;
                    break;
                case "Titlu de contact":
                    toBeUpdated.ContactTitle = value;
                    break;
                case "Oras":
                    toBeUpdated.City = value;
                    break;
                case "Tara":
                    toBeUpdated.Country = value;
                    break;
                case "Numar de telefon":
                    toBeUpdated.Phone = value;
                    break;
                case "Fax":
                    toBeUpdated.Fax = value;
                    break;
                default:
                    break;
            }
            db.SaveChanges();
        }
    }
}
