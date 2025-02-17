using ProgramZaRacunovodstvo.ViewModel;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.OverlayContainer.Visibility = Visibility.Collapsed;
            _mainWindow.MainLayout.Visibility = Visibility.Visible;
            _mainWindow.Title = "Početna";
            _mainWindow.NavigateTo(new GlavnaStrana());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowPrijava();
        }

        private void UcitajFirme()
        {
            List<string> firme = IzvuciFirmeIzBaze();

            FirmaPanel.Children.Clear();

            foreach (string firma in firme)
            {
                Button btn = KreirajDugme(firma);
                btn.Click += (s, e) => OpenCompany(firma);
                FirmaPanel.Children.Add(btn);
            }

            int rowCount = (firme.Count + 1) / 2;
            FirmaPanel.Rows = rowCount > 4 ? 4 : rowCount;
        }

        private Button KreirajDugme(string content)
        {
            Button button = new Button
            {
                Content = content,
                Width = 470,
                Height = 70,
                Background = Brushes.White,
                BorderThickness = new Thickness(0),
                FontFamily = new FontFamily("pack://application:,,,/Fonts/#Poppins Light"),
                FontSize = 30,
                Margin = new Thickness(10, 10, 10, 10),
                Effect = new DropShadowEffect
                {
                    ShadowDepth = 10,
                    Direction = 320,
                    Color = Colors.Gray,
                    Opacity = 0.5,
                    BlurRadius = 30
                }
            };

            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));
            border.SetValue(Border.PaddingProperty, new Thickness(10));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            border.AppendChild(contentPresenter);

            button.Template = new ControlTemplate(typeof(Button))
            {
                VisualTree = border
            };


            return button;
        }

        private List<string> IzvuciFirmeIzBaze()
        {
            return new List<string> { "Firma A", "Firma B", "Firma C", "Firma D", "Firma E", "Firma F", "Firma G", "Firma H" };
        }

        private void OpenCompany(string imeFirme)
        {
            MessageBox.Show($"Otvaram firmu: {imeFirme}");
        }
    }
}
