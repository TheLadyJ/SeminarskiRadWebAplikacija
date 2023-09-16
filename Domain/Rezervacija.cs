using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; } = -1;
        public DateTime DatumVremeOd { get; set; }
        public DateTime DatumVremeDo { get; set; }
        public TipProslave TipProslave { get; set; }
        public int TipProslaveId { get; set; }
        public double UkupnaCena { get; set; }
        public Radnik Radnik { get; set; }
        public int RadnikId { get; set; }
        public Klijent Klijent { get; set; }
        public int KlijentId { get; set; }
        public Mesto Mesto { get; set; }
        public int MestoId { get; set; }
        public KeteringMeni KeteringMeni { get; set; }
        public int KeteringMeniId { get; set; }

        public List<Sto> Stolovi { get; set; }
    }
}
