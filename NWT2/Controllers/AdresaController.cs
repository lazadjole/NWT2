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
    public class AdresaController : ControllerBase
    {

        private readonly IAdresaService _adresaService;
        public AdresaController(IAdresaService adresaService)
        {
            _adresaService = adresaService;
        }

        [HttpGet (Name =nameof(GetAdresaAsync))]
        public async Task<ActionResult<IEnumerable<Adresa>>> GetAdresaAsync(CancellationToken ct)
        {
            var collection = await _adresaService.GetAdreseAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetAdresaAsync));

            var resources = new Collection<Models.Adresa>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetAdresaByIDAsync))]
        public async Task<ActionResult<Adresa>> GetAdresaByIDAsync(Guid id,CancellationToken ct)
        {


            var adresa = await _adresaService.GetAdresaByIdAsync(id, ct);

            if (adresa == null)
            {
                return NotFound();
            }

            return Ok(adresa);
        }

        //// PUT: api/Adresa/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdresa(Guid id, Adresa adresa)
        //{
        //    if (id != adresa.AdresaID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(adresa).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdresaExists(id))
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

        //// POST: api/Adresa
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Adresa>> PostAdresa(Adresa adresa)
        //{
        //    _context.Adresa.Add(adresa);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAdresa", new { id = adresa.AdresaID }, adresa);
        //}

        //// DELETE: api/Adresa/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Adresa>> DeleteAdresa(Guid id)
        //{
        //    var adresa = await _context.Adresa.FindAsync(id);
        //    if (adresa == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Adresa.Remove(adresa);
        //    await _context.SaveChangesAsync();

        //    return adresa;
        //}

        //private bool AdresaExists(Guid id)
        //{
        //    return _context.Adresa.Any(e => e.AdresaID == id);
        //}
    }
}
