using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Services
{
    class Id
    {
        private static Id? _instance;
        public static Id Instance => _instance ??= new Id();

        public int idkorisnik { get; set; }
        public int firmaid { get; set; }
        public int pravnoLiceId { get; set; }
        public int FakturaId { get; set; }
        public string TipFakture { get; set; } = string.Empty;



        private Id() { }
    }
}
