﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Kupac :Resource
    {
        
        public Guid KupacID { get; set; }


        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Telefon { get; set; }
       
        public string Grad { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
    }
}
