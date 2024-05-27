using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class KontaktFormaModel
    {
            [Required(ErrorMessage = "Ime je obavezno")]
            public string Ime { get; set; }

            [Required(ErrorMessage = "Email je obavezan")]
            [EmailAddress(ErrorMessage = "Nevažeća email adresa")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Naslov je obavezan")]
            public string Naslov { get; set; }

            [Required(ErrorMessage = "Poruka je obavezna")]
            public string Poruka { get; set; }
    }
}

