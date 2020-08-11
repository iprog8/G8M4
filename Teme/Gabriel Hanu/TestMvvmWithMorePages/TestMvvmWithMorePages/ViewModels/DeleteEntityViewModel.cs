using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.ViewModels
{
    public class DeleteEntityViewModel: Screen
    {
        public DeleteEntityViewModel(ShellViewModel shellViewModel, TypeOfTable typeOfTable)
        {
            MainWindow = shellViewModel;
            if(typeOfTable == TypeOfTable.Customer)
            {
                Customers = new CRMEntities().Customers;
                Title = "Sterge Client";
                SubTitle = "Introduceti id-ul clientului pe care vreti sa il stergeti";
            }
            else
            {
                Suppliers = new CRMEntities().Suppliers;
                Title = "Sterge Furnizor";
                SubTitle = "Introduceti id-ul furnizorului pe care vreti sa il stergeti";
            }
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public ShellViewModel MainWindow { get; set; }
        private string _errorMsg;
        private string  _idValue;
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set 
            {
                _errorMsg = value;
                NotifyOfPropertyChange(() => ErrorMsg);
            }
        }
        public string IdValue
        {
            get { return _idValue; }
            set 
            {
                _idValue = MainWindow.ProcessNumber(value);
                NotifyOfPropertyChange(() => IdValue);
            }
        }
        public bool CanDelete(string idValue)
        {
            if (!string.IsNullOrWhiteSpace(idValue))
            {
                if(int.TryParse(idValue, out int value))
                {
                    if(value > 0)
                    {
                        if(Customers != null)
                        {
                            if(Customers.Find(value) != null)
                            {
                                ErrorMsg = string.Empty;
                                return true;
                            }
                            ErrorMsg = "Id-ul pe care l-ai introdus este invalid!";
                            return false;
                        }
                        else
                        {
                            if(Suppliers.Find(value) != null)
                            {
                                ErrorMsg = string.Empty;
                                return true;
                            }
                            ErrorMsg = "Id-ul pe care l-ai introdus este invalid!";
                            return false;
                        }
                    }
                    ErrorMsg = "Id-ul introdus de tine este mai mic decat 1";
                    return false;
                }
                ErrorMsg = "Input-ul introdus de tine nu este un numar";
                return false;
            }
            return false;
        }
        public void Delete(string idValue)
        {
            CRMEntities db = new CRMEntities();
            int.TryParse(idValue, out int id);
            if(Customers != null)
            { 
                db.Customers.Remove(db.Customers.Find(id));
            }
            else
            {
                db.Suppliers.Remove(db.Suppliers.Find(id));
            }
            db.SaveChanges();
            Exit();
        }
        public void Exit()
        {
            MainWindow.ChangeStatusBtns();
            TryClose();
        }
    }
    public enum TypeOfTable
    {
        Customer,
        Supplier
    }
}
