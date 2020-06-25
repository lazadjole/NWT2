using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    public class ZaposleniController : ControllerBase
    {
        protected readonly IZaposleniService _zaposleniService;

        public ZaposleniController(IZaposleniService zaposleniService)
        {
            _zaposleniService = zaposleniService;
        }

       
        [HttpGet(Name = nameof(GetZaposleniAsync))]
        public async Task<ActionResult<IEnumerable<Zaposlen>>> GetZaposleniAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            var collection = await _zaposleniService.GetZaposleneAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetZaposleniAsync));

            var resources = new PagedCollection<Models.Zaposlen>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
            };

            return Ok(resources);
        }



        [HttpGet("{id}",Name =nameof(GetZaposlenogByIDAsync))]
        public async Task<ActionResult<Models.Zaposlen>> GetZaposlenogByIDAsync(Guid id, CancellationToken ct)
        {
            var zaposlen = await _zaposleniService.GetZaposlenByIdAsync(id, ct);

            if (zaposlen == null)
            {
                return NotFound();
            }

            return Ok(zaposlen);
        }

        [HttpPost(Name = nameof(PostZaposleniAsync))]
        public async Task<ActionResult<Adresa>> PostZaposleniAsync(CancellationToken ct, [FromBody] Entities.Zaposleni zaposleniBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _zaposleniService.CreateZaposleniAsync(ct, zaposleniBody.Ime,zaposleniBody.Prezime,zaposleniBody.FKAdresaID,zaposleniBody.BrojTelefona);

            return Created(Url.Link(nameof(Controllers.ZaposleniController.GetZaposlenogByIDAsync), new { id = resourceID }), null);

        }




        [HttpDelete("{id}", Name = (nameof(DeleteZaposleniAsync)))]
        public async Task<IActionResult> DeleteZaposleniAsync(CancellationToken ct, Guid id)
        {
            await _zaposleniService.DeleteZaposleniAsync(ct, id);
            return NoContent();
        }
    }
}
