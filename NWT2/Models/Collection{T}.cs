using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class Collection<T>:Resource
    {
        public T[] Value { get; set; }
    }
}
