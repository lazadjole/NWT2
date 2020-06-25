using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IDodatakService
    {
        public Task<Models.Dodatak> GetDodatakByIdAsync(Guid id, CancellationToken ct);
        public Task<PagedResults<Models.Dodatak>> GetDodaciAsync(CancellationToken ct, PaginigOptions paginigOptions);

        public Task<Guid> CreateDodatakAsync(CancellationToken ct, string nazivDodatka, int cena);

        public Task DeleteDodatakAsync(CancellationToken ct, Guid id);

    }
}
