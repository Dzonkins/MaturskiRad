using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KreirajProdaju.xaml
    /// </summary>
    public partial class KreirajProdaju : UserControl
    {
        public ObservableCollection<Dokument> SelectedFiles { get; set; }
        private MainWindow _mainWindow;
        public KreirajProdaju(MainWindow mainWindow)
        {
            DataContext = new KreirajProdajuViewModel();
            _mainWindow = mainWindow;
            mainWindow.Title = "Kreiraj prodaju";
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
                ((KreirajProdajuViewModel)DataContext).AddFilesCommand.Execute(filePaths);
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



        private void ScrollCheck(object sender, MouseWheelEventArgs e)
        {
            if (sender is System.Windows.Controls.DataGrid dataGrid)
            {
                var scrollViewer = FindVisualChild<ScrollViewer>(dataGrid);

                if (scrollViewer != null)
                {
                    bool canScrollUp = e.Delta > 0 && scrollViewer.VerticalOffset > 0;
                    bool canScrollDown = e.Delta < 0 && scrollViewer.VerticalOffset < scrollViewer.ScrollableHeight;

                    if (canScrollUp || canScrollDown)
                    {
                        scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                    return typedChild;

                var subChild = FindVisualChild<T>(child);
                if (subChild != null)
                    return subChild;
            }
            return null!;
        }

        private void UkloniPlaceholder(object sender, SelectionChangedEventArgs e)
        {
            ComboboxTekst.Visibility = Visibility.Collapsed;
        }
    }
}
