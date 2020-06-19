using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class StatusDostave : Resource
    {
        public Guid StatusDostaveID { get; set; }

       
        public string NazivStatusa { get; set; }
    }
}
