using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace TestMvvmWithMorePages.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        private bool _btnIsEnabled = true;
        public bool BtnIsEnabled
        {
            get { return _btnIsEnabled; }
            set 
            {
                _btnIsEnabled = value;
                NotifyOfPropertyChange(() => BtnIsEnabled);
            }
        }
        protected internal void ChangeStatusBtns()
        {
            //var test = ConfigurationManager.AppSettings["title"];
            if (BtnIsEnabled)
                BtnIsEnabled = false;
            else
                BtnIsEnabled = true;
        }
        /// <summary>
        /// It takes the value that the user type, and correct it(the value has to be clean, no numbers involved, no special characters(no included))
        /// </summary>
        /// <param name="value">the value that the user typed</param>
        /// <returns>return the modified text if needed</returns>
        protected internal string ProcessText(string value)
        {
            if (char.IsNumber(value.LastOrDefault()))//verify if the last character is a number
                return value.Remove(value.Length - 1);//if it is return the string without it
            else if (!char.IsUpper(value.FirstOrDefault()) && value.Length > 0)//verify if the first letter is upper Case
                return value.FirstOrDefault().ToString().ToUpper() + value.Substring(1);//if not make it upper
            else//otherwise
                return value;//return the normal value
        }
        protected internal string ProcessNumber(string value)
        {
            if (value.All(char.IsDigit))  
                return value;
            else 
                return value.Remove(value.Length - 1);
        }
        public void DisplayClients()
        {
            ChangeStatusBtns();
            ActivateItem(new DisplayCustomersViewModel(this));
        }
        public void AddClient()
        {
            ChangeStatusBtns();
            ActivateItem(new CreateCustomerViewModel(this));
        }
        public void AddSupplier()
        {
            ChangeStatusBtns();
            ActivateItem(new CreateSupplierViewModel(this));
        }
        public void DisplaySuppliers() 
        {
            ChangeStatusBtns();
            ActivateItem(new DisplaySuppliersViewModel(this));
        }
        public void ModifyClient()
        {
            ChangeStatusBtns();
            ActivateItem(new ModifyClientViewModel(this));
        }
        public void ModifySupplier()
        {
            ChangeStatusBtns();
            ActivateItem(new ModifySupplierViewModel(this));
        }
        public void DeleteClient()
        {
            ChangeStatusBtns();
            ActivateItem(new DeleteEntityViewModel(this,TypeOfTable.Customer));
        }
        public void DeleteSupplier()
        {
            ChangeStatusBtns();
            ActivateItem(new DeleteEntityViewModel(this, TypeOfTable.Supplier));
        }
    }
}
