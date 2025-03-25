using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
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
        private readonly DatabaseKomande _database = new DatabaseKomande();
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
            _originalIzvod = new ObservableCollection<Izvod>(_database.Izvodi(Id.Instance.firmaid).OrderByDescending(n => n.Id));
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
