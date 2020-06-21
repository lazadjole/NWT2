using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using NWT2.Services;

namespace NWT2.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class NacinPlacanjaController : ControllerBase
    {

        private readonly INacinPlacanjaService _nacinPlacanjaService;

        public NacinPlacanjaController( INacinPlacanjaService nacinPlacanjaService)
        {
            _nacinPlacanjaService = nacinPlacanjaService;
        }

        [HttpGet (Name =nameof(GetNacinPlacanjaAsync))]
        public async Task<ActionResult<IEnumerable<NacinPlacanja>>> GetNacinPlacanjaAsync(CancellationToken ct)
        {
            var collection = await _nacinPlacanjaService.GetNacinPlacanjaAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetNacinPlacanjaAsync));

            var resources = new Collection<Models.NacinPlacanja>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetNacinPlacanjaByIdAsync))]
        public async Task<ActionResult<NacinPlacanja>> GetNacinPlacanjaByIdAsync(Guid id,CancellationToken ct)
        {
            var nacinPlacanja = await _nacinPlacanjaService.GetNacinPlacanjaById(id, ct);

            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return Ok(nacinPlacanja);
        }

        //// PUT: api/NacinPlacanja/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNacinPlacanja(Guid id, NacinPlacanja nacinPlacanja)
        //{
        //    if (id != nacinPlacanja.NacinPlacanjaID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(nacinPlacanja).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NacinPlacanjaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/NacinPlacanja
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<NacinPlacanja>> PostNacinPlacanja(NacinPlacanja nacinPlacanja)
        //{
        //    _context.NacinPlacanja_1.Add(nacinPlacanja);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNacinPlacanja", new { id = nacinPlacanja.NacinPlacanjaID }, nacinPlacanja);
        //}

        //// DELETE: api/NacinPlacanja/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<NacinPlacanja>> DeleteNacinPlacanja(Guid id)
        //{
        //    var nacinPlacanja = await _context.NacinPlacanja_1.FindAsync(id);
        //    if (nacinPlacanja == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.NacinPlacanja_1.Remove(nacinPlacanja);
        //    await _context.SaveChangesAsync();

        //    return nacinPlacanja;
        //}

        //private bool NacinPlacanjaExists(Guid id)
        //{
        //    return _context.NacinPlacanja_1.Any(e => e.NacinPlacanjaID == id);
        //}
    }
}
