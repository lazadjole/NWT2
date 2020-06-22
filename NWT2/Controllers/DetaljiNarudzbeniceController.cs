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
