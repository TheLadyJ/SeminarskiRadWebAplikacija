using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class CreateRezervacijaViewModel : IValidatableObject
    {
        public string DatumVremeOd { get; set; }
        public string DatumVremeDo { get; set; }
        public List<SelectListItem> TipoviProslave { get; set; } = new List<SelectListItem>();
        public int TipProslaveId { get; set; }
        public double UkupnaCena { get; set; }
        public List<SelectListItem> Radnici { get; set; } = new List<SelectListItem>();
        public int RadnikId { get; set; }
        public List<SelectListItem> Klijenti { get; set; } = new List<SelectListItem>();
        public int KlijentId { get; set; }
        public List<SelectListItem> Mesta { get; set; } = new List<SelectListItem>();
        public int MestoId { get; set; }
        public List<SelectListItem> KeteringFirme { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> KeteringMeniji { get; set; } = new List<SelectListItem>();
        public int KeteringMeniId { get; set; }

        public List<SelectListItem> Stolovi { get; set; } = new List<SelectListItem>();
        public List<StoViewModel> RezervisaniStolovi { get; set; } = new List<StoViewModel>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (RezervisaniStolovi.Count == 0)
            {
                results.Add(new ValidationResult("Rezervacija mora da ima bar jedan sto u listi rezervisanih stolova"));
            }
            else if (RezervisaniStolovi.Select(rs => rs.RbStola).Distinct().Count() != RezervisaniStolovi.Count())
            {
                results.Add(new ValidationResult("Jedan sto se ne moze ponavljati u listi rezervisanih stolova"));
            }
            return results;
        }
    }
}
