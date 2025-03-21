using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    class DetaljiFakture
    {
        public string BrojFakture { get; set; } = string.Empty;
        public string TipFakture { get; set; } = string.Empty;
        public string StatusFakture { get; set; } = string.Empty;
        public decimal Ukupno { get; set; }
        public string Dobavljac { get; set; } = string.Empty;
        public string Kupac { get; set; } = string.Empty;
        public DateOnly? Datum { get; set; }
        public byte[]? Fajl { get; set; }
        public List<FajlFakture> Fajlovi { get; set; } = new();
       
    }
    class FajlFakture
    {
        public int Id { get; set; }
        public int FakturaId { get; set; }
        public string NazivFajla { get; set; } = string.Empty;
        public byte[] Fajl { get; set; } = Array.Empty<byte>();
    }
}
