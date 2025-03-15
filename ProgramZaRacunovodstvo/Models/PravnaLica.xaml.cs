using PdfSharp.Quality;
using ProgramZaRacunovodstvo.Services;
using ProgramZaRacunovodstvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgramZaRacunovodstvo.Models
{
    internal class PravnaLica
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string PIB { get; set; } = string.Empty;
        public string Maticnibroj { get; set; } = string.Empty;
        public string Grad { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Racun { get; set; } = string.Empty;
        public string Zastupnik { get; set; } = string.Empty;
       

    }
}
