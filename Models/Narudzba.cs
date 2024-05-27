using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Projekt.Models
{
    [Table("hrana")]
    public class Narudzba
    {
        [Required(ErrorMessage = "Narudzba ID je obavezan podatak")]
        [Key]
        [Display(Name = "Narudzba ID")]
        public int Id_narudzba { get; set; }

        [Required(ErrorMessage = "Ime hrane je obavezan podatak")]
        [Display(Name = "Hrana")]
        public string Ime_hrana { get; set; }

        [Required(ErrorMessage = "Ime pića je obavezan podatak")]
        [Display(Name = "Piće")]
        public string Ime_pice { get; set; }

        [Required(ErrorMessage = "Adresa je obavezan podatak")]
        [Display(Name = "Adresa")]
        public string Ime_adresa { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezan podatak")]
        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "Broj telefona mora započeti s '09' i imati ukupno 10 znamenki")]
        public string Ime_mobitel { get; set; }
    }
}
