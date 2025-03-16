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

        public int firmaid { get; set; }
        public int pravnoLiceId { get; set; }

        private Id() { }
    }
}
