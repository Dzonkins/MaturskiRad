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
    /// Interaction logic for OFirmi.xaml
    /// </summary>
    public partial class OFirmi : UserControl
    {
        private MainWindow _mainWindow;

        public OFirmi(MainWindow mainWindow)
        {
            DataContext = new OFirmiViewModel();
            _mainWindow = mainWindow;
            InitializeComponent();
        }
    }
}
