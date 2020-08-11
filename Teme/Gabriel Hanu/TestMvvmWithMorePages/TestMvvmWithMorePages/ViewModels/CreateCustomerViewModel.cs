using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.ViewModels
{
    public class CreateCustomerViewModel: Screen
    {
        public CreateCustomerViewModel(ShellViewModel shellViewModel)
        {
            MainWindow = shellViewModel;
        }
        public ShellViewModel MainWindow { get; set; }
        private string _firstName;
        private string _lastName;
        private string _city;
        private string _country;
        private string _phone;
        private bool _canComplete = false;

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                if (value.Length < 40) _firstName = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length < 40) _lastName = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => LastName); 
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
                if(value.Length < 40) _country = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => Country);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value.Length < 20) _phone = MainWindow.ProcessNumber(value);
                NotifyOfPropertyChange(() => Phone);
            }
        }
        public bool CanComplete
        {
            get { return _canComplete; }
            set { _canComplete = value; NotifyOfPropertyChange(() => CanComplete); }
        }//After the user puts the first and second name, he can complete others fields

        public bool CanSubmit(string firstName, string lastName, string city, string country, string phone)
        {
            if(firstName.Length > 1 && lastName.Length > 1)
            {
                CanComplete = true;
                return true;
            }
            return false;
        }
        public void Submit(string firstName, string lastName, string city, string country, string phone)
        {
            CRMEntities db = new CRMEntities();
            Customer customer = new Customer();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.City = (city.Length == 0) ? null : city;
            customer.Country = (country.Length == 0) ? null : country;
            customer.Phone = (phone.Length == 0) ? null : phone;
            db.Customers.Add(customer);
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
