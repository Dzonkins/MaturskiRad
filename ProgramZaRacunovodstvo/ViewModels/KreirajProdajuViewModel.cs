using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class KreirajProdajuViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseKomande _database = new DatabaseKomande();
        public ObservableCollection<Dokument> SelectedFiles { get; set; } = new ObservableCollection<Dokument>();
        public ObservableCollection<Stavka> Stavke { get; set; } = new ObservableCollection<Stavka>();
        public ObservableCollection<string> ListaPravnihLica { get; set; } = new ObservableCollection<string>();

        public List<string>? PodaciKupac { get; set; }
        public List<string> PodaciDobavljac { get; set; }

        private string _greska = string.Empty;
        private bool _placenoProvera;
        private string status = string.Empty;
        private string _sifra = string.Empty;
        private string _naziv = string.Empty;
        private double? _kolicina;
        private decimal? _cena;
        private decimal? _IznosBezPDV;
        private decimal? _PDV;
        private int? _PDVPosto;
        private decimal? _ukupno;
        private string _selectedPravnoLice = string.Empty;
        private string _brojFakture = string.Empty;

        public string BrojFakture
        {
            get => _brojFakture;
            set
            {
                _brojFakture = value;
                OnPropertyChanged(BrojFakture);
            }
        }
        public string SelectedPravnoLice
        {
            get => _selectedPravnoLice;
            set
            {

                _selectedPravnoLice = value;
                OnPropertyChanged(SelectedPravnoLice);
            }
        }

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

        public bool Placeno
        {
            get => _placenoProvera;
            set
            {
                _placenoProvera = value;
                OnPropertyChanged(nameof(Placeno));
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
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Greska
        {
            get => _greska;
            set
            {
                _greska = value;
                OnPropertyChanged(nameof(Greska));
            }
        }


        public KreirajProdajuViewModel()
        {
            AddFilesCommand = new RelayCommand(AddFiles);
            AddStavkaCommand = new RelayCommand(AddStavka);
            DeleteCommand = new RelayCommand(DeleteStavka, CanDeleteStavka);
            SacuvajCommand = new RelayCommand(GenerisiPDF);
            PodaciDobavljac = new List<string>(_database.PodaciOFirmi(Id.Instance.firmaid));
            UcitajImenaPravnihLica();
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
            if (!string.IsNullOrWhiteSpace(Sifra) && !string.IsNullOrWhiteSpace(Naziv) && Kolicina > 0 && Cena > 0 && PDVPosto >= 0)
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
            if (Placeno)
            {
                status = "Plaćeno";
            }
            else
            {
                status = "Neplaćeno";
            }

            if (!string.IsNullOrWhiteSpace(BrojFakture) && !string.IsNullOrWhiteSpace(SelectedPravnoLice) && SelectedFiles.Count > 0 && Stavke.Count > 0 && Date != null)
            {
                Greska = "";
                PodaciKupac = new List<string>(_database.PodaciPravnoLice(SelectedPravnoLice));
                string templateFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
                Directory.CreateDirectory(templateFolder);

                string outputPath = System.IO.Path.Combine(templateFolder, BrojFakture + ".pdf");

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Prodaja";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont titleFont = new XFont("Arial", 20, XFontStyleEx.Bold);
                XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                XFont contentFont = new XFont("Arial", 8);

                gfx.DrawString("Faktura: " + BrojFakture, titleFont, XBrushes.Black, new XPoint(200, 50));
                gfx.DrawString("Datuma slanja: " + (Date?.Date.ToString("dd.MM.yyyy.") ?? "N/A"), contentFont, XBrushes.Black, new XPoint(350, 220));


                gfx.DrawString("Ime dobavljača: " + PodaciDobavljac[0], contentFont, XBrushes.Black, new XPoint(50, 100));
                gfx.DrawString("PIB: " + PodaciDobavljac[1], contentFont, XBrushes.Black, new XPoint(50, 120));
                gfx.DrawString("Matični broj: " + PodaciDobavljac[2], contentFont, XBrushes.Black, new XPoint(50, 140));
                gfx.DrawString("Adresa: " + PodaciDobavljac[3], contentFont, XBrushes.Black, new XPoint(50, 160));
                gfx.DrawString("Grad: " + PodaciDobavljac[4], contentFont, XBrushes.Black, new XPoint(50, 180));
                gfx.DrawString("Žiro račun: " + PodaciDobavljac[5], contentFont, XBrushes.Black, new XPoint(50, 200));

                gfx.DrawString("Ime kupca: " + SelectedPravnoLice, contentFont, XBrushes.Black, new XPoint(350, 100));
                gfx.DrawString("PIB: " + PodaciKupac[0], contentFont, XBrushes.Black, new XPoint(350, 120));
                gfx.DrawString("Matični broj: " + PodaciKupac[1], contentFont, XBrushes.Black, new XPoint(350, 140));
                gfx.DrawString("Adresa: " + PodaciKupac[3], contentFont, XBrushes.Black, new XPoint(350, 160));
                gfx.DrawString("Grad: " + PodaciKupac[2], contentFont, XBrushes.Black, new XPoint(350, 180));


                double tableX = 15;
                double tableY = 240;
                double tableWidth = 565;
                double rowHeight = 30;

                gfx.DrawRectangle(XPens.Black, tableX, tableY, tableWidth, rowHeight);
                gfx.DrawString("Naziv", headerFont, XBrushes.Black, new XPoint(tableX + 10, tableY + 20));
                gfx.DrawString("Količina", headerFont, XBrushes.Black, new XPoint(tableX + 80, tableY + 20));
                gfx.DrawString("Jedinična cena", headerFont, XBrushes.Black, new XPoint(tableX + 140, tableY + 20));
                gfx.DrawString("Iznos bez PDV", headerFont, XBrushes.Black, new XPoint(tableX + 220, tableY + 20));
                gfx.DrawString("Stopa PDV", headerFont, XBrushes.Black, new XPoint(tableX + 320, tableY + 20));
                gfx.DrawString("PDV", headerFont, XBrushes.Black, new XPoint(tableX + 380, tableY + 20));
                gfx.DrawString("Iznos sa PDV", headerFont, XBrushes.Black, new XPoint(tableX + 470, tableY + 20));


                double maxY = page.Height.Point - 100;
                double currentY = tableY + rowHeight;
                foreach (var stavke in Stavke)
                {
                    if (currentY + rowHeight > maxY)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        currentY = 50;
                    }

                    gfx.DrawRectangle(XPens.Black, tableX, currentY, tableWidth, rowHeight);
                    gfx.DrawString(stavke.naziv, contentFont, XBrushes.Black, new XPoint(tableX + 10, currentY + 20));
                    gfx.DrawString(stavke.kolicina?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 80, currentY + 20));
                    gfx.DrawString(stavke.cenaRSD, contentFont, XBrushes.Black, new XPoint(tableX + 140, currentY + 20));
                    gfx.DrawString(stavke.osnovicaRSD, contentFont, XBrushes.Black, new XPoint(tableX + 220, currentY + 20));
                    gfx.DrawString(stavke.pdvposto?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 20));
                    gfx.DrawString(stavke.PDVRSD?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 380, currentY + 20));
                    gfx.DrawString(stavke.ukupnoRSD?.ToString() ?? "-", contentFont, XBrushes.Black, new XPoint(tableX + 470, currentY + 20));
                    currentY += rowHeight;
                }

                gfx.DrawString("Iznos bez PDV:", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 20));
                gfx.DrawString(UkupnoOsnovica.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 20));
                gfx.DrawString("Ukupan PDV:", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 40));
                gfx.DrawString(ukupnoPDV.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 40));
                gfx.DrawString("Ukupan iznos:", headerFont, XBrushes.Black, new XPoint(tableX + 320, currentY + 60));
                gfx.DrawString(UkupnoUkupno.ToString("N2") + " RSD", headerFont, XBrushes.Black, new XPoint(tableX + 420, currentY + 60));

                currentY += rowHeight + 20;
                document.Save(outputPath);
                byte[] GenerisanPdf = File.ReadAllBytes(outputPath);
                string formattedDate = Date.HasValue ? Date.Value.Date.ToString("dd-MM-yyyy") : "01-01-0001";
                DateTime datum = Date.HasValue ? new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 0, 0, 0) : DateTime.MinValue;

                _database.KreirajFakturu("Prodaja", status, PodaciDobavljac[0], SelectedPravnoLice, Stavke, SelectedFiles, Id.Instance.firmaid, BrojFakture, UkupnoOsnovica, ukupnoPDV, UkupnoUkupno, datum, GenerisanPdf);
                Navigation.Instance.NavigateTo(new Views.Prodaja(Navigation.Instance.GetMainWindow()));

            }
            else
            {

                Greska = "Molimo vas unesite sve podatke i dodajte potrebne dokumente";
            }
        }

        private void UcitajImenaPravnihLica()
        {
            var items = _database.ImenaPravnihLica(Id.Instance.firmaid);
            ListaPravnihLica.Clear();


            foreach (var item in items)
            {
                ListaPravnihLica.Add(item);
            }

            SelectedPravnoLice = "Kupac";
        }
    }
}
