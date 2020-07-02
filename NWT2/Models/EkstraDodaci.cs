using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class EkstraDodaci : Resource
    {
        public Guid Ekstra_dodaciID { get; set; }

        public Guid DodatakID { get; set; }

        public Guid DetaljiNarudzbeniceID { get; set; }
    }
}
