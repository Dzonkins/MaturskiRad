using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    internal class PravnaLica
    {
        public string Naziv { get; set; } = string.Empty;
        public int PIB { get; set; }
        public int Maticnibroj { get; set; }
        public string Grad { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public long Racun { get; set; }
        public string Zastupnik { get; set; } = string.Empty;

    }
}
