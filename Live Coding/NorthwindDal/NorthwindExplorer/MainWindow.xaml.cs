using NorthwindDal.Model;
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

namespace NorthwindExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindContext context = new NorthwindContext();

        public MainWindow()
        {
            InitializeComponent();

            // Länder der Kunden in die TreeView
            var qCountries = context.Customers.Select(cu => cu.Country).Distinct();

            foreach (string country in qCountries)
            {
                TreeViewItem tviCountry = new TreeViewItem() { Header = country };
                tviCountry.Items.Add(new TreeViewItem());
                tviCountry.Expanded += this.CountryNode_Expanded;
                trvCustomers.Items.Add(tviCountry);
            }
        }

        private void CountryNode_Expanded(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem tviCountry)
            {
                tviCountry.Items.Clear();
                string country = tviCountry.Header.ToString();

                var qCustomersOfCountry = context.Customers.Where(cu => cu.Country == country);

                foreach (Customer customer in qCustomersOfCountry)
                {
                    TreeViewItem tviCustomer = new TreeViewItem()
                    {
                        Header = customer.CompanyName,
                        Tag = customer.CustomerId
                    };
                    tviCustomer.Selected += this.Customer_Selected;
                    tviCountry.Items.Add(tviCustomer);
                }

            }
        }

        private void Customer_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem tviCustomer && tviCustomer.Tag != null)
            {
                string customerId = tviCustomer.Tag.ToString();
                var qOrdersOfCustomer = context.Orders.Where(od => od.CustomerId == customerId);

                cbxOrders.ItemsSource = qOrdersOfCustomer.ToList(); // Deferred Execution!
            }

        }

        private void cbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxOrders.SelectedItem is Order order)
            {
                var qOrderInfo = context.OrderDetails.Where(od => od.OrderId == order.Id)
                                                    .Select(od => new
                                                    {
                                                        od.Quantity,
                                                        od.Product.ProductName,
                                                        od.UnitPrice
                                                    });

                dgOrderInfo.ItemsSource = qOrderInfo.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (((TreeViewItem)trvCustomers.SelectedItem).Tag != null)
            {
                string customerId=((TreeViewItem)trvCustomers.SelectedItem).Tag?.ToString();
                Customer customer = context.Customers.Find(customerId);

                AddEditCustomer editCustomer = new AddEditCustomer(customer);

                if (editCustomer.ShowDialog() == true)
                {
                    context.SaveChanges();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer() { Country = "Germany" };

            AddEditCustomer addCustomer = new AddEditCustomer(customer);
            if (addCustomer.ShowDialog() == true)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
