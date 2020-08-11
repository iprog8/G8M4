using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmWithMorePages.Models
{
    public class CustomerManager
    {
        public CustomerManager()
        {
            BasicCustomer = new Customer();
            BasicCustomer.FirstName = BasicCustomer.LastName = BasicCustomer.City = BasicCustomer.Country = BasicCustomer.Phone = string.Empty;       
        }
        private Customer BasicCustomer { get; set; }
        public void GetNew(Customer newCustomer)
        {
            BasicCustomer.FirstName = newCustomer.FirstName;
            BasicCustomer.LastName = newCustomer.LastName;
            BasicCustomer.City = newCustomer.City;
            BasicCustomer.Country = newCustomer.Country;
            BasicCustomer.Phone = newCustomer.Phone;
        }
        public IEnumerable<string> GetProps()
        {
            return new string[] { $"Prenume: {BasicCustomer.FirstName}", $"Nume: {BasicCustomer.LastName}",
                $"Oras: {BasicCustomer.City}", $"Tara: {BasicCustomer.Country}",
                $"Numar de telefon: {BasicCustomer.Phone}" };
        }
        public void Update(string selectedProp, string value, int id)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customers.Find(id);
            switch (selectedProp)
            {
                case "Prenume":
                    toBeUpdated.FirstName = value;
                    break;
                case "Nume":
                    toBeUpdated.LastName = value;
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
                default:
                    break;
            }
            db.SaveChanges();
        }
    }
}
