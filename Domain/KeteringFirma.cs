using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Klasa koja predstavlja ketering firmu. Na osnovu ketering firme, izlistavaju se ketering meniji firme i bira se meni za proslavu (rezervaciju).
    /// </summary>
    public class KeteringFirma
    {
        public int KeteringFirmaId { get; set; }
        public string NazivFirme { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }

        public List<KeteringMeni> Meniji { get; set; }

        public override string? ToString()
        {
            return $"{NazivFirme} ({Telefon} / {Email})";
        }
    }
}
