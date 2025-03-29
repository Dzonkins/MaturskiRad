using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    internal class OFirmiViewModel : INotifyPropertyChanged
    {
        public string Naziv { get; set; } = string.Empty;
        public string PIB { get; set; } = string.Empty;
        public string MaticniBroj { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Grad { get; set; } = string.Empty;
        public string BrojRacuna { get; set; } = string.Empty;
        public string Zastupnik { get; set; } = string.Empty;
        private string _email {  get; set; } = string.Empty;
        private string _greska { get; set; } = string.Empty;
        public ICommand DodajAdmina { get; set; }
        public ICommand Izbrisi { get; set; }


        public string Email
        {
            get => _email;
            set
            {

                _email = value;
                OnPropertyChanged(nameof(Email));
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


        public ObservableCollection<Administratori>? Administratori { get; set; }

        private readonly DatabaseKomande _database = new DatabaseKomande();
        public OFirmiViewModel()
        {
            Izbrisi = new RelayCommand(IzbrisiAdmina);
            DodajAdmina = new RelayCommand(DodajAdministratora);
            IzvuciPodatke();
            AdministratoriPodaci();
        }
        private void IzvuciPodatke()
        {
            var firma = _database.OFirmi(Id.Instance.firmaid);
            Naziv = firma.Naziv;
            PIB = firma.PIB;
            MaticniBroj = firma.MaticniBroj;
            Adresa = firma.Adresa;
            Grad = firma.Grad;
            BrojRacuna = FormatBrojRacuna(firma.BrojRacuna);
            Zastupnik = firma.Zastupnik;
        }

        private void DodajAdministratora(object parameter)
        {
            int id = _database.NadjiID(Email);
            if (!string.IsNullOrWhiteSpace(Email))
            {
                if (id != -1 && !_database.ProveraAdministrator(id, Id.Instance.firmaid))
                {
                    Greska = "";
                    OnPropertyChanged(nameof(Greska));
                    _database.DodajAdministratoraFirmi(id, Id.Instance.firmaid);
                    AdministratoriPodaci();
                    OnPropertyChanged(nameof(Administratori));
                }
                else if (_database.ProveraAdministrator(id, Id.Instance.firmaid))
                {
                    Greska = "Korisnik sa unetim email-om je već administrator u ovoj firmi";
                    OnPropertyChanged(nameof(Greska));
                }
                else
                {
                    Greska = "Korisnik sa unetim email-om ne postoji";
                    OnPropertyChanged(nameof(Greska));
                }
            }
            else
            {
                Greska = "Molimo vas unesite potrebne podatke";
            }
           
        }

        private void AdministratoriPodaci()
        {
            Administratori = new ObservableCollection<Administratori>(_database.Administratori(Id.Instance.firmaid));
        }

        private void IzbrisiAdmina(object parameter)
        {
            if (parameter is Models.Administratori admin && Administratori != null)
            {
                
                if(Id.Instance.idkorisnik != admin.korisnikId)
                {
                    Administratori.Remove(admin);
                    _database.IzbrisiAdmina(admin.korisnikId,Id.Instance.firmaid);
                    Greska = "";
                    AdministratoriPodaci();
                    OnPropertyChanged(nameof(Administratori));

                }
                else
                {
                    Greska = "Ne možete da uklonite sami sebe";
                    AdministratoriPodaci();
                    OnPropertyChanged(nameof(Administratori));

                }
            }
        }

        private string FormatBrojRacuna(string broj)
        {
            return $"{broj.Substring(0, 3)}-{broj.Substring(3, broj.Length - 5)}-{broj.Substring(broj.Length - 2)}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
