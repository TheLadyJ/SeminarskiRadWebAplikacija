using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Lozinka { get; set; }
    }
}
