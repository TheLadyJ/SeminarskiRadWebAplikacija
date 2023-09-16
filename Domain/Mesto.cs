using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Mesto
    {
        public int MestoId { get; set; }
        public string Grad { get; set; }
        public string PostanskiBroj { get; set; }
        public string Adresa { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public List<Sto> Stolovi { get; set; }
    }
}
