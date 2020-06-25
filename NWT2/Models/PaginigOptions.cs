using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class PaginigOptions
    {   
        [Range (1,999)]
        [System.ComponentModel.DefaultValue(20)]
        public int? Offset { get; set; }

        [Range(1,50)]
        [DefaultValue(20)]
        public int? Limit { get; set; }

    }
}
