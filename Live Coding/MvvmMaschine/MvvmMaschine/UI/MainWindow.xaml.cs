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

namespace MvvmMaschine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TennisballWurfmaschine wurfmaschine = null;
        public MainWindow()
        {
            InitializeComponent();

            wurfmaschine = new TennisballWurfmaschine();
            this.DataContext = wurfmaschine;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            wurfmaschine.Start();
        }

        private void btnStopp_Click(object sender, RoutedEventArgs e)
        {
            wurfmaschine.Stopp();
        }
    }
}
