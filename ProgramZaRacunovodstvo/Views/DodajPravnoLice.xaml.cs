using System;
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
    /// Interaction logic for DodajPravnoLice.xaml
    /// </summary>
    public partial class DodajPravnoLice : UserControl
    {
        private MainWindow _mainWindow;

        public DodajPravnoLice(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new Views.PravnaLica(_mainWindow));
        }

        private void BrojCheck(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(\.[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
