using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjekatFinalni.Models
{
    public class LozinkaAdmin
    {
        public int Id { get; set; }

        [DisplayName("Nova lozinka:")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [DisplayName("Potvrdi lozinku:")]
        [DataType(DataType.Password)]
        [Compare("Lozinka", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string PotvrdiLozinku { get; set; }


    }
}