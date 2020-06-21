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
    public class DodatakController : ControllerBase
    {
        private readonly IDodatakService _dodatakService;

        public DodatakController(IDodatakService dodatakService)
        {
            _dodatakService = dodatakService;
        }

        [HttpGet (Name =nameof(GetDodaciAsync))]
        public async Task<ActionResult<IEnumerable<Dodatak>>> GetDodaciAsync(CancellationToken ct)
        {
            var collection = await _dodatakService.GetDodaciAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetDodaciAsync));

            var resources = new Collection<Models.Dodatak>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dodatak>> GetDodatakByIdAsync(Guid id,CancellationToken ct)
        {

            var resource =await _dodatakService.GetDodatakByIdAsync(id,ct);
            if (resource == null) return NotFound();
            return Ok(resource);

        }

        //// PUT: api/Dodatak/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDodatak(Guid id, Dodatak dodatak)
        //{
        //    if (id != dodatak.DodatakID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dodatak).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DodatakExists(id))
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

        //// POST: api/Dodatak
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Dodatak>> PostDodatak(Dodatak dodatak)
        //{
        //    _context.Dodatak.Add(dodatak);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDodatak", new { id = dodatak.DodatakID }, dodatak);
        //}

        //// DELETE: api/Dodatak/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Dodatak>> DeleteDodatak(Guid id)
        //{
        //    var dodatak = await _context.Dodatak.FindAsync(id);
        //    if (dodatak == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Dodatak.Remove(dodatak);
        //    await _context.SaveChangesAsync();

        //    return dodatak;
        //}

        //private bool DodatakExists(Guid id)
        //{
        //    return _context.Dodatak.Any(e => e.DodatakID == id);
        //}
    }
}
