using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using System.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class IzmeniPravnoLiceVievModel : INotifyPropertyChanged
    {
        private string _naziv = String.Empty;
        private string _pib = String.Empty;
        private string _maticniBroj = String.Empty;
        private string _grad = String.Empty;
        private string _adresa = String.Empty;
        private string _racun = String.Empty;
        private string _zastupnik = String.Empty;
        private string _greska = String.Empty;
        public int id { get; set; }
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

        public IzmeniPravnoLiceVievModel()
        {
            id = Id.Instance.pravnoLiceId;
            Sacuvaj = new RelayCommand(sacuvaj);
            PovuciPodatke();
        }

        private void PovuciPodatke()
        {
            List<string> PodaciPravnoLice = new List<string>(_database.PodaciOPravnomLicu(Id.Instance.pravnoLiceId));
            Naziv = PodaciPravnoLice[0];
            Pib = PodaciPravnoLice[1];
            MaticniBroj = PodaciPravnoLice[2];
            Grad = PodaciPravnoLice[3];
            Adresa = PodaciPravnoLice[4];
            Racun = PodaciPravnoLice[5];
            Zastupnik = PodaciPravnoLice[6];
        }

        private void sacuvaj(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(Naziv) && !string.IsNullOrWhiteSpace(Pib) && !string.IsNullOrWhiteSpace(MaticniBroj) && !string.IsNullOrWhiteSpace(Grad) && !string.IsNullOrWhiteSpace(Adresa) && !string.IsNullOrWhiteSpace(Racun) && !string.IsNullOrWhiteSpace(Zastupnik))
            {
                _database.IzmeniPravnoLice(Naziv, Pib, MaticniBroj, Grad, Adresa, Racun, Zastupnik, id);
                Greska = "";
                Naziv = String.Empty;
                Pib = String.Empty;
                MaticniBroj = String.Empty;
                Grad = String.Empty;
                Adresa = String.Empty;
                Racun = String.Empty;
                Zastupnik = String.Empty;
                Navigation.Instance.NavigateTo(new Views.PravnaLica(Navigation.Instance.GetMainWindow()));
            }
            else
            {
                Greska = "Molimo vas popunite sva polja";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
