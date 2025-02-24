using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class NabavkeViewModel : INotifyPropertyChanged
    {
        private DateTime? _date;

        public DateTime? Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    // Validation: Ensure Date1 is not bigger than Date2
                    if (Date2.HasValue && value.HasValue && value > Date2)
                    {
                        _date = Date2; // Set Date1 to Date2 if it's bigger
                    }
                    else
                    {
                        _date = value;
                    }

                    OnPropertyChanged(nameof(Date));

                    // Update Date2 if it's less than Date
                    if (Date2.HasValue && Date.HasValue && Date2 < Date)
                    {
                        Date2 = Date;
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
                    // Validation: Ensure Date2 is not less than Date1
                    if (Date.HasValue && value.HasValue && value < Date)
                    {
                        _date2 = Date; // Set Date2 to Date1 if it's less
                    }
                    else
                    {
                        _date2 = value;
                    }

                    OnPropertyChanged(nameof(Date2));
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Nabavka> _nabavke = new();

        public ObservableCollection<Nabavka> Nabavke
        {
            get => _nabavke;
            set
            {
                _nabavke = value;
            }
        }

        public NabavkeViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Nabavke = new ObservableCollection<Nabavka>
            {
                new Nabavka { BrojFakture = "F12345", TipFakture = "Ulazna", Status = "Plaćeno", Dobavljac = "ABC d.o.o.", Iznos = 15000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-10) },
                new Nabavka { BrojFakture = "F12346", TipFakture = "Izlazna", Status = "Neplaćeno", Dobavljac = "XYZ d.o.o.", Iznos = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)}
            };
        }
    }
}
