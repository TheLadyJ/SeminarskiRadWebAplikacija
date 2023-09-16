using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class KeteringFirma
    {
        public int KeteringFirmaId { get; set; }
        public string NazivFirme { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }

        public List<KeteringMeni> Meniji { get; set; }
    }
}
