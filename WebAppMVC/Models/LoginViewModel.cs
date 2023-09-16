using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
    }
}
