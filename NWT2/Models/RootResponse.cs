using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class RootResponse:Resource
    {
        public Link Adrese { get; set; }

        public Link DetaljiNarudzbenica { get; set; }

        public Link Dodaci { get; set; }

        public Link EkstraDodaci { get; set; }

        public Link Kupci { get; set; }

        public Link NacinPlacanja { get; set; }

        public Link Narudzbenice { get; set; }

        public Link Pice { get; set; }

        public Link StatusDostave { get; set; }

        public Link TipoviVozila { get; set; }

        public Link Vozila { get; set; }

        public Link Zaposleni { get; set; }


    }
}
