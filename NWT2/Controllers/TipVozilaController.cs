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
    public class TipVozilaController : ControllerBase
    {

        private readonly ITipVozilaService _tipVozilaService;

        public TipVozilaController( ITipVozilaService tipVozilaService)
        {
            _tipVozilaService = tipVozilaService;
        }

        [HttpGet (Name =nameof(GetTipVozilaAsync))]
        public async Task<ActionResult<IEnumerable<TipVozila>>> GetTipVozilaAsync(CancellationToken ct)
        {
            var collection = await _tipVozilaService.GetTipVozilaAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetTipVozilaAsync));

            var resources = new Collection<Models.TipVozila>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);

        }

        [HttpGet("{id}",Name =nameof(GetTipVozilaByIdAsync))]
        public async Task<ActionResult<TipVozila>> GetTipVozilaByIdAsync(Guid id,CancellationToken ct)
        {
            var tipVozila = await _tipVozilaService.GetTipVozilaByIdAsync(id, ct);

            if (tipVozila == null)
            {
                return NotFound();
            }

            return Ok(tipVozila);
        }

        //// PUT: api/TipVozila/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTipVozila(Guid id, TipVozila tipVozila)
        //{
        //    if (id != tipVozila.TipVozilaID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tipVozila).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipVozilaExists(id))
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

        //// POST: api/TipVozila
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<TipVozila>> PostTipVozila(TipVozila tipVozila)
        //{
        //    _context.TipVozila_1.Add(tipVozila);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTipVozila", new { id = tipVozila.TipVozilaID }, tipVozila);
        //}

        //// DELETE: api/TipVozila/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TipVozila>> DeleteTipVozila(Guid id)
        //{
        //    var tipVozila = await _context.TipVozila_1.FindAsync(id);
        //    if (tipVozila == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TipVozila_1.Remove(tipVozila);
        //    await _context.SaveChangesAsync();

        //    return tipVozila;
        //}

        //private bool TipVozilaExists(Guid id)
        //{
        //    return _context.TipVozila_1.Any(e => e.TipVozilaID == id);
        //}
    }
}
