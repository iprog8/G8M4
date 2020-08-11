using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestMvvmWithMorePages.Models;

namespace TestMvvmWithMorePages.ViewModels
{
    public class DisplaySuppliersViewModel: Screen
    {
        public DisplaySuppliersViewModel(ShellViewModel shellViewModel)
        {
            MainWindow = shellViewModel;
        }
        private ShellViewModel MainWindow { get; set; }
        public void Exit()
        {
            MainWindow.ChangeStatusBtns();
            TryClose();
        }
    }
}
