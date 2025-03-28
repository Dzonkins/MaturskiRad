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
    /// Interaction logic for Izvodi.xaml
    /// </summary>
    public partial class Izvodi : UserControl
    {
        public Izvodi()
        {
            DataContext = new IzvodiViewModel();
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
            if (DataContext is IzvodiViewModel viewModel && IzvodiDataGrid.ActualHeight > 0)
            {
                double rowHeight = 50;
                double headerHeight = 41;
                int novBrojStavki = (int)((IzvodiDataGrid.ActualHeight - headerHeight) / rowHeight);

                if (viewModel.stavkiPoStranici != novBrojStavki)
                {
                    viewModel.stavkiPoStranici = novBrojStavki;

                    Dispatcher.Invoke(() =>
                    {
                        CollectionViewSource.GetDefaultView(IzvodiDataGrid.ItemsSource)?.Refresh();
                    });
                }


            }
        }
    }
}
