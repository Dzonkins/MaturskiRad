﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    public class Prodaja
    {
        public int ID { get; set; }
        public string BrojFakture { get; set; } = string.Empty;
        public string TipFakture { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Primalac { get; set; } = string.Empty;
        public double Iznos { get; set; }
        public DateOnly DatumSlanja { get; set; }
    }
}
