using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Sto
    {
        public int RbStola { get; set; }
        public int Kapacitet { get; set; }
        public double CenaStola { get; set; }


        public Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacId { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }


        public Mesto Mesto { get; set; }
        public int MestoId { get; set; }

        public override string? ToString()
        {
            return $"Kapacitet: {Kapacitet}, Cena stola: {CenaStola}, Proizvođač: {Proizvodjac}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Sto s)
            {
                return s.RbStola == RbStola;
            }
            return false;
        }
    }
}
