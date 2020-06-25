using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface INacinPlacanjaService
    {

        public Task<Models.NacinPlacanja> GetNacinPlacanjaById(Guid id, CancellationToken ct);

        public Task<PagedResults< Models.NacinPlacanja>> GetNacinPlacanjaAsync(CancellationToken ct, PaginigOptions paginigOptions);

        public Task<Guid> CreateNacinPlacanjaAsync(CancellationToken ct, string nazivNacinaPlacanja);

        public Task DeleteNacinPlacanjaAsync(CancellationToken ct, Guid id);

    }
}
