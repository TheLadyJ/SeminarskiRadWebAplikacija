using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVC.Models
{
    public class CreateStoViewModel
    {
        public int Kapacitet { get; set; }
        public double CenaStola { get; set; }
        public int ProizvodjacId { get; set; }
        public int MestoId { get; set; }

        public List<SelectListItem> Mesta { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Proizvodjaci { get; set; } = new List<SelectListItem>();
    }
}
