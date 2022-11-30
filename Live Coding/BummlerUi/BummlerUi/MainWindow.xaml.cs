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

namespace BummlerUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler;

        public MainWindow()
        {
            InitializeComponent();

            bummler = new Bummler();
        }

        private async void btnTroedeln_Click(object sender, RoutedEventArgs e)
        {
            crcRed.Fill = Brushes.Red;
            lblTroedeln.Content = "";
            lblTroedeln.Content = await bummler.TroedelnAsync();
            crcRed.Fill = null;
        }

        private async void btnBummeln_Click(object sender, RoutedEventArgs e)
        {
            lblBummeln.Content = "";
            lblBummeln.Content = await bummler.BummelnAsync();
        }
    }
}
