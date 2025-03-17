using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProgramZaRacunovodstvo.Models
{
    public class Dokument
    {
        public string imeFajla { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public byte[] fajl { get; set; }

        public Dokument(string filePath)
        {
            Path = filePath;
            imeFajla = System.IO.Path.GetFileName(filePath);
            fajl = File.ReadAllBytes(Path);
        }

    }
}
