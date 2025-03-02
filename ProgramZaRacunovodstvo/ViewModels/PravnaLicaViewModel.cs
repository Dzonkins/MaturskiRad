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

namespace ProgramZaRacunovodstvo.ViewModels
{
    class PravnaLicaViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;
        private ObservableCollection<PravnaLica> _originalPravnaLica = new();


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

        private ObservableCollection<PravnaLica> _pagedPravnaLica = new();

        public ObservableCollection<PravnaLica> PagedPravnaLica
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


        private ObservableCollection<PravnaLica> _pravnaLica = new();

        public ObservableCollection<PravnaLica> PravnaLica1
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
            PrethodnaStranica = new RelayCommand<object>(_ => PrethodnaStrana(), _ => _trenutnaStranica > 1);
            SledecaStranica = new RelayCommand<object>(_ => SledecaStrana(), _ => _trenutnaStranica < TotalPages);
            ucitajPodatke();

            _timer = new System.Timers.Timer(300);
            _timer.AutoReset = false;
            _timer.Elapsed += (s, e) => Pretraga();


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


                PravnaLica1 = new ObservableCollection<PravnaLica>(filter);
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
            _originalPravnaLica = new ObservableCollection<PravnaLica>
            {
                new PravnaLica { Naziv = "F1234", PIB = 123456789, Maticnibroj = 12345678, Grad = "Beograd", Adresa = "Ulica 1, 10", Racun = 1234567890123456, Zastupnik = "Petar Petrović" },
                new PravnaLica { Naziv = "F5678", PIB = 987654321, Maticnibroj = 87654321, Grad = "Novi Sad", Adresa = "Ulica 2, 20", Racun = 9876543210987654, Zastupnik = "Ana Anić" },
                new PravnaLica { Naziv = "F9012", PIB = 112233445, Maticnibroj = 55667788, Grad = "Niš", Adresa = "Ulica 3, 30", Racun = 1122334455667788, Zastupnik = "Marko Marković" },
                new PravnaLica { Naziv = "F3456", PIB = 543216789, Maticnibroj = 98761234, Grad = "Subotica", Adresa = "Ulica 4, 40", Racun = 5432167890543216, Zastupnik = "Jelena Jelić" },
                new PravnaLica { Naziv = "F7890", PIB = 678901234, Maticnibroj = 43218765, Grad = "Kragujevac", Adresa = "Ulica 5, 50", Racun = 6789012345678901, Zastupnik = "Stefan Stefanović" },
                new PravnaLica { Naziv = "F2345", PIB = 234567890, Maticnibroj = 65432198, Grad = "Beograd", Adresa = "Ulica 6, 60", Racun = 2345678901234567, Zastupnik = "Milica Milić" },
                new PravnaLica { Naziv = "F6789", PIB = 890123456, Maticnibroj = 89012345, Grad = "Novi Sad", Adresa = "Ulica 7, 70", Racun = 8901234567890123, Zastupnik = "Nikola Nikolić" },
                new PravnaLica { Naziv = "F0123", PIB = 345678901, Maticnibroj = 12345987, Grad = "Niš", Adresa = "Ulica 8, 80", Racun = 3456789012345678, Zastupnik = "Ivana Ivanović" },
                new PravnaLica { Naziv = "F4567", PIB = 789012345, Maticnibroj = 56789012, Grad = "Subotica", Adresa = "Ulica 9, 90", Racun = 7890123456789012, Zastupnik = "Dejan Dejić" },
                new PravnaLica { Naziv = "F8901", PIB = 456789012, Maticnibroj = 90123456, Grad = "Kragujevac", Adresa = "Ulica 10, 100", Racun = 4567890123456789, Zastupnik = "Sanja Sanjić" },
                new PravnaLica { Naziv = "F1122", PIB = 121212121, Maticnibroj = 21212121, Grad = "Zrenjanin", Adresa = "Ulica 11, 110", Racun = 1212121212121212, Zastupnik = "Goran Goranić" },
                new PravnaLica { Naziv = "F3344", PIB = 343434343, Maticnibroj = 43434343, Grad = "Pančevo", Adresa = "Ulica 12, 120", Racun = 3434343434343434, Zastupnik = "Marija Marić" },
                new PravnaLica { Naziv = "F5566", PIB = 565656565, Maticnibroj = 65656565, Grad = "Kraljevo", Adresa = "Ulica 13, 130", Racun = 5656565656565656, Zastupnik = "Dragan Dragić" },
                new PravnaLica { Naziv = "F7788", PIB = 787878787, Maticnibroj = 87878787, Grad = "Čačak", Adresa = "Ulica 14, 140", Racun = 7878787878787878, Zastupnik = "Tamara Tamarić" },
                new PravnaLica { Naziv = "F9900", PIB = 909090909, Maticnibroj = 90909090, Grad = "Leskovac", Adresa = "Ulica 15, 150", Racun = 9090909090909090, Zastupnik = "Aleksandar Aleksandrić" },
                new PravnaLica { Naziv = "F2233", PIB = 232323232, Maticnibroj = 32323232, Grad = "Vranje", Adresa = "Ulica 16, 160", Racun = 2323232323232323, Zastupnik = "Sofija Sofić" }
            };
            PravnaLica1 = new ObservableCollection<PravnaLica>(_originalPravnaLica);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (PravnaLica1.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedPravnaLica = new ObservableCollection<PravnaLica>(
                PravnaLica1.Skip((_trenutnaStranica - 1) * stavkiPoStranici).Take(stavkiPoStranici)
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
