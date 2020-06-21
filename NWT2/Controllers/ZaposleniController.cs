using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NWT2.Models;
using NWT2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NWT2.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        protected readonly IZaposleniService _zaposleniService;

        public ZaposleniController(IZaposleniService zaposleniService)
        {
            _zaposleniService = zaposleniService;
        }

       
        [HttpGet(Name = nameof(GetZaposleniAsync))]
        public async Task<ActionResult<IEnumerable<Zaposlen>>> GetZaposleniAsync(CancellationToken ct)
        {
            var collection = await _zaposleniService.GetZaposleneAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetZaposleniAsync));

            var resources = new Collection<Models.Zaposlen>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }



        [HttpGet("{id}",Name =nameof(GetZaposlenogByIDAsync))]
        public async Task<ActionResult<Models.Zaposlen>> GetZaposlenogByIDAsync(Guid id, CancellationToken ct)
        {
            var zaposlen = await _zaposleniService.GetZaposlenByIdAsync(id, ct);

            if (zaposlen == null)
            {
                return NotFound();
            }

            return Ok(zaposlen);
        }

        // POST api/<ZaposleniController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ZaposleniController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ZaposleniController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
