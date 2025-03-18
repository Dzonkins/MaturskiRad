using Microsoft.Win32;
using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Wpf.Ui.Controls;
using System.Diagnostics;
using System.Collections;

namespace ProgramZaRacunovodstvo.Views
{
    /// <summary>
    /// Interaction logic for KreirajNabavku.xaml
    /// </summary>
    public partial class KreirajNabavku : UserControl
    {
        public ObservableCollection<Dokument> SelectedFiles { get; set; }
        private MainWindow _mainWindow;

        public KreirajNabavku(MainWindow mainWindow)
        {
            DataContext = new KreirajNabavkuViewModel();
            _mainWindow = mainWindow;
            InitializeComponent();
            SelectedFiles = new ObservableCollection<Dokument>();
        }

        private void DodajDokument(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Izaberite PDF dokumente"
            };

            if (dialog.ShowDialog() == true)
            {
                var filePaths = dialog.FileNames;
                ((KreirajNabavkuViewModel)DataContext).AddFilesCommand.Execute(filePaths);
            }
        }

        private async void DataGrid_promenjeneDimenzije(object sender, SizeChangedEventArgs e)
        {
            await Task.Delay(200);
            CollectionViewSource.GetDefaultView(StavkeDataGrid.ItemsSource)?.Refresh();
        }

        private void BrojCheck(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(\.[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new Views.Nabavke(_mainWindow));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void UkloniPlaceholder(object sender, SelectionChangedEventArgs e)
        {
            ComboboxTekst.Visibility = Visibility.Collapsed;
        }
    }
}
