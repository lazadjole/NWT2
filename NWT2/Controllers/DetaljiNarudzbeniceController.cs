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
    public class DetaljiNarudzbeniceController : ControllerBase
    {
        private readonly IDetaljiNarudzbeniceService _detaljiNarudzbeniceService;

        public DetaljiNarudzbeniceController(IDetaljiNarudzbeniceService detaljiNarudzbeniceService)
        {
            _detaljiNarudzbeniceService = detaljiNarudzbeniceService;
        }

       [HttpGet (Name =nameof(GetDetaljiNarudzbeniceAsync))]
        public async Task<ActionResult<IEnumerable<DetaljiNarudzbenice>>> GetDetaljiNarudzbeniceAsync(CancellationToken ct)
        {
            var collection = await _detaljiNarudzbeniceService.GetDetaljiNarudzbeniceAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetDetaljiNarudzbeniceAsync));

            var resources = new Collection<Models.DetaljiNarudzbenice>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }


        [HttpGet("{id}",Name =nameof(GetDetaljiNarudzbeniceByIDasync))]
        public async Task<ActionResult<DetaljiNarudzbenice>> GetDetaljiNarudzbeniceByIDasync(Guid id,CancellationToken ct)
        {
            var resource = await _detaljiNarudzbeniceService.GetDetaljiNarudzbeniceByIdAsync(id, ct);
            if (resource == null) return NotFound();

            return Ok(resource);
        }

    //    // PUT: api/DetaljiNarudzbenice/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutDetaljiNarudzbenice(Guid id, DetaljiNarudzbenice detaljiNarudzbenice)
    //    {
    //        if (id != detaljiNarudzbenice.DetaljiNarudzbeniceID)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(detaljiNarudzbenice).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!DetaljiNarudzbeniceExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/DetaljiNarudzbenice
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    //    [HttpPost]
    //    public async Task<ActionResult<DetaljiNarudzbenice>> PostDetaljiNarudzbenice(DetaljiNarudzbenice detaljiNarudzbenice)
    //    {
    //        _context.DetaljiNarudzbenice_1.Add(detaljiNarudzbenice);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetDetaljiNarudzbenice", new { id = detaljiNarudzbenice.DetaljiNarudzbeniceID }, detaljiNarudzbenice);
    //    }

    //    // DELETE: api/DetaljiNarudzbenice/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<DetaljiNarudzbenice>> DeleteDetaljiNarudzbenice(Guid id)
    //    {
    //        var detaljiNarudzbenice = await _context.DetaljiNarudzbenice_1.FindAsync(id);
    //        if (detaljiNarudzbenice == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.DetaljiNarudzbenice_1.Remove(detaljiNarudzbenice);
    //        await _context.SaveChangesAsync();

    //        return detaljiNarudzbenice;
    //    }

    //    private bool DetaljiNarudzbeniceExists(Guid id)
    //    {
    //        return _context.DetaljiNarudzbenice_1.Any(e => e.DetaljiNarudzbeniceID == id);
    //    }
    }
}
