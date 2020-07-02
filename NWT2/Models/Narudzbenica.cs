using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Narudzbenica :Resource
    {
        public Guid NarudzbenicaID { get; set; }

        public string BrojNaruDzbenice { get; set; }

        public Guid KupacID { get; set; }

        public Guid ZaposleniId { get; set; }

        public Guid StatusDostaveID { get; set; }

        public Guid NacinPlacanjaID { get; set; }

        public DateTime datumPrijema { get; set; }

        public Guid VoziloID { get; set; }
    }
}
