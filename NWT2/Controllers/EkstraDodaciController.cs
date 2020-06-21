using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EkstraDodaciController : ControllerBase
    {
        private readonly IEkstraDodaciService _ekstraDodaciService;

        public EkstraDodaciController(IEkstraDodaciService ekstraDodaciService)
        {
            _ekstraDodaciService = ekstraDodaciService;
        }


        [HttpGet (Name =nameof(GetEkstraDodaciAsync))]
        public async Task<ActionResult<IEnumerable< Models.EkstraDodaci>>> GetEkstraDodaciAsync(CancellationToken ct)
        {
            var collection = await _ekstraDodaciService.GetEkstraDodaciAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetEkstraDodaciAsync));

            var resources = new Collection<Models.EkstraDodaci>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}", Name = nameof(GetEkstraDodaciByIDAsync))]
        public async Task<ActionResult<Models.EkstraDodaci>> GetEkstraDodaciByIDAsync(Guid id, CancellationToken ct)
        {
            var resource = await _ekstraDodaciService.GetEkstraDodaciByIdAsync(id, ct);
            if (resource == null) return NotFound();

            return Ok(resource);
        }

        // POST api/<EkstraDodaciController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EkstraDodaciController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EkstraDodaciController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
