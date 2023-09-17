using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja sto. Sto se unosti od strane radnika i vezan je za odredjeno mesto.
    /// </summary>
    public class Sto
    {

        /// <summary>
        /// RbStola je jedinstveni identifikator stola. 
        /// </summary>
        /// <remarks>
        /// Automatski se dodeljuje vrednost ovom atributu prilikom kreiranja novog stola.
        /// </remarks>
        public int RbStola { get; set; }
        /// <summary>
        /// Kapacitet stola predstavlja broj ljudi koji moze sesti za tim stolom.
        /// </summary>
        public int Kapacitet { get; set; }
        /// <summary>
        /// Cena stola predstavlja cenu rezervisanja datog stola.
        /// </summary>
        public double CenaStola { get; set; }


        /// <summary>
        /// Proizvodjac stola.
        /// </summary>
        public Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacId { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        /// <summary>
        /// Mesto na kom se sto nalazi.
        /// </summary>
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
