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
    public class NarudzbenicaController : ControllerBase
    {

        private readonly INarudzbenicaService _narudzbenicaService;

        public NarudzbenicaController( INarudzbenicaService narudzbenicaService)
        {
            _narudzbenicaService = narudzbenicaService;
        }

        [HttpGet (Name =nameof(GetNarudzbeniceAsync))]
        public async Task<ActionResult<IEnumerable<Narudzbenica>>> GetNarudzbeniceAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;

            var collection = await _narudzbenicaService.GetNarudzbeniceAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetNarudzbeniceAsync));

            var resources = new PagedCollection<Models.Narudzbenica>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                 Size = collection.TotalSize,
                Offset = paginigOptions.Offset.Value,
                Limit = paginigOptions.Limit.Value
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetNarudzbenicaByIdAsync))]
        public async Task<ActionResult<Narudzbenica>> GetNarudzbenicaByIdAsync(Guid id,CancellationToken ct)
        {
            var narudzbenica = await _narudzbenicaService.GetNarudzbenicaByIdAsync(id, ct);

            if (narudzbenica == null)
            {
                return NotFound();
            }

            return Ok(narudzbenica);
        }




        [HttpPost]
        public async Task<ActionResult<Narudzbenica>> PostNarudzbenicaAsync(CancellationToken ct, [FromBody] Entities.Narudzbenica narudzbenicaBody)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _narudzbenicaService.CreateNarudzbenicaAsync(ct, narudzbenicaBody.BrojNarudzbenice,narudzbenicaBody.KupacID,narudzbenicaBody.ZaposleniId,narudzbenicaBody.StatusDostaveID,narudzbenicaBody.NacinPlacanja,narudzbenicaBody.datumPrijema,narudzbenicaBody.VoziloID);

            return Created(Url.Link(nameof(Controllers.NarudzbenicaController.GetNarudzbenicaByIdAsync), new { id = resourceID }), null);
        }



        [HttpDelete("{id}",Name =(nameof(DeleteNarudzbenicaAsync)))]
        public async Task<ActionResult<Narudzbenica>> DeleteNarudzbenicaAsync(CancellationToken ct,Guid id)
        {
            await _narudzbenicaService.DeleteNarudzbenicaAsync(ct, id);
            return NoContent(); ;
        }


    }
}
