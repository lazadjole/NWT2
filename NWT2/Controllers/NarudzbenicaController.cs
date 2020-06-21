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
    public class NarudzbenicaController : ControllerBase
    {

        private readonly INarudzbenicaService _narudzbenicaService;

        public NarudzbenicaController( INarudzbenicaService narudzbenicaService)
        {
            _narudzbenicaService = narudzbenicaService;
        }

        [HttpGet (Name =nameof(GetNarudzbeniceAsync))]
        public async Task<ActionResult<IEnumerable<Narudzbenica>>> GetNarudzbeniceAsync(CancellationToken ct)
        {
            var collection = await _narudzbenicaService.GetNarudzbeniceAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetNarudzbeniceAsync));

            var resources = new Collection<Models.Narudzbenica>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetNarudzbenicaByIdAsync))]
        public async Task<ActionResult<Narudzbenica>> GetNarudzbenicaByIdAsync(Guid id,CancellationToken ct)
        {
            var narudzbenica = await _narudzbenicaService.GetNarudzbenicaByIdAsync(id, ct);

            if (narudzbenica == null)
            {
                return NotFound();
            }

            return Ok(narudzbenica);
        }

        //// PUT: api/Narudzbenica/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNarudzbenica(Guid id, Narudzbenica narudzbenica)
        //{
        //    if (id != narudzbenica.NarudzbenicaID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(narudzbenica).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NarudzbenicaExists(id))
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

        //// POST: api/Narudzbenica
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Narudzbenica>> PostNarudzbenica(Narudzbenica narudzbenica)
        //{
        //    _context.Narudzbenica_1.Add(narudzbenica);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNarudzbenica", new { id = narudzbenica.NarudzbenicaID }, narudzbenica);
        //}

        //// DELETE: api/Narudzbenica/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Narudzbenica>> DeleteNarudzbenica(Guid id)
        //{
        //    var narudzbenica = await _context.Narudzbenica_1.FindAsync(id);
        //    if (narudzbenica == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Narudzbenica_1.Remove(narudzbenica);
        //    await _context.SaveChangesAsync();

        //    return narudzbenica;
        //}

        //private bool NarudzbenicaExists(Guid id)
        //{
        //    return _context.Narudzbenica_1.Any(e => e.NarudzbenicaID == id);
        //}
    }
}
