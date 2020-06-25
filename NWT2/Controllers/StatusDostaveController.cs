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
        public async Task<ActionResult<IEnumerable<StatusDostave>>> GetStatusDostaveAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            var collection = await _statusDostaveService.GetStatusDostaveAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetStatusDostaveAsync));

            var resources = new PagedCollection<Models.StatusDostave>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
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



        [HttpPost (Name =nameof(PostStatusDostaveAsync))]
        public async Task<ActionResult<StatusDostave>> PostStatusDostaveAsync(CancellationToken ct, [FromBody] Entities.StatusDostave statusBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _statusDostaveService.CreateStatusDostaveAsync(ct,statusBody.NazivStatusa);

            return Created(Url.Link(nameof(Controllers.StatusDostaveController.GetStatusDostaveByIdAsync), new { id = resourceID }), null);
        }

        [HttpDelete("{id}", Name =nameof(DeleteStatusDostaveAsync))]
        public async Task<ActionResult<StatusDostave>> DeleteStatusDostaveAsync(CancellationToken ct,Guid id)
        {
            await _statusDostaveService.DeleteStatusDostaveAsync(ct, id);
            return NoContent();
        }


    }
}
