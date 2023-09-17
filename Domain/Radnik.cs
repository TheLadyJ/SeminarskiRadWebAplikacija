using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Radnik : IdentityUser<int>
    {
        public int RadnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }


    }
}
