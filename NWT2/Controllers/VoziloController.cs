using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NWT2.Models;
using NWT2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NWT2.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VoziloController : ControllerBase
    {
        private readonly IVoziloService _voziloService;

        public VoziloController(IVoziloService voziloService)
        {
            _voziloService = voziloService;
        }

        [HttpGet (Name =nameof(GetVozilaAsync))]
        public async Task<ActionResult<IEnumerable<Vozilo>>> GetVozilaAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            var collection = await _voziloService.GetVoziloAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetVozilaAsync));

            var resources = new PagedCollection<Models.Vozilo>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
            };

            return Ok(resources);
        }

        [HttpGet("{id}", Name =nameof(GetVoziloByIdAsync))]
        public async Task<ActionResult<Models.Vozilo>> GetVoziloByIdAsync(Guid id,CancellationToken ct)
        {

            var vozilo = await _voziloService.GetVoziloByIdAsync(id, ct);

            if (vozilo == null)
            {
                return NotFound();
            }

            return Ok(vozilo);
        }
        [HttpPost(Name = nameof(PostVoziloaAsync))]
        public async Task<ActionResult<Vozilo>> PostVoziloaAsync(CancellationToken ct, [FromBody] Entities.Vozilo voziloBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _voziloService.CreateVoziloAsync(ct, voziloBody.FKTipVozilaID,voziloBody.EvidencioniBr,voziloBody.MarkaVozila,voziloBody.DetaljiVozila);

            return Created(Url.Link(nameof(Controllers.VoziloController.GetVoziloByIdAsync), new { id = resourceID }), null);

        }



        [HttpDelete("{id}", Name = (nameof(DeleteVoziloAsync)))]
        public async Task<IActionResult> DeleteVoziloAsync(CancellationToken ct, Guid id)
        {
            await _voziloService.DeleteVoziloAsync(ct, id);
            return NoContent();
        }
    }
}
