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
    public class VoziloController : ControllerBase
    {
        private readonly IVoziloService _voziloService;

        public VoziloController(IVoziloService voziloService)
        {
            _voziloService = voziloService;
        }

        [HttpGet (Name =nameof(GetVozilaAsync))]
        public async Task<ActionResult<IEnumerable<Vozilo>>> GetVozilaAsync(CancellationToken ct)
        {
            var collection = await _voziloService.GetVoziloAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetVozilaAsync));

            var resources = new Collection<Models.Vozilo>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}", Name =nameof(GetVoziloByIdAsync))]
        public async Task<ActionResult<Models.Vozilo>> GetVoziloByIdAsync(Guid id,CancellationToken ct)
        {

            var vozilo = await _voziloService.GetVoziloByIdAsync(id, ct);

            if (vozilo == null)
            {
                return NotFound();
            }

            return Ok(vozilo);
        }

        // POST api/<VoziloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VoziloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VoziloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
