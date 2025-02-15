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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.OverlayContainer.Visibility = Visibility.Collapsed;
            _mainWindow.MainLayout.Visibility = Visibility.Visible;
            _mainWindow.Title = "Početna";
            _mainWindow.NavigateTo(new GlavnaStrana());

        }
    }
}
