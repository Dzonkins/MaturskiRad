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

namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prijava _prijava;
        private IzborFirme _IzborFirme;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Prijava";
            ShowOverlay(new Prijava(this));

            _prijava = new Prijava(this);
            _IzborFirme = new IzborFirme(this);
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
    }
}