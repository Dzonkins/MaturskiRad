using Microsoft.Web.WebView2.Core;
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
    /// Interaction logic for DetaljiFakture.xaml
    /// </summary>
    public partial class DetaljiFakture : UserControl
    {
        private MainWindow _mainWindow;
        public DetaljiFakture(MainWindow mainWindow)
        {
            DataContext = new DetaljiFaktureViewModel();
            _mainWindow = mainWindow;
            InitializeComponent();
        }
    }
}
