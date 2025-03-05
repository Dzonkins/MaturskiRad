using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    internal class IzvodiViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;
        private ObservableCollection<Izvod> _originalIzvod = new();


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

        private ObservableCollection<Izvod> _pagedIzvodi = new();

        public ObservableCollection<Izvod> PagedIzvodi
        {
            get => _pagedIzvodi;
            set
            {
                _pagedIzvodi = value;
                OnPropertyChanged(nameof(PagedIzvodi));
            }
        }

        public ICommand PrethodnaStranica { get; }
        public ICommand SledecaStranica { get; }

        private DateTime? _date;

        public DateTime? Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    if (Date2.HasValue && value.HasValue && value > Date2)
                    {
                        _date = Date2;
                        Pretraga();
                    }
                    else
                    {
                        _date = value;
                        Pretraga();
                    }

                    OnPropertyChanged(nameof(Date));

                    if (Date2.HasValue && Date.HasValue && Date2 < Date)
                    {
                        Date2 = Date;
                        Pretraga();
                    }
                }
            }
        }

        private DateTime? _date2;


        public DateTime? Date2
        {
            get => _date2;
            set
            {
                if (_date2 != value)
                {
                    if (Date.HasValue && value.HasValue && value < Date)
                    {
                        _date2 = Date;
                        Pretraga();
                    }
                    else
                    {
                        _date2 = value;
                        Pretraga();
                    }

                    OnPropertyChanged(nameof(Date2));
                }
            }
        }


        private ObservableCollection<Izvod> _izvodi = new();

        public ObservableCollection<Izvod> Izvodi
        {
            get => _izvodi;
            set
            {
                _izvodi = value;
                OnPropertyChanged(nameof(Izvodi));
            }
        }

        public IzvodiViewModel()
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
                var filter = _originalIzvod.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(PretragaText))
                {
                    filter = filter.Where(n =>
                        (n.BrojFakture?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.TipFakture != null && n.TipFakture.StartsWith(PretragaText, StringComparison.OrdinalIgnoreCase)) ||
                        (n.PravnoLice?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.Status != null && PretragaText != "" && n.Status.StartsWith(PretragaText, StringComparison.OrdinalIgnoreCase))

                    );
                }

                if (Date.HasValue)
                {
                    DateOnly startDate = DateOnly.FromDateTime(Date.Value);
                    filter = filter.Where(n => n.DatumSlanja >= startDate);
                }

                if (Date2.HasValue)
                {
                    DateOnly endDate = DateOnly.FromDateTime(Date2.Value);
                    filter = filter.Where(n => n.DatumSlanja <= endDate);
                }

                Izvodi = new ObservableCollection<Izvod>(filter);
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
            _originalIzvod = new ObservableCollection<Izvod>
            {
               new Izvod { BrojFakture = "FAKT-2023-123", TipFakture = "Izlazna", Status = "Poslato", PravnoLice = "Firma A", Osnovica = 1000.00, Pdv = 200.00, Ukupno = 1200.00, DatumSlanja = new DateOnly(2023, 10, 26) },
               new Izvod { BrojFakture = "FAKT-2023-124", TipFakture = "Ulazna", Status = "Primljeno", PravnoLice = "Dobavljač B", Osnovica = 500.50, Pdv = 100.10, Ukupno = 600.60, DatumSlanja = new DateOnly(2023, 10, 27) },
               new Izvod { BrojFakture = "FAKT-2023-125", TipFakture = "Izlazna", Status = "U Obradi", PravnoLice = "Klijent C", Osnovica = 2500.75, Pdv = 500.15, Ukupno = 3000.90, DatumSlanja = new DateOnly(2023, 10, 28) },
               new Izvod { BrojFakture = "FAKT-2023-126", TipFakture = "Ulazna", Status = "Plaćeno", PravnoLice = "Dobavljač D", Osnovica = 800.00, Pdv = 160.00, Ukupno = 960.00, DatumSlanja = new DateOnly(2023, 10, 29) },
               new Izvod { BrojFakture = "FAKT-2023-127", TipFakture = "Izlazna", Status = "Poslato", PravnoLice = "Firma E", Osnovica = 1500.25, Pdv = 300.05, Ukupno = 1800.30, DatumSlanja = new DateOnly(2023, 10, 30) },
               new Izvod { BrojFakture = "FAKT-2023-128", TipFakture = "Ulazna", Status = "Primljeno", PravnoLice = "Dobavljac F", Osnovica = 1200.00, Pdv = 240.00, Ukupno = 1440.00, DatumSlanja = new DateOnly(2023, 10, 31) },
               new Izvod { BrojFakture = "FAKT-2023-129", TipFakture = "Izlazna", Status = "U Obradi", PravnoLice = "Klijent G", Osnovica = 3000.00, Pdv = 600.00, Ukupno = 3600.00, DatumSlanja = new DateOnly(2023, 11, 01) },
               new Izvod { BrojFakture = "FAKT-2023-130", TipFakture = "Ulazna", Status = "Plaćeno", PravnoLice = "Dobavljač H", Osnovica = 750.50, Pdv = 150.10, Ukupno = 900.60, DatumSlanja = new DateOnly(2023, 11, 02) },
               new Izvod { BrojFakture = "FAKT-2023-131", TipFakture = "Izlazna", Status = "Poslato", PravnoLice = "Firma I", Osnovica = 1800.75, Pdv = 360.15, Ukupno = 2160.90, DatumSlanja = new DateOnly(2023, 11, 03) },
               new Izvod { BrojFakture = "FAKT-2023-132", TipFakture = "Ulazna", Status = "Primljeno", PravnoLice = "Dobavljač J", Osnovica = 900.00, Pdv = 180.00, Ukupno = 1080.00, DatumSlanja = new DateOnly(2023, 11, 04) },
               new Izvod { BrojFakture = "FAKT-2023-133", TipFakture = "Izlazna", Status = "U Obradi", PravnoLice = "Klijent K", Osnovica = 2200.25, Pdv = 440.05, Ukupno = 2640.30, DatumSlanja = new DateOnly(2023, 11, 05) },
               new Izvod { BrojFakture = "FAKT-2023-134", TipFakture = "Ulazna", Status = "Plaćeno", PravnoLice = "Dobavljač L", Osnovica = 1300.00, Pdv = 260.00, Ukupno = 1560.00, DatumSlanja = new DateOnly(2023, 11, 06) },
               new Izvod { BrojFakture = "FAKT-2023-135", TipFakture = "Izlazna", Status = "Poslato", PravnoLice = "Firma M", Osnovica = 2800.50, Pdv = 560.10, Ukupno = 3360.60, DatumSlanja = new DateOnly(2023, 11, 07) },
               new Izvod { BrojFakture = "FAKT-2023-136", TipFakture = "Ulazna", Status = "Primljeno", PravnoLice = "Dobavljač N", Osnovica = 600.75, Pdv = 120.15, Ukupno = 720.90, DatumSlanja = new DateOnly(2023, 11, 08) },
               new Izvod { BrojFakture = "FAKT-2023-137", TipFakture = "Izlazna", Status = "U Obradi", PravnoLice = "Klijent O", Osnovica = 1900.00, Pdv = 380.00, Ukupno = 2280.00, DatumSlanja = new DateOnly(2023, 11, 09) },
               new Izvod { BrojFakture = "FAKT-2023-138", TipFakture = "Ulazna", Status = "Plaćeno", PravnoLice = "Dobavljač P", Osnovica = 1100.25, Pdv = 220.05, Ukupno = 1320.30, DatumSlanja = new DateOnly(2023, 11, 10) }
            };
            Izvodi = new ObservableCollection<Izvod>(_originalIzvod);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (Izvodi.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedIzvodi = new ObservableCollection<Izvod>(
                Izvodi.Skip((_trenutnaStranica - 1) * stavkiPoStranici).Take(stavkiPoStranici)
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
