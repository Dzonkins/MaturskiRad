﻿using System;
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

namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Prijava : UserControl
    {
        private MainWindow _mainWindow;

        public Prijava(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ShowIzborFirme();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
