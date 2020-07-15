using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class DetaljiNarudzbenice :Resource
    {
        public Guid DetaljiNarudzbeniceID { get; set; }

        public string NazivPice { get; set; }

        public string BrojNarudzbenice { get; set; }

        public int Kolicina { get; set; }
    }
}
