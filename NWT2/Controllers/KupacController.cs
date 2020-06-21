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
    public class KupacController : ControllerBase
    {

        private readonly IkupacService _kupacService;

        public KupacController( IkupacService kupacService)
        {
            _kupacService = kupacService;
        }

        [HttpGet (Name =nameof(GetKupciAsync))]
        public async Task<ActionResult<IEnumerable<Kupac>>> GetKupciAsync(CancellationToken ct)
        {
            var collection = await _kupacService.GetKupaceAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetKupciAsync));

            var resources = new Collection<Models.Kupac>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetKupacByIdAsync))]
        public async Task<ActionResult<Kupac>> GetKupacByIdAsync(Guid id,CancellationToken ct)
        {
            var kupac = await _kupacService.GetKupacByIdAsync(id, ct);

            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(kupac);
        }

        //// PUT: api/Kupac/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutKupac(Guid id, Kupac kupac)
        //{
        //    if (id != kupac.KupacID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(kupac).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KupacExists(id))
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

        //// POST: api/Kupac
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Kupac>> PostKupac(Kupac kupac)
        //{
        //    _context.Kupac.Add(kupac);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetKupac", new { id = kupac.KupacID }, kupac);
        //}

        //// DELETE: api/Kupac/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Kupac>> DeleteKupac(Guid id)
        //{
        //    var kupac = await _context.Kupac.FindAsync(id);
        //    if (kupac == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Kupac.Remove(kupac);
        //    await _context.SaveChangesAsync();

        //    return kupac;
        //}

        //private bool KupacExists(Guid id)
        //{
        //    return _context.Kupac.Any(e => e.KupacID == id);
        //}
    }
}
