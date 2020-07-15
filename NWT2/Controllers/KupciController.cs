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
    public class KupciController : ControllerBase
    {

        private readonly IkupacService _kupacService;

        public KupciController( IkupacService kupacService)
        {
            _kupacService = kupacService;
        }

        [HttpGet (Name =nameof(GetKupciAsync))]
        public async Task<ActionResult<IEnumerable<Kupac>>> GetKupciAsync(CancellationToken ct,[FromQuery] PaginigOptions paginigOptions)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;
            var collection = await _kupacService.GetKupaceAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetKupciAsync));

            var resources = new PagedCollection<Models.Kupac>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size=collection.TotalSize,
                Limit=paginigOptions.Limit.Value,
                Offset=paginigOptions.Offset.Value
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetKupacByIdAsync))]
        public async Task<ActionResult<Kupac>> GetKupacByIdAsync(Guid id,CancellationToken ct)
        {
            var kupac = await _kupacService.GetKupacByIdAsync(id, ct);

            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(kupac);
        }





        [HttpPost (Name =nameof(PostKupacAsync))]
        public async Task<ActionResult<Kupac>> PostKupacAsync(CancellationToken ct, [FromBody] Entities.Kupac kupacBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _kupacService.CreateKupacAsync(ct, kupacBody.Ime,kupacBody.Prezime,kupacBody.Telefon,kupacBody.AdresaID);

            return Created(Url.Link(nameof(Controllers.KupciController.GetKupacByIdAsync), new { id = resourceID }), null);
        }



        [HttpDelete("{id}", Name =nameof(DeleteKupacAsync))]
        public async Task<IActionResult> DeleteKupacAsync(CancellationToken ct, Guid id)
        {
            await _kupacService.DeleteKupacAsync(ct, id);
            return NoContent();
        }


    }
}
