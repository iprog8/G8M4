using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestMvvmWithMorePages.Models;
using System.Data.Entity;

namespace TestMvvmWithMorePages.Views
{
    /// <summary>
    /// Interaction logic for DisplayCustomersView.xaml
    /// </summary>
    public partial class DisplayCustomersView : UserControl
    {
        public DisplayCustomersView()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CRMEntities db = new CRMEntities();
            var customers = db.Customers.Include(c => c.Orders).ToList();
            foreach (var customer in customers)
            {
                var item = new TreeViewItem();
                var subItem = new TreeViewItem();
                item.Header = $"Clientul cu id-ul: {customer.Id}";
                item.Items.Add($"Prenume: {customer.FirstName}");
                item.Items.Add($"Nume: {customer.LastName}");
                item.Items.Add($"Oras: {customer.City}");
                item.Items.Add($"Tara: {customer.Country}");
                item.Items.Add($"Numar de telefon: {customer.Phone}");
                subItem.Header = $"Numar comenzi {customer.Orders.Count}";
                foreach (var order in customer.Orders)
                {
                    var subI = new TreeViewItem();
                    subI.Header = $"Comanda cu id-ul: {order.Id}";
                    subI.Items.Add($"Data comenzii: {order.OrderDate}");
                    subI.Items.Add($"Numar produse: {order.OrderItems.Count}");
                    subI.Items.Add($"Suma totala: {order.TotalAmount}");
                    subItem.Items.Add(subI);
                }
                item.Items.Add(subItem);
                CustomersView.Items.Add(item);
            }
        }
    }
}
