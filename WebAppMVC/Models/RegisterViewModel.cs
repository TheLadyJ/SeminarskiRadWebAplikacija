﻿using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string KorisnickoIme { get; set; }


        [Required(ErrorMessage = "Obavezno polje")]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [Compare("Lozinka")]
        public string ProveraLozinke { get; set; }
    }
}
