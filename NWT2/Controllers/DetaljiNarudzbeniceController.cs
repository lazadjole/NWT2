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
        public async Task<ActionResult<IEnumerable<DetaljiNarudzbenice>>> GetDetaljiNarudzbeniceAsync(CancellationToken ct,[FromQuery] PaginigOptions paginigOptions)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;
            var collection = await _detaljiNarudzbeniceService.GetDetaljiNarudzbeniceAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetDetaljiNarudzbeniceAsync));

            var resources = new PagedCollection<Models.DetaljiNarudzbenice>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
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


        [HttpPost(Name = nameof(PostDetaljiNarudzbeniceAsync))]
        public async Task<ActionResult<DetaljiNarudzbenice>> PostDetaljiNarudzbeniceAsync(CancellationToken ct, [FromBody] Entities.DetaljiNarudzbenice detaljiNarudzbenice)
        {

            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _detaljiNarudzbeniceService.PostDetaljiNarudzbeniceAsync(ct, detaljiNarudzbenice.FKPicaID, detaljiNarudzbenice.FKNarudzbenicaID, detaljiNarudzbenice.Kolicina);

            return Created(Url.Link(nameof(Controllers.DetaljiNarudzbeniceController.GetDetaljiNarudzbeniceByIDasync), new { id = resourceID }), null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetaljiNarudzbenice>> DeleteDetaljiNarudzbeniceAsync(Guid id,CancellationToken ct)
        {

            await _detaljiNarudzbeniceService.DeleteDetaljiNarudzbeniceAsync(ct, id);

            return NoContent();
        }


    }
}
