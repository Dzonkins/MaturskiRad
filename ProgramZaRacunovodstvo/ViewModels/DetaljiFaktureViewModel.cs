using Microsoft.Win32;
using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Input;
using System.Windows;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class DetaljiFaktureViewModel
    {

        private string _brojFakture = string.Empty;
        private string _datumSlanja = string.Empty;
        private string _dobavljac = string.Empty;
        private string _tipFakture = string.Empty;
        private string _statusFakture = string.Empty;
        private string _kupac = string.Empty;
        private string _iznos = string.Empty;
        private bool _placeno;
        private string? _pdfUrl;

        private string? _tempFilePath;
        public ObservableCollection<FajlFakture> Fajlovi { get; set; } = new();
        public ICommand Sacuvaj { get; }
        public ICommand Checkbox { get; }
        public ICommand PreuzmiFakturuCommand { get; }


        public int id { get; set; }
        private readonly DatabaseKomande _database = new DatabaseKomande();

        public string? PdfUrl
        {
            get => _pdfUrl;
            set
            {
                _pdfUrl = value;
                OnPropertyChanged(nameof(PdfUrl));
            }
        }

        public string TipFakture
        {
            get => _tipFakture;
            set => _tipFakture = value;
        }
        public string Status
        {
            get => _statusFakture;
            set => _statusFakture = value;
        }

        public bool Placeno
        {
            get => _placeno;
            set
            {
                if (_placeno != value)
                {
                    _placeno = value;
                }
            }
        }

        public string BrojFakture
        {
            get => _brojFakture;
            set
            {
                _brojFakture = value;
            }
        }

        public string DatumSlanja
        {
            get => _datumSlanja;
            set
            {
                _datumSlanja = value;
            }
        }

        public string Iznos
        {
            get => _iznos;
            set
            {
                _iznos = value;
            }
        }

        public string Dobavljac
        {
            get => _dobavljac;
            set
            {
                _dobavljac = value;
            }
        }

        public string Kupac
        {
            get => _kupac;
            set
            {
                _kupac = value;
            }
        }

        public DetaljiFaktureViewModel()
        {
            id = Id.Instance.FakturaId;
            PovuciPodatke();
            Sacuvaj = new RelayCommand<FajlFakture>(SacuvajDokument);
            Checkbox = new RelayCommand<bool?>(CheckboxPromenjen);
            PreuzmiFakturuCommand = new RelayCommand(PreuzmiFakturu, CanPreuzmiFakturu);

        }

        private void CheckboxPromenjen(bool? isChecked)
        {
            if (isChecked == true)
            {
                Status = "Plaćeno";
            }
            else
            {
                Status = "Neplaćeno";
            }
            _database.AzurirajStatus(id, Status);
        }

        private void PovuciPodatke()
        {
            var faktura = _database.PodaciOFakturi(id);

            if (faktura != null)
            {
                BrojFakture = faktura.BrojFakture;
                TipFakture = faktura.TipFakture;
                Status = faktura.StatusFakture;
                Iznos = $"{faktura.Ukupno:N2} RSD";
                Dobavljac = faktura.Dobavljac;
                Kupac = faktura.Kupac;
                DatumSlanja = faktura.Datum?.ToString("dd.MM.yyyy.") ?? "N/A";
                Fajlovi.Clear();
                foreach (var file in faktura.Fajlovi)
                {
                    Fajlovi.Add(file);
                }
                PdfWebView(faktura.Fajl);
                if (Status == "Plaćeno")
                {
                    Placeno = true;
                }else
                {
                    Placeno = false;
                }
            }
            else
            {
                BrojFakture = "N/A";
                TipFakture = "N/A";
                Status = "N/A";
                Iznos = "0.00 RSD";
                Dobavljac = "N/A";
                Kupac = "N/A";
                DatumSlanja = "N/A";
            }
        }

        private void SacuvajDokument(FajlFakture? fajl)
        {
            if (fajl == null)
            {
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                FileName = fajl.NazivFajla,
                Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
            };

            if (saveDialog.ShowDialog() == true)
            {
                File.WriteAllBytes(saveDialog.FileName, fajl.Fajl);
            }
        }


        private void PreuzmiFakturu(object parameter)
        {
            if (string.IsNullOrEmpty(_tempFilePath) || !File.Exists(_tempFilePath))
            {
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                FileName = "Faktura " + BrojFakture +".pdf",
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save PDF"
            };

            if (saveDialog.ShowDialog() == true)
            {
                File.Copy(_tempFilePath, saveDialog.FileName, true);
            }
        }

        private bool CanPreuzmiFakturu(object parameter)
        {
            return !string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath);
        }


        private void PdfWebView(byte[]? pdfData)
        {
            if (pdfData == null)
            {
                PdfUrl = null;
                return;
            }

            try
            {
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string tempFolderPath = System.IO.Path.Combine(appDirectory, "Temp");
                if (!System.IO.Directory.Exists(tempFolderPath))
                {
                    System.IO.Directory.CreateDirectory(tempFolderPath);
                }

                string tempFilePath = System.IO.Path.Combine(tempFolderPath, "temp_faktura.pdf");
                _tempFilePath = tempFilePath;

                System.IO.File.WriteAllBytes(tempFilePath, pdfData);

                PdfUrl = new Uri(tempFilePath).AbsoluteUri + "#toolbar=0";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving PDF: " + ex.Message);
                PdfUrl = null;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
