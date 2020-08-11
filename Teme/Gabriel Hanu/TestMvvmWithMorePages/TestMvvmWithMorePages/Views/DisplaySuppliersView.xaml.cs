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
    /// Interaction logic for DisplaySuppliersView.xaml
    /// </summary>
    public partial class DisplaySuppliersView : UserControl
    {
        public DisplaySuppliersView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CRMEntities db = new CRMEntities();
            var suppliers = db.Suppliers.Include(s => s.Products).ToList();
            foreach (var supplier in suppliers)
            {
                var item = new TreeViewItem();
                var subItem = new TreeViewItem();
                item.Header = $"Supplier-ul cu id-ul: {supplier.Id}";
                item.Items.Add($"Numele companiei {supplier.CompanyName}");
                item.Items.Add($"Nume de contact: {supplier.ContactName}");
                item.Items.Add($"Titlu de contact: {supplier.ContactTitle}");
                item.Items.Add($"Orasul: {supplier.City}");
                item.Items.Add($"Tara: {supplier.Country}");
                item.Items.Add($"Numarul de telefon: {supplier.Phone}");
                item.Items.Add($"Fax: {supplier.Fax}");
                subItem.Header = $"Numar produse: {supplier.Products.Count}";
                foreach (var product in supplier.Products)
                {
                    var subI = new TreeViewItem();
                    subI.Header = $"Id-ul produsului: {product.Id}";
                    subI.Items.Add($"Numele produsului: {product.ProductName}");
                    subI.Items.Add($"Pretul: {product.UnitPrice}");
                    subI.Items.Add($"Este in stock: {(product.IsDiscontinued == false ? "Nu" : "Da")}");
                    subItem.Items.Add(subI);
                }
                item.Items.Add(subItem);
                SuppliersView.Items.Add(item);
            }
        }
    }
}
