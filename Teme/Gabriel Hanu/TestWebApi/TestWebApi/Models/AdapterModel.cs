using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApi.ViewModels;

namespace TestWebApi.Models
{
    public partial class Supplier
    {
        public Supplier(SupplierViewModel supplierVM)
        {
            this.Id = supplierVM.Id;
            this.CompanyName = supplierVM.CompanyName;
            this.ContactName = supplierVM.ContactName;
            this.ContactTitle = supplierVM.ContactTitle;
            this.City = supplierVM.City;
            this.Country = supplierVM.Country;
            this.Phone = supplierVM.Phone;
        }
    }
}