using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Vozilo :Resource
    {
        public Guid VoziloID { get; set; }

        public int TipVozilaID { get; set; }
        public string MarkaVozila { get; set; }
        public string EvidencioniBr { get; set; }


        public string DetaljiVozila { get; set; }
    }
}
