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
    public class PicaController : ControllerBase
    {
        private readonly IPicaService _ipicaService;

        public PicaController( IPicaService ipicaService)
        {
            _ipicaService = ipicaService;
        }

        [HttpGet (Name =nameof(GetPiceAsync))]
        public async Task<ActionResult<IEnumerable<Pica>>> GetPiceAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;
            var collection = await _ipicaService.GetPiceAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetPiceAsync));

            var resources = new PagedCollection<Models.Pica>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetPicaByIdAsync))]
        public async Task<ActionResult<Pica>> GetPicaByIdAsync(Guid id,CancellationToken ct)
        {
            var pica = await _ipicaService.GetPicaByIdAsync(id, ct);

            if (pica == null)
            {
                return NotFound();
            }

            return Ok(pica);
        }





        [HttpPost (Name =nameof(PostPicaAsync))]
        public async Task<ActionResult<Pica>> PostPicaAsync(CancellationToken ct, [FromBody] Entities.Pica picaBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _ipicaService.CreatePiacaAsync(ct, picaBody.NazivPice,picaBody.Kratak_opis,picaBody.Cena);

            return Created(Url.Link(nameof(Controllers.PicaController.GetPicaByIdAsync), new { id = resourceID }), null);
        }

        [HttpDelete("{id}" , Name =(nameof(DeletePicaAsync)))]
        public async Task<ActionResult<Pica>> DeletePicaAsync(CancellationToken ct,Guid id)
        {
            await _ipicaService.DeletePicaAsync(ct, id);
            return NoContent();
        }


    }
}
