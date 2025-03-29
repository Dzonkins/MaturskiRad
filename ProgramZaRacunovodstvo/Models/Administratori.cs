using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    internal class Administratori
    {
        public int Id { get; set; }
        public int korisnikId { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
