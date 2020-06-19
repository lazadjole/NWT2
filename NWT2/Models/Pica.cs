using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Pica : Resource
    {

        public Guid PicaID { get; set; }
 
        public string NazivPice { get; set; }
  
        public string Kratak_opis { get; set; }

        public int Cena { get; set; }
    }
}
