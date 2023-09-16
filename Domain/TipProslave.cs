using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipProslave
    {
        public int TipProslaveId { get; set; }
        public string NazivTipaProslave { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }
    }
}
