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
    class ProdajaViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;
        private ObservableCollection<Prodaja> _originalProdaja = new();


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

        private ObservableCollection<Prodaja> _pagedProdaja = new();

        public ObservableCollection<Prodaja> PagedProdaja
        {
            get => _pagedProdaja;
            set
            {
                _pagedProdaja = value;
                OnPropertyChanged(nameof(PagedProdaja));
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


        private ObservableCollection<Prodaja> _prodaja = new();

        public ObservableCollection<Prodaja> Prodaje
        {
            get => _prodaja;
            set
            {
                _prodaja = value;
                OnPropertyChanged(nameof(Prodaje));
            }
        }

        public ProdajaViewModel()
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
                var filter = _originalProdaja.AsEnumerable(); 

                if (!string.IsNullOrWhiteSpace(PretragaText))
                {
                    filter = filter.Where(n =>
                        (n.BrojFakture?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.Status != null && n.Status.StartsWith(PretragaText, StringComparison.OrdinalIgnoreCase)) ||
                        (n.Primalac?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false)
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

                Prodaje = new ObservableCollection<Prodaja>(filter);
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
            _originalProdaja = new ObservableCollection<Prodaja>
            {
                new Prodaja { BrojFakture = "F23456", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "1F2345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)},
                new Prodaja { BrojFakture = "F12345", Status = "Plaćeno", Primalac = "ABC d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Prodaja { BrojFakture = "F12346", Status = "Neplaćeno", Primalac = "XYZ d.o.o.", Osnovica = 10000, Pdv = 2000, Ukupno = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)}
            };
            Prodaje = new ObservableCollection<Prodaja>(_originalProdaja);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (Prodaje.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedProdaja = new ObservableCollection<Prodaja>(
                Prodaje.Skip((_trenutnaStranica - 1) * stavkiPoStranici).Take(stavkiPoStranici)
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
