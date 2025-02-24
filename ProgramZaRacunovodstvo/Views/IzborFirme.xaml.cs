using ProgramZaRacunovodstvo.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for GlavnaStrana.xaml
    /// </summary>
    public partial class IzborFirme : UserControl
    {

        private MainWindow _mainWindow;

        public IzborFirme(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            UcitajFirme();

        }

        private void Otvorifirmu()
        {
            _mainWindow.OverlayContainer.Visibility = Visibility.Collapsed;
            _mainWindow.MainLayout.Visibility = Visibility.Visible;
            _mainWindow.Title = "Početna";
            _mainWindow.NavigateTo(new GlavnaStrana());

            var pocetnaButton = MainWindow.nadjiSveElemente<Button>(_mainWindow)
                              .FirstOrDefault(b => b.Tag as string == "Pocetna");

            if (pocetnaButton != null)
            {
                _mainWindow.Navigacija(pocetnaButton, new RoutedEventArgs());
            }

        }



        private void UcitajFirme()
        {
            List<string> firme = IzvuciFirmeIzBaze();

            FirmaPanel.Children.Clear();

            foreach (string firma in firme)
            {
                Button btn = KreirajDugme(firma);
                btn.Click += (s, e) => Otvorifirmu();
                FirmaPanel.Children.Add(btn);
            }

            int rowCount = (firme.Count + 1) / 2;
            FirmaPanel.Rows = rowCount > 4 ? 4 : rowCount;
        }

        private Wpf.Ui.Controls.Button KreirajDugme(string content)
        {
            var button = new Wpf.Ui.Controls.Button
            {
                Content = content,
                Width = 470,
                Height = 70,
                FontSize = 30,
                Margin = new Thickness(10),
                CornerRadius = new CornerRadius(15),
                Background = new SolidColorBrush(Colors.White),
                BorderThickness = new Thickness(0),
                Foreground = new SolidColorBrush(Colors.Black),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            button.Effect = new DropShadowEffect
            {
                ShadowDepth = 10,
                Direction = 320,
                Color = Colors.Gray,
                Opacity = 0.5,
                BlurRadius = 30
            };

            button.Content = new TextBlock
            {
                Text = content,
                FontSize = 30,
                FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Poppins Light"),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            return button;
        }


        private List<string> IzvuciFirmeIzBaze()
        {
            return new List<string> { "Firma A", "Firma B", "Firma C", "Firma D", "Firma E", "Firma F", "Firma G", "Firma H" };
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowPrijava();

        }
    }
}
