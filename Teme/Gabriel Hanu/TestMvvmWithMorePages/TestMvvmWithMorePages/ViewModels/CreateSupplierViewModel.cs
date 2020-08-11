using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.ViewModels
{
    public class CreateSupplierViewModel: Screen
    {
        public CreateSupplierViewModel(ShellViewModel shellViewModel)
        {
            MainWindow = shellViewModel;
        }
        public ShellViewModel MainWindow { get; set; }
        private bool _camComplete = false;
        private string _companyName;
        private string _contactName;
        private string _contactTitle;
        private string _city;
        private string _country;
        private string _phone;
        private string _fax;

        public string CompanyName
        {
            get { return _companyName; }
            set 
            {
                if (value.Length < 40) _companyName = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => CompanyName);
            }
        }
        public string ContactName
        {
            get { return _contactName; }
            set 
            {
                if (value.Length < 50) _contactName = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => ContactName);
            }
        }
        public string ContactTitle
        {
            get { return _contactTitle; }
            set 
            {
                if (value.Length < 40) _contactTitle = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => ContactTitle);
            }
        }
        public string City
        {
            get { return _city; }
            set 
            {
                if (value.Length < 40) _city = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => City);
            }
        }
        public string Country
        {
            get { return _country; }
            set 
            {
                if (value.Length < 40) _country = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => Country);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set 
            {
                if (value.Length < 30) _phone = MainWindow.ProcessNumber(value);
                NotifyOfPropertyChange(() => Phone);
            }
        }
        public string Fax
        {
            get { return  _fax; }
            set 
            {
                if (value.Length < 30) _fax = MainWindow.ProcessNumber(value);
                NotifyOfPropertyChange(() => Fax);
            }
        }
        public bool CanComplete
        {
            get { return _camComplete; }
            set { _camComplete = value; NotifyOfPropertyChange(() => CanComplete); }
        }

        public bool CanSubmit(string companyName, string contactName, string contactTitle, string city, string country, string phone, string fax)
        {
            if (companyName.Length > 2)
            {
                CanComplete = true;
                return true;
            }
            return false;
        }
        public void Submit(string companyName, string contactName, string contactTitle, string city, string country, string phone, string fax)
        {
            CRMEntities db = new CRMEntities();
            Supplier tempSupplier = new Supplier();
            tempSupplier.CompanyName = companyName;
            tempSupplier.ContactName = contactName.Length == 0 ? null : contactName;
            tempSupplier.ContactTitle = contactTitle.Length == 0 ? null : contactTitle;
            tempSupplier.City = city.Length == 0 ? null : city;
            tempSupplier.Country = country.Length == 0 ? null : country;
            tempSupplier.Phone = phone.Length == 0 ? null : phone;
            tempSupplier.Fax = fax.Length == 0 ? null : fax;
            db.Suppliers.Add(tempSupplier);
            db.SaveChanges();
            Exit();
        }
        public void Exit()
        {
            MainWindow.ChangeStatusBtns();
            TryClose();
        }
    }
}
