using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja radnika. Za radnika je napravljena aplikacija i on kad se prijavi moze vrsiti sistemske operacije
    /// </summary>
    public class Radnik : IdentityUser<int>
    {
        /// <summary>
        /// Id radnika
        /// </summary>
        /// <remark>
        /// Automatski se stvara prilikom dodavanja novog radnika.
        /// </remark>>

        public int RadnikId { get; set; }
        /// <summary>
        /// Ime radnika
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime radnika
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Korisnicko ime radnika
        /// </summary>
        public string KorisnickoIme { get; set; }
        /// <summary>
        /// Lozinka radnika
        /// </summary>
        public string Lozinka { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }


    }
}
