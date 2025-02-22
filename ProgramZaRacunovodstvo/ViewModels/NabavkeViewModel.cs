using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class NabavkeViewModel
    {
        private ObservableCollection<Nabavka> _nabavke = new(); // ✅ Now initialized

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
            new Nabavka { BrojFakture = "F12346", TipFakture = "Izlazna", Status = "Neplaćeno", Dobavljac = "XYZ d.o.o.", Iznos = 25000, DatumSlanja = DateOnly.FromDateTime(DateTime.Now).AddDays(-5)
 }
        };
        }
    }
}
