using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.Managers
{
    public class CustomerManager
    {
        public void Display()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customer.ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id-ul: {customer.Id} \nNumele clientului: {customer.FirstName} {customer.LastName} \nOrasul: {customer.City} \nTara: {customer.Country}");
            }
        }
        public void Add(Customer customer)
        {
            CRMEntities db = new CRMEntities();
            db.Customer.Add(customer);
            db.SaveChanges();
        }
        public void Modify(int id, string firstName, string lastName, string city, string country)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customer.Find(id);
            if (toBeUpdated == null) return;
            toBeUpdated.FirstName = firstName;
            toBeUpdated.LastName = lastName;
            toBeUpdated.City = city;
            toBeUpdated.Country = country;
            db.SaveChanges();
        }
        public bool VerifyId(string id)
        {
            if (int.TryParse(id, out int newId))
            {
                if (newId < 1) return false;
                else if (new CRMEntities().Customer.Find(newId) != null)
                    return true;
            }
            return false;
        }
        public Customer GetCustomerById(int id)
        {
            return new CRMEntities().Customer.Find(id);
        }
        public void Delete(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeDeleted = db.Customer.Find(id);
            if (toBeDeleted == null) return;
            db.Customer.Remove(toBeDeleted);
            db.SaveChanges();
        }
    }
}
