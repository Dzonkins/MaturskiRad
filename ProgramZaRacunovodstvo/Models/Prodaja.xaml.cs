﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramZaRacunovodstvo.Models
{
    public class Prodaja
    {
        public string BrojFakture { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Primalac { get; set; } = string.Empty;
        public decimal Osnovica { get; set; }

        public decimal Pdv { get; set; }
        public decimal Ukupno { get; set; }
        public DateOnly DatumSlanja { get; set; }

        public string OsnovicaRSD => $"{Osnovica:N2} RSD";
        public string PdvRSD => $"{Pdv:N2} RSD";
        public string UkupnoRSD => $"{Ukupno:N2} RSD";
    }
}
