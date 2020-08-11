using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmWithMorePages.ViewModels
{
    public class DisplayCustomersViewModel: Screen
    {
        public DisplayCustomersViewModel(ShellViewModel shellViewModel)
        {
            MainWindow = shellViewModel;
        }
        private ShellViewModel MainWindow { get; set; }
        public void Exit()
        {
            MainWindow.ChangeStatusBtns();
            this.TryClose();
        }
    }
}
