using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja klijenta. Klijent se unosi od strane radnika kako bi se mogla kreirati rezervacija za njega.
    /// </summary>
    public class Klijent
    {
        /// <summary>
        /// Id klijenta
        /// </summary>
        /// <remark>
        /// Automatski se stvara prilikom dodavanja novog klijenta.
        /// </remark>>
        public int KlijentId { get; set; }
        /// <summary>
        /// Ime klijenta
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime klijenta
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Telefon klijenta
        /// </summary>
        public string Telefon { get; set; }
        /// <summary>
        /// Email klijenta
        /// </summary>
        public string Email { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public override string? ToString()
        {
            return $"{Ime} {Prezime} ({Telefon} / {Email})";
        }

    }
}
