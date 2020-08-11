using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.ViewModels
{
    public class ModifyClientViewModel: Screen
    {
        public ModifyClientViewModel(ShellViewModel shellViewModel)
        {
            MainWindow = shellViewModel;
            customerManager = new CustomerManager();
            ClientProps = new BindableCollection<string>(customerManager.GetProps());
        }

        private BindableCollection<string> _clientProps;
        private string _valueToChange;
        private string _idValue;
        private string _selectedProp;
        private string _statusId;
        private bool _isIdValid = false;
        public BindableCollection<string> ClientProps
        {
            get { return _clientProps; }
            set { _clientProps = value; NotifyOfPropertyChange(() => ClientProps); }
        }
        private  CustomerManager customerManager { get; set; }
        private ShellViewModel MainWindow { get; set; }
        public bool IsIdValid
        {
            get { return _isIdValid; }
            set { _isIdValid = value; NotifyOfPropertyChange(() => IsIdValid); }
        }
        public string StatusId
        {
            get { return _statusId; }
            set { _statusId = value; NotifyOfPropertyChange(() => StatusId); }
        }
        public string SelectedProp
        {
            get { return _selectedProp; }
            set { if(value != null) _selectedProp = value.ToString().Split(':')[0]; NotifyOfPropertyChange(() => SelectedProp); }
        }
        public string ValueToChange
        {
            get { return _valueToChange; }
            set 
            {
                if (SelectedProp == "Numar de telefon") _valueToChange = MainWindow.ProcessNumber(value);
                else _valueToChange = MainWindow.ProcessText(value);
                NotifyOfPropertyChange(() => ValueToChange); }
        }
        public string IdValue
        {
            get { return _idValue; }
            set 
            {
                _idValue = MainWindow.ProcessNumber(value);
                if (!string.IsNullOrWhiteSpace(_idValue))
                {
                    if(int.TryParse(_idValue, out int id))
                    {
                        if(id > 0)
                        {
                            Customer toBeVerified = new CRMEntities().Customers.Find(id);
                            if(toBeVerified != null)
                            {
                                customerManager.GetNew(toBeVerified);
                                ClientProps = new BindableCollection<string>(customerManager.GetProps());
                                IsIdValid = true;
                                StatusId = "Id-ul este bun! Acum puteti modifica proprietatile";
                            }
                            else
                                OutputNone();
                        }
                        else
                            OutputNone();
                    }
                    else
                        OutputNone();
                }
                else
                    OutputNone();
                NotifyOfPropertyChange(() => IdValue);
            }
        }
        public bool CanModify(string valueToChange)
        {
            if (valueToChange.Length > 1 && SelectedProp != null) return true;
            return false;
        }
        public void Modify(string valueToChange)
        {
            customerManager.Update(SelectedProp, valueToChange, int.Parse(IdValue));
            ValueToChange = string.Empty;
            SelectedProp = string.Empty;
            IdValue = IdValue;
        }
        public void Exit()
        {
            MainWindow.ChangeStatusBtns();
            TryClose();
        }
        private void OutputNone()
        {
            IsIdValid = false;
            StatusId = string.Empty;
        }
    }
}
