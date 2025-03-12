﻿using ProgramZaRacunovodstvo.Views;
using ProgramZaRacunovodstvo.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prijava? _prijava;
        private IzborFirme? _IzborFirme;
        private Registracija? _registracija;
        private DodajFirmu? _dodajFirmu;

        public string? SelectedFirma { get; set; }
        public int KorisnikId { get; set; }
        public int FirmaId { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Prijava";
            ShowOverlay(new Prijava(this));


        }

        public void ShowPrijava()
        {
            _prijava = new Prijava(this);
            ShowOverlay(_prijava);
            this.Title = "Prijava";
        }

        public void ShowIzborFirme(string? ime = null)
        {
            _IzborFirme = new IzborFirme(this);
            ShowOverlay(_IzborFirme);
            this.Title = "Izbor Firme";
            MainContent.Content = new IzborFirme(this, ime);
        }

        public void ShowRegistracija()
        {
            _registracija = new Registracija(this);
            ShowOverlay(_registracija);
            this.Title = "Resgistracija";
        }

        public void ShowDodajFirmu()
        {
            _dodajFirmu = new DodajFirmu(this);
            ShowOverlay(_dodajFirmu);
            this.Title = "Dodaj firmu";
        }

        public void ShowOverlay(UserControl control)
        {
            OverlayContent.Content = control;
            OverlayContainer.Visibility = Visibility.Visible;
        }

        public void HideOverlay()
        {
            OverlayContainer.Visibility = Visibility.Collapsed;
            OverlayContent.Content = null;
        }

        private Button? _selectedButton;

        public void Navigacija(object sender, RoutedEventArgs? e)
        {



            if (sender is Button btn && btn.Tag is string controlName)
            {
                if (_selectedButton != null)
                {
                    _selectedButton.ClearValue(Button.BackgroundProperty);
                    _selectedButton.ClearValue(Button.BorderBrushProperty);
                }

                btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B4FFF"));
                btn.BorderBrush = Brushes.White;
                _selectedButton = btn;

                switch (controlName)
                {
                    case "Pocetna":
                        this.Title = "Početna";
                        NavigateTo(new GlavnaStrana(this));
                        break;
                   case "Nabavke":
                        this.Title = "Nabavke";
                        NavigateTo(new Nabavke(this));
                        break;
                    case "Prodaja":
                        NavigateTo(new Views.Prodaja());
                        break;
                    case "Izvodi":
                        NavigateTo(new Views.Izvodi());
                        break;
                    case "Pravna lica":
                        NavigateTo(new Views.PravnaLica());
                        break;
                    case "IzlogujSe":
                        OverlayContainer.Visibility = Visibility.Visible;
                        MainLayout.Visibility = Visibility.Collapsed;
                        KorisnikId = -1;
                        Title = "Prijava";
                        ShowPrijava();
                        break;
                }
            }
        }

        public static IEnumerable<T> nadjiSveElemente<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T tChild)
                    {
                        yield return tChild;
                    }

                    foreach (T childOfChild in nadjiSveElemente<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public void NavigateTo(UserControl control)
        {
            MainContent.Content = control;
        }
    }
}