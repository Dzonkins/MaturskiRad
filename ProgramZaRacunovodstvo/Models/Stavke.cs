using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    class Stavka
    {
        public string sifra { get; set; } = string.Empty;
        public string naziv { get; set; } = string.Empty;
        public double? kolicina { get; set; }
        public decimal? cena { get; set; }
        public decimal? osnovica { get; set; }
        public decimal? PDV { get; set; }
        public int? PDVPosto { get; set; }
        public decimal? Ukupno { get; set; }

        public string cenaRSD => $"{cena:N2} RSD";
        public string osnovicaRSD => $"{osnovica:N2} RSD";
        public string pdvposto => $"{PDVPosto:N2}%";
        public string ukupnoRSD => $"{Ukupno:N2} RSD";
    }
}
