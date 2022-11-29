using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using EierfarmBl;
using Microsoft.Win32;

namespace EierfarmUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml - "Code behind"-Datei
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Chicken chicken = new Chicken("Neues Huhn");

            cbxTiere.Items.Add(chicken);
            cbxTiere.SelectedItem = chicken;
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            //Chicken chicken = (Chicken)cbxTiere.SelectedItem; // löst Exception aus, wenn SelectedItem kein Chicken
            Chicken chicken = cbxTiere.SelectedItem as Chicken; // Safe Cast - liefert null, wenn  SelectedItem kein Chicken
            if (chicken != null)
                chicken.Eat();
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is IEggProducer animal) // Wenn Cast möglich, ist chicken != null
            {
                animal.LayEgg();
            }
        }

        private void btnNeuesTier_Click(object sender, RoutedEventArgs e)
        {
            NeuesTier dlgNeuesTier = new NeuesTier();

            IEggProducer animal = null;

            if (dlgNeuesTier.ShowDialog() == true)
            {
                switch (dlgNeuesTier.AnimalType)
                {
                    case "Chicken":
                        animal = new Chicken(dlgNeuesTier.AnimalName);
                        break;
                    case "Goose":
                        animal = new Goose(dlgNeuesTier.AnimalName);
                        break;
                    default:
                        animal = new Platypus() { Name = dlgNeuesTier.AnimalName, Weight = 2000 };
                        break;
                }

                cbxTiere.Items.Add(animal);
                cbxTiere.SelectedItem = animal;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlgSaveFileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Filter = "Chicken|*.chk|Goose|*.gos|Platypus|*.plt",
                FilterIndex = 3
            };

            if (dlgSaveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(dlgSaveFileDialog.FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(cbxTiere.SelectedItem.GetType());
                    serializer.Serialize(writer, cbxTiere.SelectedItem);
                }
            }
        }
    }
}
