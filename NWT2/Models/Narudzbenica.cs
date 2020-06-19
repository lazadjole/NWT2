using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Narudzbenica : Resource
    {
        public Guid NarudzbenicaID { get; set; }

        public string BrojNaruDzbenice { get; set; }

        public int KupacID { get; set; }

        public int ZaposleniId { get; set; }

        public int StatusDostaveID { get; set; }

        public int NacinPlacanjaID { get; set; }

        public DateTime datumPrijema { get; set; }

        public int VoziloID { get; set; }
    }
}
