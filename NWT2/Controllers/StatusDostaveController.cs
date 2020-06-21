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
    public class StatusDostaveController : ControllerBase
    {
        private readonly IStatusDostaveService _statusDostaveService;
        public StatusDostaveController(PicerijaDbContext context, IStatusDostaveService statusDostaveService)
        {
            _statusDostaveService = statusDostaveService;
        }

        [HttpGet (Name =nameof(GetStatusDostaveAsync))]
        public async Task<ActionResult<IEnumerable<StatusDostave>>> GetStatusDostaveAsync(CancellationToken ct)
        {
            var collection = await _statusDostaveService.GetStatusDostaveAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetStatusDostaveAsync));

            var resources = new Collection<Models.StatusDostave>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetStatusDostaveByIdAsync))]
        public async Task<ActionResult<StatusDostave>> GetStatusDostaveByIdAsync(Guid id,CancellationToken ct)
        {
            var statusDostave = await _statusDostaveService.GetStatusDostavebByIdAsync(id, ct);

            if (statusDostave == null)
            {
                return NotFound();
            }

            return Ok(statusDostave);
        }

        //// PUT: api/StatusDostave/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStatusDostave(Guid id, StatusDostave statusDostave)
        //{
        //    if (id != statusDostave.StatusDostaveID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(statusDostave).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StatusDostaveExists(id))
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

        //// POST: api/StatusDostave
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<StatusDostave>> PostStatusDostave(StatusDostave statusDostave)
        //{
        //    _context.StatusDostave_1.Add(statusDostave);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStatusDostave", new { id = statusDostave.StatusDostaveID }, statusDostave);
        //}

        //// DELETE: api/StatusDostave/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<StatusDostave>> DeleteStatusDostave(Guid id)
        //{
        //    var statusDostave = await _context.StatusDostave_1.FindAsync(id);
        //    if (statusDostave == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.StatusDostave_1.Remove(statusDostave);
        //    await _context.SaveChangesAsync();

        //    return statusDostave;
        //}

        //private bool StatusDostaveExists(Guid id)
        //{
        //    return _context.StatusDostave_1.Any(e => e.StatusDostaveID == id);
        //}
    }
}
