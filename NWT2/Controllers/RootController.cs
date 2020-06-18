using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NWT2.Controllers
{   [Route("/")]
    public class RootController : Controller
    {   
        [HttpGet(Name=nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot),null)
            };

            return Ok( response);
            
        }
    }
}