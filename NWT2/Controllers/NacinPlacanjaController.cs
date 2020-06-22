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
    public class NacinPlacanjaController : ControllerBase
    {

        private readonly INacinPlacanjaService _nacinPlacanjaService;

        public NacinPlacanjaController( INacinPlacanjaService nacinPlacanjaService)
        {
            _nacinPlacanjaService = nacinPlacanjaService;
        }

        [HttpGet (Name =nameof(GetNacinPlacanjaAsync))]
        public async Task<ActionResult<IEnumerable<NacinPlacanja>>> GetNacinPlacanjaAsync(CancellationToken ct)
        {
            var collection = await _nacinPlacanjaService.GetNacinPlacanjaAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetNacinPlacanjaAsync));

            var resources = new Collection<Models.NacinPlacanja>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetNacinPlacanjaByIdAsync))]
        public async Task<ActionResult<NacinPlacanja>> GetNacinPlacanjaByIdAsync(Guid id,CancellationToken ct)
        {
            var nacinPlacanja = await _nacinPlacanjaService.GetNacinPlacanjaById(id, ct);

            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return Ok(nacinPlacanja);
        }




        [HttpPost (Name =nameof(PostNacinPlacanjaAsync))]
        public async Task<ActionResult<NacinPlacanja>> PostNacinPlacanjaAsync(CancellationToken ct, [FromBody] Entities.NacinPlacanja nacinPlacanjaBody)
        {

            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _nacinPlacanjaService.CreateNacinPlacanjaAsync(ct, nacinPlacanjaBody.NazivNacinaPlacanja);

            return Created(Url.Link(nameof(Controllers.NacinPlacanjaController.GetNacinPlacanjaByIdAsync), new { id = resourceID }), null);
        }

        [HttpDelete("{id}",Name =(nameof(DeleteNacinPlacanjaAsync)))]
        public async Task<ActionResult<NacinPlacanja>> DeleteNacinPlacanjaAsync(Guid id,CancellationToken ct)
        {
            await _nacinPlacanjaService.DeleteNacinPlacanjaAsync(ct, id);
            return NoContent();
        }

      
    }
}
