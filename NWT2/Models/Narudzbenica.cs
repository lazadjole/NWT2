using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Narudzbenica :Resource
    {
        public Guid NarudzbenicaID { get; set; }

        public string BrojNaruDzbenice { get; set; }

        public string imeKupca { get; set; }


        public  string prezimeKupca { get; set; }

        public string imeZaposleng { get; set; }

        public  string prezimeZaposlenog { get; set; }

        public string statusDostave { get; set; }

        public string NacinPlacanja { get; set; }

        public DateTime datumPrijema { get; set; }

        public string evidencioniBrVozila { get; set; }
    }
}
