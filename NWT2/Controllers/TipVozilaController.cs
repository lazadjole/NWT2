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




        [HttpPost (Name =nameof(PostTipVozilaAsync))]
        public async Task<ActionResult<TipVozila>> PostTipVozilaAsync(CancellationToken ct, [FromBody] Entities.TipVozila tipBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _tipVozilaService.CreateTipVozilaAsync(ct,tipBody.vrstaVozila);

            return Created(Url.Link(nameof(Controllers.TipVozilaController.GetTipVozilaByIdAsync), new { id = resourceID }), null);
        }

        [HttpDelete("{id}", Name =(nameof(DeleteTipVozilaAsync)))]
        public async Task<ActionResult<TipVozila>> DeleteTipVozilaAsync(CancellationToken ct,Guid id)
        {
            await _tipVozilaService.DeleteTipVozilaAsync(ct, id);
            return NoContent();
        }


    }
}
