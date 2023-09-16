using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class CreateKlijentViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Broj telefona nije korektnog formata. (do 10 cifara)")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
