using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
     public  interface IZaposleniService
    {

        public Task<Models.Zaposlen> GetZaposlenByIdAsync(Guid id, CancellationToken ct);

        public Task<PagedResults<Models.Zaposlen>> GetZaposleneAsync(CancellationToken ct, PaginigOptions paginigOptions);

        public Task<Guid> CreateZaposleniAsync(CancellationToken ct, string ime, string prezime, Guid idAdresa, string brTelefona);

        public Task DeleteZaposleniAsync(CancellationToken ct, Guid id);
    }
}
