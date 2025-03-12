using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ProgramZaRacunovodstvo.Views
{
    /// <summary>
    /// Interaction logic for DodajFirmu.xaml
    /// </summary>
    public partial class DodajFirmu : UserControl
    {

        private MainWindow _mainWindow;
        private readonly DatabaseKomande _database = new DatabaseKomande();

        public DodajFirmu(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Ime firme" || textBox.Text == "PIB" || textBox.Text == "Matični broj" || textBox.Text == "Grad" || textBox.Text == "Adresa sedišta firme" || textBox.Text == "Broj žiro računa" || textBox.Text == "Zastupnik"))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                textBox.Text = (string)textBox.Tag;

            }
        }

        private void BrojCheck(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            txtImeFirme.Text = "Ime firme";
            txtPIB.Text = "PIB";
            txtMaticni.Text = "Matični broj";
            txtGrad.Text = "Grad";
            txtAdresa.Text = "Adresa sedišta firme";
            txtGrad.Text = "Grad";
            txtBrojZiroRacuna.Text = "broj žiro računa";
            txtZastupnik.Text = "Zastupnik";
            txtImeFirme.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtPIB.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtMaticni.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtGrad.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtAdresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtBrojZiroRacuna.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtZastupnik.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            _mainWindow.ShowIzborFirme();
        }

        private void dodajFirmu(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtImeFirme.Text) || txtImeFirme.Text == "Ime firme" || string.IsNullOrEmpty(txtPIB.Text) || txtPIB.Text == "PIB" || string.IsNullOrEmpty(txtMaticni.Text) || txtMaticni.Text == "Matični broj" || string.IsNullOrEmpty(txtGrad.Text) || txtGrad.Text == "Grad" || string.IsNullOrEmpty(txtAdresa.Text) || txtAdresa.Text == "Adresa sedišta firme" || string.IsNullOrEmpty(txtBrojZiroRacuna.Text) || txtBrojZiroRacuna.Text == "Broj žiro računa" || string.IsNullOrEmpty(txtZastupnik.Text) || txtZastupnik.Text == "Zastupnik")
            {
                greska.Visibility = Visibility.Visible;
            }
            else {
                _database.DodajFirmu(txtImeFirme.Text, txtPIB.Text, txtMaticni.Text, txtAdresa.Text, txtGrad.Text, txtBrojZiroRacuna.Text, txtZastupnik.Text, _mainWindow.KorisnikId);
                greska.Visibility = Visibility.Collapsed;
                txtImeFirme.Text = "Ime firme";
                txtPIB.Text = "PIB";
                txtMaticni.Text = "Matični broj";
                txtGrad.Text = "Grad";
                txtAdresa.Text = "Adresa sedišta firme";
                txtGrad.Text = "Grad";
                txtBrojZiroRacuna.Text = "Broj žiro računa";
                txtZastupnik.Text = "Zastupnik";
                txtImeFirme.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtPIB.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtMaticni.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtGrad.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtAdresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtBrojZiroRacuna.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtZastupnik.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                _mainWindow.ShowIzborFirme();
            }
        }
    }
}
