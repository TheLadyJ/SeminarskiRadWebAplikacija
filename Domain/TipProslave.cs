using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja tip proslave.
    /// </summary>
    public class TipProslave
    {
        public int TipProslaveId { get; set; }
        public string NazivTipaProslave { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }
    }
}
