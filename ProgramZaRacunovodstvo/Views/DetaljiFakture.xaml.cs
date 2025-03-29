using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DetaljiFakture.xaml
    /// </summary>
    public partial class DetaljiFakture : UserControl
    {
        private MainWindow _mainWindow;
        string tipfakture = string.Empty;

        public DetaljiFakture(MainWindow mainWindow)
        {
            tipfakture = Id.Instance.TipFakture;
            DataContext = new DetaljiFaktureViewModel();
            _mainWindow = mainWindow;
            mainWindow.Title = "Detalji fakture";
            InitializeComponent();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            if(tipfakture == "Nabavka")
            {
                _mainWindow.NavigateTo(new Views.Nabavke(_mainWindow));

            }
            else
            {
                _mainWindow.NavigateTo(new Views.Prodaja(_mainWindow));

            }
        }
    }
}
