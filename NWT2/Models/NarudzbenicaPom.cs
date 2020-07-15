using NWT2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class NarudzbenicaPom
    {
       public Entities.Narudzbenica Narudzbenica { get; set; }

        public Entities.Kupac Kupac { get; set; }

        public Entities.Zaposleni Zaposleni { get; set; }

        public Entities.StatusDostave StatusDostave { get; set; }

        public Entities.Vozilo Vozilo { get; set; }
    }
}
