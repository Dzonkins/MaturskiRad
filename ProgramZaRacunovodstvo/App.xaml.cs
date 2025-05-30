﻿using PdfSharp.Fonts;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProgramZaRacunovodstvo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            var dbInitializer = new DatabaseInitialize();
            dbInitializer.InitializeDatabase();
            base.OnStartup(e);
        }
    }

}
