using System;

namespace NWT2.Models
{
    public class Adresa:Resource
    {

        public Guid AdresaID { get; set; }

        public string Ulica { get; set; }

        public int Broj { get; set; }

        public string Grad { get; set; }

    }
}
