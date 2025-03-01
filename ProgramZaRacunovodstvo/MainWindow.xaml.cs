using ProgramZaRacunovodstvo.Views;
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
        private Prijava _prijava;
        private IzborFirme _IzborFirme;
        private Registracija _registracija;
        private DodajFirmu _dodajFirmu;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Prijava";
            ShowOverlay(new Prijava(this));

            _prijava = new Prijava(this);
            _IzborFirme = new IzborFirme(this);
            _registracija = new Registracija(this);
            _dodajFirmu = new DodajFirmu(this);
        }

        public void ShowPrijava()
        {
            ShowOverlay(_prijava);
            this.Title = "Prijava";
        }

        public void ShowIzborFirme()
        {
            ShowOverlay(_IzborFirme);
            this.Title = "Izbor Firme";
        }

        public void ShowRegistracija()
        {
            ShowOverlay(_registracija);
            this.Title = "Resgistracija";
        }

        public void ShowDodajFirmu()
        {
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
                        NavigateTo(new GlavnaStrana());
                        break;
                   case "Nabavke":
                        this.Title = "Nabavke";
                        NavigateTo(new Nabavke());
                        break;
                    case "Prodaja":
                        NavigateTo(new Views.Prodaja());
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