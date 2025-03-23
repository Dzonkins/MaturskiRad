using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Wpf.Ui.Input;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class ProdajaViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseKomande _database = new DatabaseKomande();
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;

        private ObservableCollection<Models.Prodaja> _originalProdaja = new();
        public ICommand Izbrisi { get; }
        public ICommand Detalji { get; }


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

        private ObservableCollection<Models.Prodaja> _pagedProdaja = new();

        public ObservableCollection<Models.Prodaja> PagedProdaja
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


        private ObservableCollection<Models.Prodaja> _prodaja = new();

        public ObservableCollection<Models.Prodaja> Prodaje
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
            Izbrisi = new RelayCommand(IzbrisiNabavku);
            Detalji = new RelayCommand(DetaljiNabavke);
            PrethodnaStranica = new RelayCommand<object>(_ => PrethodnaStrana(), _ => _trenutnaStranica > 1);
            SledecaStranica = new RelayCommand<object>(_ => SledecaStrana(), _ => _trenutnaStranica < TotalPages);
            ucitajPodatke();

            _timer = new System.Timers.Timer(300);
            _timer.AutoReset = false;
            _timer.Elapsed += (s, e) => Pretraga();


        }

        private void IzbrisiNabavku(object parameter)
        {
            if (parameter is Models.Prodaja prodaja && PagedProdaja.Contains(prodaja))
            {
                PagedProdaja.Remove(prodaja);
                Prodaje.Remove(prodaja);
                _database.IzbrisiFakturu(prodaja.Id);
                OsveziStavke();
            }
        }

        private void DetaljiNabavke(object parameter)
        {
            if (parameter is Models.Prodaja prodaja && PagedProdaja.Contains(prodaja))
            {
                Id.Instance.TipFakture = "Prodaja";
                Id.Instance.FakturaId = prodaja.Id;
                Navigation.Instance.NavigateTo(new Views.DetaljiFakture(Navigation.Instance.GetMainWindow()));
            }
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
                        (n.Kupac?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false)
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

                Prodaje = new ObservableCollection<Models.Prodaja>(filter);
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
            _originalProdaja = new ObservableCollection<Models.Prodaja>(_database.IzvuciProdaje(Id.Instance.firmaid, "Prodaja").OrderByDescending(n => n.Id));
            Prodaje = new ObservableCollection<Models.Prodaja>(_originalProdaja);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (Prodaje.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedProdaja = new ObservableCollection<Models.Prodaja>(
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
