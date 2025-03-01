using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    public class Nabavka
    {
        public int ID { get; set; }
        public string BrojFakture { get; set; } = string.Empty;
        public string TipFakture { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Dobavljac { get; set; } = string.Empty;
        public double Osnovica { get; set; }

        public double Pdv { get; set; }
        public double Ukupno { get; set; }
        public DateOnly DatumSlanja { get; set; }

        public string OsnovicaRSD => $"{Osnovica:N2} RSD";
        public string PdvRSD => $"{Pdv:N2} RSD";
        public string UkupnoRSD => $"{Ukupno:N2} RSD";
    }

}
