using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class DetaljiNarudzbenice :Resource
    {
        public Guid DetaljiNarudzbeniceID { get; set; }

       
        public int PicaID { get; set; }

       
        public int NarudzbenicaID { get; set; }

     
        public int Kolicina { get; set; }
    }
}
