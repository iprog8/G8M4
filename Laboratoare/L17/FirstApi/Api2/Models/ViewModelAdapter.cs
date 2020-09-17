using Api2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api2.Models
{

    public partial class Customer
    {

        public Customer(CustomerVM customerVM)
        {
            this.Id = customerVM.Id;
            this.City = customerVM.City;
            this.Country = customerVM.Country;
            this.FirstName = customerVM.FirstName;
            this.LastName = customerVM.LastName;
            this.Phone = customerVM.Phone;
        }

    }

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

    public partial class Currency
    {

        public Currency()
        {

        }

        public Currency(CurrencyVM currency)
        {
            Id = currency.Id;
            Valuta = currency.Valuta;
            Paritate = currency.Paritate;
        }

    }
}