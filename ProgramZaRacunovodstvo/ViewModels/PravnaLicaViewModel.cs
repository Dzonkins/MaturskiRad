using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wpf.Ui.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.Views;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class PravnaLicaViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;
        private readonly DatabaseKomande _database = new DatabaseKomande();
        private ObservableCollection<Models.PravnaLica> _originalPravnaLica = new();
        public ICommand Izbrisi { get; }
        public ICommand Izmeni { get; }



        public string PretragaText
        {
            get => _pretragaText;
            set
            {
                if (_pretragaText != value)
                {
                    _pretragaText = value;
                    OnPropertyChanged(nameof(PretragaText));
                    _timer.Stop();
                    _timer.Start();
                }
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            private set
            {
                if (_totalPages != value)
                {
                    _totalPages = value;
                    OnPropertyChanged(nameof(TotalPages));
                    OsveziStatusKomandi();
                }
            }
        }

        public int stavkiPoStranici
        {
            get => _stavkiPoStranici;
            set
            {
                if (_stavkiPoStranici != value)
                {
                    _stavkiPoStranici = value;
                    OnPropertyChanged(nameof(stavkiPoStranici));
                    OsveziStavke();
                }
            }
        }

        private ObservableCollection<Models.PravnaLica> _pagedPravnaLica = new();

        public ObservableCollection<Models.PravnaLica> PagedPravnaLica
        {
            get => _pagedPravnaLica;
            set
            {
                _pagedPravnaLica = value;
                OnPropertyChanged(nameof(PagedPravnaLica));
            }
        }

        public ICommand PrethodnaStranica { get; }
        public ICommand SledecaStranica { get; }



        private ObservableCollection<Models.PravnaLica> _pravnaLica = new();

        public ObservableCollection<Models.PravnaLica> PravnaLica1
        {
            get => _pravnaLica;
            set
            {
                _pravnaLica = value;
                OnPropertyChanged(nameof(PravnaLica1));
            }
        }

        public PravnaLicaViewModel()
        {
            Izmeni = new RelayCommand(IzmeniPravnoLice);
            Izbrisi = new RelayCommand(IzbrisiPravnoLice);
            PrethodnaStranica = new RelayCommand<object>(_ => PrethodnaStrana(), _ => _trenutnaStranica > 1);
            SledecaStranica = new RelayCommand<object>(_ => SledecaStrana(), _ => _trenutnaStranica < TotalPages);
            ucitajPodatke();

            _timer = new System.Timers.Timer(300);
            _timer.AutoReset = false;
            _timer.Elapsed += (s, e) => Pretraga();


        }

        private void IzbrisiPravnoLice(object parameter)
        {
            if (parameter is Models.PravnaLica pravnoLice && PagedPravnaLica.Contains(pravnoLice))
            {
                PagedPravnaLica.Remove(pravnoLice);
                PravnaLica1.Remove(pravnoLice);
                _database.IzbrisiPravnoLice(pravnoLice.Id);
                ucitajPodatke();
            }
        }

        private void IzmeniPravnoLice(object parameter)
        {
            if (parameter is Models.PravnaLica pravnoLice && PagedPravnaLica.Contains(pravnoLice))
            {
                Id.Instance.pravnoLiceId = pravnoLice.Id;
                Navigation.Instance.NavigateTo(new IzmeniPravnoLice(Navigation.Instance.GetMainWindow()));
            }
        }

        private void Pretraga()
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                var filter = _originalPravnaLica.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(PretragaText))
                {
                    filter = filter.Where(n =>
                        (n.Naziv?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.PIB.ToString().Contains(PretragaText, StringComparison.OrdinalIgnoreCase)) ||
                        (n.Maticnibroj.ToString().Contains(PretragaText, StringComparison.OrdinalIgnoreCase)) ||
                        (n.Grad?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.Adresa?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.Zastupnik?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false)



                    );
                }


                PravnaLica1 = new ObservableCollection<Models.PravnaLica>(filter);
                OsveziStavke();
            });
        }



        private void OsveziStatusKomandi()
        {
            (PrethodnaStranica as RelayCommand<object>)?.NotifyCanExecuteChanged();
            (SledecaStranica as RelayCommand<object>)?.NotifyCanExecuteChanged();
        }

        private void ucitajPodatke()
        {
            _originalPravnaLica = new ObservableCollection<Models.PravnaLica>(_database.IzvuciPravnaLica(Id.Instance.firmaid));
            PravnaLica1 = new ObservableCollection<Models.PravnaLica>(_originalPravnaLica);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (PravnaLica1.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedPravnaLica = new ObservableCollection<Models.PravnaLica>(
                PravnaLica1.Skip((_trenutnaStranica - 1) * stavkiPoStranici).Take(stavkiPoStranici)
                  .Select(p => new Models.PravnaLica
                  {
                      Id = p.Id,
                      Naziv = p.Naziv,
                      PIB = p.PIB,
                      Maticnibroj = p.Maticnibroj,
                      Grad = p.Grad,
                      Adresa = p.Adresa,
                      Zastupnik = p.Zastupnik,
                      Racun = FormatBrojRacuna(p.Racun)
                  })
            );


            OsveziStatusKomandi();

        }

        private void PrethodnaStrana()
        {
            if (_trenutnaStranica > 1)
            {
                _trenutnaStranica--;
                OsveziStavke();
                OsveziStatusKomandi();

            }
        }

        private void SledecaStrana()
        {
            if (_trenutnaStranica < TotalPages)
            {
                _trenutnaStranica++;
                OsveziStavke();
                OsveziStatusKomandi();

            }
        }

        private string FormatBrojRacuna(string broj)
        {
            return $"{broj.Substring(0, 3)}-{broj.Substring(3, broj.Length - 5)}-{broj.Substring(broj.Length - 2)}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
