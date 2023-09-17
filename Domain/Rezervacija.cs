using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja rezervaciju. Rezervaciju radnik moze da kreira, brise i menja nakon sto se uloguje na sistem.
    /// </summary>
    public class Rezervacija
    {
        /// <summary>
        /// Id Rezervacije
        /// </summary>
        /// <remark>
        /// Automatski se stvara prilikom dodavanja nove rezervacije.
        /// </remark>>
        public int RezervacijaId { get; set; }
        /// <summary>
        /// Datum i vreme pocetka proslave (rezervacije)
        /// </summary>
        public DateTime DatumVremeOd { get; set; }
        /// <summary>
        /// Datum i vreme zavrsetka proslave (rezervacije)
        /// </summary>
        public DateTime DatumVremeDo { get; set; }
        /// <summary>
        /// Tip proslave
        /// </summary>
        public TipProslave TipProslave { get; set; }
        public int TipProslaveId { get; set; }
        /// <summary>
        /// Ukupna cena rezervacije.
        /// </summary>
        public double UkupnaCena { get; set; }
        /// <summary>
        /// Radnik koji je kreirao rezervaciju.
        /// </summary>
        public Radnik Radnik { get; set; }
        public int RadnikId { get; set; }
        /// <summary>
        /// Klijent za koga je kreirana rezervacija.
        /// </summary>
        public Klijent Klijent { get; set; }
        public int KlijentId { get; set; }
        /// <summary>
        /// Mesto na kome se odvija proslava (rezervacija).
        /// </summary>
        /// <remarks>
        /// Stolovi rezervacije moraju biti sa istog mesta kao i sama rezervacija.
        /// </remarks>
        public Mesto Mesto { get; set; }
        public int MestoId { get; set; }
        /// <summary>
        /// Ketering meni za proslavu.
        /// </summary>
        public KeteringMeni KeteringMeni { get; set; }
        public int KeteringMeniId { get; set; }
        /// <summary>
        /// Lista stolova koji su pod rezervacijom.
        /// </summary>
        public List<Sto> Stolovi { get; set; }
    }
}
