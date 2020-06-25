using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IEkstraDodaciService
    {
        public Task<Models.EkstraDodaci> GetEkstraDodaciByIdAsync(Guid id, CancellationToken ct);

        public Task<PagedResults< Models.EkstraDodaci>> GetEkstraDodaciAsync(CancellationToken ct, PaginigOptions paginigOptions);

        public Task<Guid> CreateEkstraDodaciAsync(CancellationToken ct, Guid IdDodatak, Guid IdDetaljiNardzbenice);

        public Task DeleteEkstraDodatakAsync(CancellationToken ct, Guid id);

    }
}
