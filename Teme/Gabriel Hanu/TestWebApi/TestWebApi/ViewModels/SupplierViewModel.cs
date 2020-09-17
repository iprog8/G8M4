using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TestWebApi.Models;

namespace TestWebApi.ViewModels
{
    public class SupplierViewModel
    {
        public SupplierViewModel()
        {

        }
        public SupplierViewModel(Supplier supplier)
        {
           this.Id = supplier.Id;
           this.CompanyName = supplier.CompanyName;
           this.ContactName = supplier.ContactName;
           this.ContactTitle = supplier.ContactTitle;
           this.City = supplier.City;
           this.Country = supplier.Country;
           this.Phone = supplier.Phone;
        }
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}