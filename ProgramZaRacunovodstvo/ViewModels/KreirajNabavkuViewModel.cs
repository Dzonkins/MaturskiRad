using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private bool CanDeleteStavka(object parameter)
        {
            return parameter is Stavka stavka;
        }
    }
}
