﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Zaposlen :Resource
    {
        public Guid ZaposleniId { get; set; }

 
        public string Ime { get; set; }

        public String Prezime { get; set; }

     
        public Guid AdresaID { get; set; }

        public string BrojTelefona { get; set; }
    }
}
