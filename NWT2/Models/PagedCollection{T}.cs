using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class PagedCollection<T>:Collection<T>
    {
        [JsonProperty(NullValueHandling =NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Size { get; set; }


        
    }
}
