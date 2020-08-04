using CrmManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.Managers
{
    public class CustomersManager
    {
        /// <summary>
        /// Get all the customers and display them
        /// </summary>
        public void DisplayCustomers()
        {
            //get the data base on
            CRMEntities db = new CRMEntities();
            //store all the customers
            ICollection<Customer> customers = db.Customers.ToList();
            //loop thru the list and display all the customers
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id-ul: {customer.Id} \nNumele clientului: {customer.FirstName} {customer.LastName} \nOrasul: {customer.City} \nTara: {customer.Country}");
            }
        }
        public void AddCustomer(Customer customer)
        {
            //get the data base on
            CRMEntities db = new CRMEntities();
            //add the customer 
            db.Customers.Add(customer);
            //save the changes to the data base
            db.SaveChanges();
        }
        public void ModifyCustomer(int id, string firstName, string lastName, string city, string country)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customers.Find(id);
            if (toBeUpdated == null) return;
            toBeUpdated.FirstName = firstName;
            toBeUpdated.LastName = lastName;
            toBeUpdated.City = city;
            toBeUpdated.Country = country;
            db.SaveChanges();
        }
        public Customer GetCustomerById(int id)
        {
            return new CRMEntities().Customers.Find(id);
        }
        public bool DeleteCustomer(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeDeleted = db.Customers.Find(id);
            if (toBeDeleted == null) return false;
            db.Customers.Remove(toBeDeleted);
            db.SaveChanges();
            return true;
        }
    }
}  

