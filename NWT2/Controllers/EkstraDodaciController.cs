using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NWT2.Models;
using NWT2.Services;


namespace NWT2.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EkstraDodaciController : ControllerBase
    {
        private readonly IEkstraDodaciService _ekstraDodaciService;

        public EkstraDodaciController(IEkstraDodaciService ekstraDodaciService)
        {
            _ekstraDodaciService = ekstraDodaciService;
        }


        [HttpGet (Name =nameof(GetEkstraDodaciAsync))]
        public async Task<ActionResult<IEnumerable< Models.EkstraDodaci>>> GetEkstraDodaciAsync(CancellationToken ct, [FromQuery] PaginigOptions paginigOptions)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));
            paginigOptions.Offset = paginigOptions.Offset ?? 0;
            paginigOptions.Limit = paginigOptions.Limit ?? 25;
            var collection = await _ekstraDodaciService.GetEkstraDodaciAsync(ct,paginigOptions);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetEkstraDodaciAsync));

            var resources = new PagedCollection<Models.EkstraDodaci>
            {
                Self = collectionLink,
                Value = collection.Items.ToArray(),
                Limit=paginigOptions.Limit.Value,
                Offset=paginigOptions.Offset.Value,
                Size=collection.TotalSize
            };

            return Ok(resources);
        }

        [HttpGet("{id}", Name = nameof(GetEkstraDodaciByIDAsync))]
        public async Task<ActionResult<Models.EkstraDodaci>> GetEkstraDodaciByIDAsync(Guid id, CancellationToken ct)
        {
            var resource = await _ekstraDodaciService.GetEkstraDodaciByIdAsync(id, ct);
            if (resource == null) return NotFound();

            return Ok(resource);
        }


        [HttpPost(Name = nameof(PostEkstraDodaciAsync))]
        public async Task<ActionResult<EkstraDodaci>> PostEkstraDodaciAsync(CancellationToken ct, [FromBody] Entities.EkstraDodaci ekstraDodaci)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _ekstraDodaciService.CreateEkstraDodaciAsync(ct, ekstraDodaci.DodatakID,ekstraDodaci.DetaljiNarudzbeniceID);

            return Created(Url.Link(nameof(Controllers.EkstraDodaciController.GetEkstraDodaciByIDAsync), new { id = resourceID }), null);

        }




        [HttpDelete("{id}", Name = (nameof(DeleteEkstraDodaci)))]
        public async Task<IActionResult> DeleteEkstraDodaci(CancellationToken ct, Guid id)
        {
            await _ekstraDodaciService.DeleteEkstraDodatakAsync(ct, id);
            return NoContent();
        }
    }
}
