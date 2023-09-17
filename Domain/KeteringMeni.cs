using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja ketering meni koji se sluzi na proslavi.
    /// </summary>
    public class KeteringMeni
    {
        public int KeteringMeniId { get; set; }
        public string Predjelo { get; set; }
        public string GlavnoJelo { get; set; }
        public string Dezert { get; set; }
        public double CenaHranePoOsobi { get; set; }

        public KeteringFirma KeteringFirma { get; set; }
        public int KeteringFirmaId { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public override string? ToString()
        {
            return $"Predjelo: {Predjelo}, Glavno jelo: {GlavnoJelo}, Dezert: {Dezert}, Cena po osobi: {CenaHranePoOsobi}";
        }
    }
}
