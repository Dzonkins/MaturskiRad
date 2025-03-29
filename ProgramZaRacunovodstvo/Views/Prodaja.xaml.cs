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
    /// Interaction logic for Prodaja.xaml
    /// </summary>
    public partial class Prodaja : UserControl
    {
        private MainWindow _mainWindow;

        public Prodaja(MainWindow mainWindow)
        {
            DataContext = new ProdajaViewModel();
            _mainWindow = mainWindow;
            mainWindow.Title = "Prodaja";
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
            if (DataContext is ProdajaViewModel viewModel && ProdajaDataGrid.ActualHeight > 0)
            {
                double rowHeight = 50;
                double headerHeight = 41;
                int novBrojStavki = (int)((ProdajaDataGrid.ActualHeight - headerHeight) / rowHeight);

                if (viewModel.stavkiPoStranici != novBrojStavki)
                {
                    viewModel.stavkiPoStranici = novBrojStavki;

                    Dispatcher.Invoke(() =>
                    {
                        CollectionViewSource.GetDefaultView(ProdajaDataGrid.ItemsSource)?.Refresh();
                    });
                }


            }
        }

        private void KreirajProdaju(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new Views.KreirajProdaju(_mainWindow));
        }
    }
}
