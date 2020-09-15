using Api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api2.ViewModels
{
    public class CustomerVM
    {
        public CustomerVM()
        {
        }

        public CustomerVM(Customer customer)
        {
            this.Id = customer.Id;
            this.City = customer.City;
            this.Country = customer.Country;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.Phone = customer.Phone;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

}