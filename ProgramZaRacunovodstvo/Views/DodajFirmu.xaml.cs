﻿using System;
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

        private void BrojZiroRacuna(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowIzborFirme();
        }
    }
}
