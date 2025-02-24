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

namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Prijava : UserControl
    {
        private MainWindow _mainWindow;
        bool visibleText = false;

        public Prijava(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            txtPasswordVisible.LostFocus += txtPasswordVisible_LostFocus;
        }



        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowIzborFirme();

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
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Password) && txtPasswordVisible.Visibility == Visibility.Collapsed)
            {
                txtPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void txtPasswordVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordVisible.Text) && txtPassword.Visibility == Visibility.Collapsed)
            {
                txtPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = textBox.Name.Remove(0, 3);
            }
        }
        private void prikaziLozinku(object sender, RoutedEventArgs e)
        {
            
            if (!visibleText) {
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

            if (string.IsNullOrWhiteSpace(txtPassword.Password) && string.IsNullOrWhiteSpace(txtPasswordVisible.Text))
            {
                txtPasswordPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                txtPasswordPlaceholder.Visibility = Visibility.Collapsed;
            }

            visibleText = !visibleText;
        }
    }
}
