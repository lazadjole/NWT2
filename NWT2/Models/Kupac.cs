﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Kupac
    {
        
        public Guid KupacID { get; set; }


        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Telefon { get; set; }
       
        public int AdresaID { get; set; }
    }
}