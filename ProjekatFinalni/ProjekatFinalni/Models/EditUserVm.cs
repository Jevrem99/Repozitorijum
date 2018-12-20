using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjekatFinalni.Models
{
    public class EditUserVm
    {
        public int Id { get; set; }

        [DisplayName("Korisnicko ime:")]
        public string Korisnickoime { get; set; }

        [DisplayName("Admin:")]
        public bool Admin { get; set; }

        [DisplayName("Gost:")]
        public bool Gost { get; set; }

        [DisplayName("Pravo za unos:")]
        public bool PravoUnosa { get; set; }
    }
}