using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Adresa
    {

        public Guid AdresaID { get; set; }

        public string Ulica { get; set; }

        public int Broj { get; set; }

        public string Grad { get; set; }

        public string PostanskiBroj { get; set; }
    }
}
