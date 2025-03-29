using ProgramZaRacunovodstvo.ViewModels;
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

namespace ProgramZaRacunovodstvo.Views
{
    /// <summary>
    /// Interaction logic for PravnaLica.xaml
    /// </summary>
    public partial class PravnaLica : UserControl
    {
        private MainWindow _mainWindow;

        public PravnaLica(MainWindow mainWindow)
        {
            DataContext = new PravnaLicaViewModel();
            _mainWindow = mainWindow;
            mainWindow.Title = "Pravna lica";
            InitializeComponent();
        }

        private void DataGrid_Ucitano(object sender, RoutedEventArgs e)
        {
            IzmeniBrojStavki();
        }

        private async void DataGrid_promenjeneDimenzije(object sender, SizeChangedEventArgs e)
        {
            await Task.Delay(200);
            Dispatcher.Invoke(IzmeniBrojStavki);
        }

        private void IzmeniBrojStavki()
        {
            if (DataContext is PravnaLicaViewModel viewModel && PravnaLicaDataGrid.ActualHeight > 0)
            {
                double rowHeight = 50;
                double headerHeight = 41;
                int novBrojStavki = (int)((PravnaLicaDataGrid.ActualHeight - headerHeight) / rowHeight);

                if (viewModel.stavkiPoStranici != novBrojStavki)
                {
                    viewModel.stavkiPoStranici = novBrojStavki;

                    Dispatcher.Invoke(() =>
                    {
                        CollectionViewSource.GetDefaultView(PravnaLicaDataGrid.ItemsSource)?.Refresh();
                    });
                }


            }
        }

        private void DodajPravnoLice(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new Views.DodajPravnoLice(_mainWindow));
        }
    }
}
