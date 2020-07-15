using NWT2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class DetaljiNarudzbenicePom
    {
       public Entities.DetaljiNarudzbenice detaljiNarudzbenice { get; set; }
       public Entities.Pica pica { get; set; }
       public Entities.Narudzbenica Narudzbenica { get; set; }
    }
}
