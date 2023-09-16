using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Ime { get; set; }
        [Required]

        public string Prezime { get; set; }
        [Required]

        public string KorisnickoIme { get; set; }

        [Required]

        public string Lozinka { get; set; }
        [Required]


        [Compare("Lozinka")]
        public string ProveraLozinke { get; set; }
    }
}
