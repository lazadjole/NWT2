using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public abstract class Resource:Link
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Link Self { get; set; }
    }
}
