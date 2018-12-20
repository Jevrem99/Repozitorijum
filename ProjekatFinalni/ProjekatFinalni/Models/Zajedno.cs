using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekatFinalni.Models
{
    public class Zajedno
    {

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string RadnoMesto { get; set; }
        public int SkolaID { get; set; }
        public int KontaktID { get; set; }

        
        public string NazivSkole { get; set; }
        public string AdresaRegistracije { get; set; }
        public string Opstina { get; set; }
        public Nullable<int> PostanskiBroj { get; set; }
        public string MaticniBrojSkole { get; set; }
        public string PIB { get; set; }
        public string BrojRacunaSkole { get; set; }
        public string WebStranica { get; set; }
        public byte[] Fotografija { get; set; }
        public string Beleska { get; set; }
    }
}