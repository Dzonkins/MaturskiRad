using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgramZaRacunovodstvo.Services
{
    class Navigation
    {
        private static Navigation? _instance;
        public static Navigation Instance => _instance ??= new Navigation();

        private MainWindow? _mainWindow;

        public void Initialize(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void NavigateTo(UserControl page)
        {
            _mainWindow?.NavigateTo(page);
        }

        public MainWindow GetMainWindow()
        {
            return _mainWindow ?? throw new InvalidOperationException("Navigation is not initialized with a MainWindow instance.");
        }
    }
}
