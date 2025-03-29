using ProgramZaRacunovodstvo.Services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ProgramZaRacunovodstvo
{
    public partial class Prijava : UserControl
    {
        private MainWindow _mainWindow;
        bool visibleText = false;
        private bool sifraFokus = false;
        private readonly DatabaseKomande _database = new DatabaseKomande();

        public Prijava(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            txtPasswordVisible.LostFocus += txtPasswordVisible_LostFocus;
            txtPasswordVisible.GotFocus += txtPasswordVisible_GotFocus;
            txtPassword.GotFocus += txtPassword_GotFocus;
            txtPassword.LostFocus += txtPassword_LostFocus;
        }

        public string? ime { get; set; }
        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            bool prijavljen = false;
            string upisanaLozinka = passwordVisibilty ? txtPasswordVisible.Text : txtPassword.Password;

            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "Email" || string.IsNullOrEmpty(upisanaLozinka))
            {
                greska.Visibility = Visibility.Visible;
                greska.Text = "Molimo vas popunite sva polja";
            }
            else
            {
                greska.Visibility = Visibility.Collapsed;

                prijavljen = _database.ProveraPrijava(txtEmail.Text, upisanaLozinka);

                if (prijavljen)
                {
                    
                    txtPassword.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                    txtPasswordVisible.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                    txtEmail.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                    _mainWindow.imeKorisnika = _database.NadjiIme(txtEmail.Text);
                    _mainWindow.KorisnikId = _database.NadjiID(txtEmail.Text);
                    Id.Instance.idkorisnik = _database.NadjiID(txtEmail.Text);
                    txtEmail.Text = "Email";
                    txtPassword.Password = "";
                    txtPasswordVisible.Text = "";
                    greska.Visibility = Visibility.Hidden;
                    _mainWindow.ShowIzborFirme();                    
                }
                else
                {
                    greska.Text = "Netačan email ili lozinka";
                    greska.Visibility = Visibility.Visible;

                }

            }
        }

        private void RegistrujSe(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowRegistracija();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Email" || textBox.Text == "Lozinka"))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = Visibility.Collapsed;
            sifraFokus = true;
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            sifraFokus = false;
            LozinkaPlaceholder();
        }

        private void txtPasswordVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPasswordPlaceholder.Visibility = Visibility.Collapsed;
            sifraFokus = true;
        }

        private void txtPasswordVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            sifraFokus = false;
            LozinkaPlaceholder();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                textBox.Text = textBox.Name.Remove(0, 3);
            }
        }
        bool passwordVisibilty = false;
        private void prikaziLozinku(object sender, RoutedEventArgs e)
        {
            visibleText = !visibleText;

            if (visibleText)
            {
                passwordVisibilty = true;
                txtPasswordVisible.Text = txtPassword.Password;
                txtPasswordVisible.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
                txtPasswordVisible.Focus();
            }
            else
            {
                passwordVisibilty = false;
                txtPassword.Password = txtPasswordVisible.Text;
                txtPasswordVisible.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Focus();
            }

            Dispatcher.Invoke(() =>
            {
                LozinkaPlaceholder();
            }, DispatcherPriority.Render);
        }

        private void LozinkaPlaceholder()
        {
            if (!sifraFokus && string.IsNullOrWhiteSpace(visibleText ? txtPasswordVisible.Text : txtPassword.Password))
            {
                txtPasswordPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                txtPasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }
    }
}