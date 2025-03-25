using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.Views;


namespace ProgramZaRacunovodstvo.ViewModels
{

    class DodajPravnoLiceViewModel : INotifyPropertyChanged
    {
        private string _naziv = String.Empty;
        private string _pib = String.Empty;
        private string _maticniBroj = String.Empty;
        private string _grad = String.Empty;
        private string _adresa = String.Empty;
        private string _racun = String.Empty;
        private string _zastupnik = String.Empty;
        private string _greska = String.Empty;
        public int FirmaId { get; set; }
        private readonly DatabaseKomande _database = new DatabaseKomande();


        public ICommand Sacuvaj { get; set; }

        public string Naziv
        {
            get => _naziv;
            set
            {
                _naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }

        public string Pib
        {
            get => _pib;
            set
            {
                _pib = value;
                OnPropertyChanged(nameof(Pib));
            }
        }

        public string MaticniBroj
        {
            get => _maticniBroj;
            set
            {
                _maticniBroj = value;
                OnPropertyChanged(nameof(MaticniBroj));
            }
        }
        public string Grad
        {
            get => _grad;
            set
            {
                _grad = value;
                OnPropertyChanged(nameof(Grad));
            }
        }

        public string Adresa
        {
            get => _adresa;
            set
            {
                _adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }

        public string Racun
        {
            get => _racun;
            set
            {
                _racun = value;
                OnPropertyChanged(nameof(Racun));
            }
        }
        public string Zastupnik
        {
            get => _zastupnik;
            set
            {
                _zastupnik = value;
                OnPropertyChanged(nameof(Zastupnik));
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

        public DodajPravnoLiceViewModel()
        {
            FirmaId = Id.Instance.firmaid;
            Sacuvaj = new RelayCommand(sacuvaj);
        }

        private void sacuvaj(object parameter)
        {
            if(string.IsNullOrWhiteSpace(Naziv) || string.IsNullOrWhiteSpace(Pib) || string.IsNullOrWhiteSpace(MaticniBroj) || string.IsNullOrWhiteSpace(Grad) || string.IsNullOrWhiteSpace(Adresa) || string.IsNullOrWhiteSpace(Racun) || string.IsNullOrWhiteSpace(Zastupnik))
            {
                Greska = "Molimo vas popunite sva polja";
            }else if(_database.PravnoLiceProvera(Naziv ,Id.Instance.firmaid))
            {
                Greska = "Pravno lice sa unetim nazivom već postoji";

            }else if(_database.PravnoLicePIB(Pib, Id.Instance.firmaid))
            {
                Greska = "Pravno lice sa unetim PIB-om već postoji";

            }
            else
            {
                _database.DodajPravnoLice(Naziv, Pib, MaticniBroj, Grad, Adresa, Racun, Zastupnik, FirmaId);
                Greska = "";
                Naziv = String.Empty;
                Pib = String.Empty;
                MaticniBroj = String.Empty;
                Grad = String.Empty;
                Adresa = String.Empty;
                Racun = String.Empty;
                Zastupnik = String.Empty;
                Navigation.Instance.NavigateTo(new PravnaLica(Navigation.Instance.GetMainWindow()));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
