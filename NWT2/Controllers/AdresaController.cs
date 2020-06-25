using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NWT2.Models;
using NWT2.Services;

namespace NWT2.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AdresaController : ControllerBase
    {

        private readonly IAdresaService _adresaService;
    
        public AdresaController(IAdresaService adresaService)
        {
            _adresaService = adresaService;
        }

        [HttpGet (Name =nameof(GetAdresaAsync))]
        public async Task<ActionResult<IEnumerable<Adresa>>> GetAdresaAsync(CancellationToken ct,[FromQuery] PaginigOptions paginigOptions)
        {   if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;
            var collection = await _adresaService.GetAdreseAsync(ct, paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetAdresaAsync));

            var resources = new PagedCollection<Models.Adresa>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Size=collection.TotalSize,
                Offset=paginigOptions.Offset.Value,
                Limit=paginigOptions.Limit.Value
            };

            return Ok(resources);
        }

        [HttpGet("{id}",Name =nameof(GetAdresaByIDAsync))]
        public async Task<ActionResult<Adresa>> GetAdresaByIDAsync(Guid id,CancellationToken ct)
        {


            var adresa = await _adresaService.GetAdresaByIdAsync(id, ct);

            if (adresa == null)
            {
                return NotFound();
            }

            return Ok(adresa);
        }

       


        [HttpPost (Name =nameof(PostAdresaAsync))]
        public async Task<ActionResult<Adresa>> PostAdresaAsync(CancellationToken ct, [FromBody] Entities.Adresa adresaBody )
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _adresaService.CreateAdresaAsync(ct,adresaBody.Ulica,adresaBody.Broj,adresaBody.Grad);

            return Created(Url.Link(nameof(Controllers.AdresaController.GetAdresaByIDAsync), new {id=resourceID}), null);

        }


        [HttpDelete("{id}" , Name =(nameof (DeleteAdresaAsync)))]
        public async Task<IActionResult> DeleteAdresaAsync(CancellationToken ct,Guid id)
        {
            await _adresaService.DeleteAdresaAsync(ct, id);
            return NoContent();
        }

       
    }
}
