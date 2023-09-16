using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Proizvodjac
    {
        public int ProizvodjacId { get; set; }
        public string NazivProizvodjaca { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public List<Sto> Stolovi { get; set; }

        public override string? ToString()
        {
            return NazivProizvodjaca + " (" + Telefon + " / " + Email + ")";
        }
    }
}
