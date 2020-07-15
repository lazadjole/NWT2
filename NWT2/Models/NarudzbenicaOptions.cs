using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class NarudzbenicaOptions
    {
        public string imeZaposleng { get; set; }

        public string prezimeZaposlenog { get; set; }

        public string statusDostave { get; set; }

        public DateTime? datumPrijema { get; set; }
    }
}
