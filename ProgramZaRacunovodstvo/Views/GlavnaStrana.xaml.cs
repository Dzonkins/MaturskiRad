using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProgramZaRacunovodstvo.ViewModel
{
    /// <summary>
    /// Interaction logic for GlavnaStrana.xaml
    /// </summary>
    public partial class GlavnaStrana : UserControl
    {

        private MainWindow _mainWindow;


        public GlavnaStrana(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            //coment
            Naslovi();
        }

        private void Naslovi()
        {

            Stanje.Text = "Trenutno stanje za " + DateTime.Now.ToString("MMMM");
            Ulazne.Text = "Ulazne fakture u " + DateTime.Now.ToString("MMMM") + "u";
            Izlazne.Text = "Izlazne fakture u " + DateTime.Now.ToString("MMMM") + "u";
            Firma.Text = "Dobrodošli " + _mainWindow.SelectedFirma;

        }
    }
}
