using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ProgramZaRacunovodstvo.Views
{
    public partial class Registracija : UserControl
    {
        private MainWindow _mainWindow;
        bool visibleText = false;
        private bool sifraFokus = false;

        public Registracija(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            txtPasswordVisible.LostFocus += txtPasswordVisible_LostFocus;
            txtPasswordVisible.GotFocus += txtPasswordVisible_GotFocus;
            txtPassword.GotFocus += txtPassword_GotFocus;
            txtPassword.LostFocus += txtPassword_LostFocus;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Email" || textBox.Text == "JMBG" || textBox.Text == "Ime" || textBox.Text == "Prezime" || textBox.Text == "Grad" || textBox.Text == "Adresa"))
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

        private void Nazad(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "Ime";
            txtPrezime.Text = "Prezime";
            txtJMBG.Text = "JMBG";
            txtGrad.Text = "Grad";
            txtAdresa.Text = "Adresa";
            txtEmail.Text = "Email";
            txtPassword.Password = "";
            txtPasswordVisible.Text = "";
            txtIme.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtPrezime.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtJMBG.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtGrad.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtAdresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtEmail.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
            txtPassword.Visibility = Visibility.Visible;
            txtPasswordVisible.Visibility = Visibility.Collapsed;
            visibleText = false;

            txtPasswordPlaceholder.Visibility = Visibility.Visible;
            _mainWindow.ShowPrijava();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            visibleText = !visibleText;

            if (visibleText)
            {
                txtPasswordVisible.Text = txtPassword.Password;
                txtPasswordVisible.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
                txtPasswordVisible.Focus();
            }
            else
            {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "Email" || string.IsNullOrEmpty(txtPassword.Password))
            {
                greska.Visibility = Visibility.Visible;
                greska.Text = "Molimo vas popunite sva polja";
            }
            else
            {
                txtIme.Text = "Ime";
                txtPrezime.Text = "Prezime";
                txtJMBG.Text = "JMBG";
                txtGrad.Text = "Grad";
                txtAdresa.Text = "Adresa";
                txtEmail.Text = "Email";
                txtPassword.Password = "";
                txtPasswordVisible.Text = "";
                txtIme.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtPrezime.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtJMBG.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtGrad.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtAdresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtEmail.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF616161"));
                txtPassword.Visibility = Visibility.Visible;
                txtPasswordVisible.Visibility = Visibility.Collapsed;
                visibleText = false;

                txtPasswordPlaceholder.Visibility = Visibility.Visible;
                greska.Visibility = Visibility.Hidden;
                _mainWindow.ShowPrijava();
            }
        }
    }
}