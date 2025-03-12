﻿using PdfSharp.Drawing;
using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Fonts;
using System.Windows.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class KreirajNabavkuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dokument> SelectedFiles { get; set; } = new ObservableCollection<Dokument>();
        public ObservableCollection<Stavka> Stavke { get; set; } = new ObservableCollection<Stavka>();

        private string _sifra = String.Empty;
        private string _naziv = String.Empty;
        private double? _kolicina;
        private decimal? _cena;
        private decimal? _IznosBezPDV;
        private decimal? _PDV;
        private int? _PDVPosto;
        private decimal? _ukupno;

        public string Sifra
        {
            get => _sifra;
            set
            {
                _sifra = value;
                OnPropertyChanged(nameof(Sifra));
            }
        }

        public string Naziv
        {
            get => _naziv;
            set
            {
                _naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }

        public double? Kolicina
        {
            get => _kolicina;
            set
            {
                _kolicina = value;
                Osnovica();
                IznosPDV();
                UkupanIznos();
            }
        }

        public decimal? Cena
        {
            get => _cena;
            set
            {
                _cena = value;
                Osnovica();
                IznosPDV();
                UkupanIznos();
            }
        }

        public decimal? PDV
        {
            get => _PDV;
            set
            {
                _PDV = value;
                OnPropertyChanged(nameof(PDV));
            }
        }

        public int? PDVPosto
        {
            get => _PDVPosto;
            set
            {
                _PDVPosto = value;
                IznosPDV();
                UkupanIznos();
            }
        }

        public decimal? Ukupno
        {
            get => _ukupno;
            set
            {
                _ukupno = value;
                OnPropertyChanged(nameof(Ukupno));
            }
        }

        public decimal? IznosbezPDV
        {
            get => _IznosBezPDV;
            set
            {
                _IznosBezPDV = value;
                OnPropertyChanged(nameof(IznosbezPDV));
            }
        }

        public ICommand AddFilesCommand { get; set; }
        public ICommand AddStavkaCommand { get; set; }
        public ICommand DeleteCommand { get; }
        public ICommand SacuvajCommand { get; set; }


        private DateTime? _date;

        public DateTime? Date
        {
            get => _date;
            set
            {    
                _date = value;
            }
        }

        

        public KreirajNabavkuViewModel()
        {
            AddFilesCommand = new RelayCommand(AddFiles);
            AddStavkaCommand = new RelayCommand(AddStavka);
            DeleteCommand = new RelayCommand(DeleteStavka, CanDeleteStavka);
            SacuvajCommand = new RelayCommand(GenerisiPDF);
        }

        private void Osnovica()
        {
            if (Kolicina.HasValue && Cena != 0)
            {
                IznosbezPDV = (decimal)Kolicina.Value * Cena;
            }
            else
            {
                IznosbezPDV = 0;
            }
            OnPropertyChanged(nameof(IznosbezPDV));
        }

        private void IznosPDV()
        {
            PDV = (IznosbezPDV ?? 0) * ((PDVPosto ?? 0) / 100m);
            OnPropertyChanged(nameof(Ukupno));

        }

        private void UkupanIznos()
        {
            Ukupno = (IznosbezPDV ?? 0) + (PDV ?? 0);
            OnPropertyChanged(nameof(Ukupno));

        }

        public decimal UkupnoUkupno
        {
            get => Stavke.Sum(stavka => stavka.Ukupno ?? 0);
        }

        public decimal UkupnoOsnovica
        {
            get => Stavke.Sum(stavka => stavka.osnovica ?? 0);
        }

        public decimal ukupnoPDV
        {
            get => Stavke.Sum(stavka => stavka.PDV ?? 0);
        }

        private void AddStavka(object parameter)
        {
            var stavka = new Stavka
            {
                sifra = Sifra,
                naziv = Naziv,
                kolicina = Kolicina,
                cena = Cena,
                osnovica = IznosbezPDV,
                PDV = PDV,
                PDVPosto = PDVPosto,
                Ukupno = Ukupno
                
            };

            Stavke.Add(stavka);

            Sifra = string.Empty;
            Naziv = string.Empty;
            PDVPosto = null;
            Kolicina = null;
            Cena = null;
            IznosbezPDV = null;
            PDV = null;
            Ukupno = null;

            OnPropertyChanged(nameof(Sifra));
            OnPropertyChanged(nameof(Naziv));
            OnPropertyChanged(nameof(PDVPosto));
            OnPropertyChanged(nameof(Kolicina));
            OnPropertyChanged(nameof(Cena));

            OnPropertyChanged(nameof(UkupnoUkupno));
            OnPropertyChanged(nameof(UkupnoOsnovica));
            OnPropertyChanged(nameof(ukupnoPDV));


        }

        private void AddFiles(object parameter)
        {
            var filePaths = parameter as IEnumerable<string>;

            if (filePaths == null)
                return;

            foreach (var path in filePaths)
            {
                var file = new Dokument(path);

                if (!SelectedFiles.Any(f => f.Path == file.Path))
                {
                    SelectedFiles.Add(file);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void DeleteStavka(object parameter)
        {
            var stavka = parameter as Stavka;
            if (stavka != null)
            {
                Stavke.Remove(stavka);
            }
            OnPropertyChanged(nameof(Stavke));
            OnPropertyChanged(nameof(UkupnoUkupno));
            OnPropertyChanged(nameof(UkupnoOsnovica));
            OnPropertyChanged(nameof(ukupnoPDV));
        }

        private bool CanDeleteStavka(object parameter)
        {
            return parameter is Stavka stavka;
        }

        private void GenerisiPDF(object parameter)
        {
            string templateFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template");
            Directory.CreateDirectory(templateFolder);

            string outputPath = System.IO.Path.Combine(templateFolder, "template.pdf");

            PdfDocument document = new PdfDocument();
            document.Info.Title = "NabavkeTemplate";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont titleFont = new XFont("Arial", 20, XFontStyleEx.Bold);
            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
            XFont contentFont = new XFont("Arial", 8);

            gfx.DrawString("Faktura:", titleFont, XBrushes.Black, new XPoint(200, 50));

            gfx.DrawString("Name: _______________________", contentFont, XBrushes.Black, new XPoint(50, 100));
            gfx.DrawString("Address: ____________________", contentFont, XBrushes.Black, new XPoint(50, 130));
            gfx.DrawString("Amount: _____________________", contentFont, XBrushes.Black, new XPoint(50, 160));

            double tableX = 15;
            double tableY = 200;
            double tableWidth = 565;
            double rowHeight = 30;

            gfx.DrawRectangle(XPens.Black, tableX, tableY, tableWidth, rowHeight);
            gfx.DrawString("Naziv", headerFont, XBrushes.Black, new XPoint(tableX + 10, tableY + 20));
            gfx.DrawString("Količina", headerFont, XBrushes.Black, new XPoint(tableX + 80, tableY + 20));
            gfx.DrawString("Jedinična cena", headerFont, XBrushes.Black, new XPoint(tableX + 140, tableY + 20));
            gfx.DrawString("Iznos bez PDV", headerFont, XBrushes.Black, new XPoint(tableX + 230, tableY + 20));
            gfx.DrawString("Stopa PDV", headerFont, XBrushes.Black, new XPoint(tableX + 310, tableY + 20));
            gfx.DrawString("PDV", headerFont, XBrushes.Black, new XPoint(tableX + 380, tableY + 20));
            gfx.DrawString("Iznos sa PDV", headerFont, XBrushes.Black, new XPoint(tableX + 470, tableY + 20));



            double currentY = tableY + rowHeight;
            foreach (var stavke in Stavke)
            {
                gfx.DrawRectangle(XPens.Black, tableX, currentY, tableWidth, rowHeight);
                gfx.DrawString(stavke.naziv, contentFont, XBrushes.Black, new XPoint(tableX + 10, currentY + 20));
                gfx.DrawString(stavke.kolicina?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 80, currentY + 20));
                gfx.DrawString(stavke.cenaRSD, contentFont, XBrushes.Black, new XPoint(tableX + 140, currentY + 20));
                gfx.DrawString(stavke.osnovicaRSD, contentFont, XBrushes.Black, new XPoint(tableX + 230, currentY + 20));
                gfx.DrawString(stavke.pdvposto?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 310, currentY + 20));
                gfx.DrawString(stavke.PDVRSD?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 380, currentY + 20));
                gfx.DrawString(stavke.ukupnoRSD?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 470, currentY + 20));
                currentY += rowHeight;
            }

            gfx.DrawString("Iznos bez PDV", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 20));
            gfx.DrawString(UkupnoOsnovica.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 20));
            gfx.DrawString("Ukupan PDV", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 40));
            gfx.DrawString(ukupnoPDV.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 40));
            gfx.DrawString("Ukupan iznos", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 60));
            gfx.DrawString(UkupnoUkupno.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 60));

            currentY += rowHeight + 20;

            document.Save(outputPath);
            Process.Start(new ProcessStartInfo(outputPath) { UseShellExecute = true });
        }
    }
}
