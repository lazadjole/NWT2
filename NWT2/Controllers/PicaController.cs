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
    public class PicaController : ControllerBase
    {
        private readonly IPicaService _ipicaService;

        public PicaController( IPicaService ipicaService)
        {
            _ipicaService = ipicaService;
        }

        [HttpGet (Name =nameof(GetPiceAsync))]
        public async Task<ActionResult<IEnumerable<Pica>>> GetPiceAsync(CancellationToken ct)
        {
            var collection = await _ipicaService.GetPiceAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetPiceAsync));

            var resources = new Collection<Models.Pica>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetPicaByIdAsync))]
        public async Task<ActionResult<Pica>> GetPicaByIdAsync(Guid id,CancellationToken ct)
        {
            var pica = await _ipicaService.GetPicaByIdAsync(id, ct);

            if (pica == null)
            {
                return NotFound();
            }

            return Ok(pica);
        }

        //// PUT: api/Pica/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPica(Guid id, Pica pica)
        //{
        //    if (id != pica.PicaID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pica).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PicaExists(id))
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

        //// POST: api/Pica
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Pica>> PostPica(Pica pica)
        //{
        //    _context.Pica.Add(pica);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPica", new { id = pica.PicaID }, pica);
        //}

        //// DELETE: api/Pica/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Pica>> DeletePica(Guid id)
        //{
        //    var pica = await _context.Pica.FindAsync(id);
        //    if (pica == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pica.Remove(pica);
        //    await _context.SaveChangesAsync();

        //    return pica;
        //}

        //private bool PicaExists(Guid id)
        //{
        //    return _context.Pica.Any(e => e.PicaID == id);
        //}
    }
}
