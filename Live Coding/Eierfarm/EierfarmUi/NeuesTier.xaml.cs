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
using System.Windows.Shapes;

namespace EierfarmUi
{
    /// <summary>
    /// Interaction logic for NeuesTier.xaml
    /// </summary>
    public partial class NeuesTier : Window
    {
        public NeuesTier()
        {
            InitializeComponent();

            this.DataContext = this; // Basis aller Bindungsausdrücke, wenn nichts anderes angegeben
        }

        public string AnimalName { get; set; }
        public string AnimalType { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radChicken.IsChecked == true)
            {
                this.AnimalType = "Chicken";
            }
            else if (radGoose.IsChecked == true)
            {
                this.AnimalType = "Goose";
            }
            else
            {
                this.AnimalType = "Platypus";
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
