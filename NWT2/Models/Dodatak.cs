using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Dodatak : Resource
    {
        public Guid DodatakID { get; set; }

        public string Naziv_dodatka { get; set; }

        public int Cena { get; set; }
    }
}
