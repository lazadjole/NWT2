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
    public class DodatakController : ControllerBase
    {
        private readonly IDodatakService _dodatakService;

        public DodatakController(IDodatakService dodatakService)
        {
            _dodatakService = dodatakService;
        }

        [HttpGet (Name =nameof(GetDodaciAsync))]
        public async Task<ActionResult<IEnumerable<Dodatak>>> GetDodaciAsync(CancellationToken ct)
        {
            var collection = await _dodatakService.GetDodaciAsync(ct);
            if (collection == null) return NotFound();

            var collectionLink = Link.ToCollection(nameof(GetDodaciAsync));

            var resources = new Collection<Models.Dodatak>
            {
                Self = collectionLink,
                Value = collection.ToArray()
            };

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dodatak>> GetDodatakByIdAsync(Guid id,CancellationToken ct)
        {

            var resource =await _dodatakService.GetDodatakByIdAsync(id,ct);
            if (resource == null) return NotFound();
            return Ok(resource);

        }




        [HttpPost (Name =nameof(PostDodatakAsync))]
        public async Task<ActionResult<Dodatak>> PostDodatakAsync(CancellationToken ct,[FromBody] Entities.Dodatak dodatak)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var resourceID = await _dodatakService.CreateDodatakAsync(ct, dodatak.Naziv_dodatka,dodatak.Cena);

            return Created(Url.Link(nameof(Controllers.DodatakController.GetDodatakByIdAsync), new { id = resourceID }), null);

        }


         [HttpDelete("{id}",Name = nameof(DeleteDodatakAsync))]
         public async Task<ActionResult<Dodatak>> DeleteDodatakAsync(CancellationToken ct,Guid id)
            {
            await _dodatakService.DeleteDodatakAsync(ct, id);
            return NoContent();
        }


        }
}
