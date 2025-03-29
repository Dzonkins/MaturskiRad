using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    internal class Firma
    {
        public string Naziv { get; set; } = string.Empty;
        public string PIB { get; set; } = string.Empty;
        public string MaticniBroj { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Grad { get; set; } = string.Empty;
        public string BrojRacuna { get; set; } = string.Empty;
        public string Zastupnik { get; set; } = string.Empty;
    }
}
