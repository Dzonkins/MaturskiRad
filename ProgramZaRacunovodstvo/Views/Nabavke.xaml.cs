using ProgramZaRacunovodstvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Nabavke.xaml
    /// </summary>
    public partial class Nabavke : UserControl
    {
        private MainWindow _mainWindow;

        public Nabavke(MainWindow mainWindow)
        {
            DataContext = new NabavkeViewModel();
            mainWindow.Title = "Nabavke";
            _mainWindow = mainWindow;
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
            if (DataContext is NabavkeViewModel viewModel && NabavkeDataGrid.ActualHeight > 0)
            {
                double rowHeight = 50;
                double headerHeight = 41;
                int novBrojStavki = (int)((NabavkeDataGrid.ActualHeight - headerHeight) / rowHeight);

                if (viewModel.stavkiPoStranici != novBrojStavki)
                {
                    viewModel.stavkiPoStranici = novBrojStavki;

                    Dispatcher.Invoke(() =>
                    {
                        CollectionViewSource.GetDefaultView(NabavkeDataGrid.ItemsSource)?.Refresh();
                    });
                }


            }
        }

        private void KreirajNabavku(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new Views.KreirajNabavku(_mainWindow));
        }
    }
}
