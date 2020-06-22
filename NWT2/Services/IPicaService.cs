using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
     public interface IPicaService
    {
        public Task<Models.Pica> GetPicaByIdAsync(Guid id, CancellationToken ct);
        public Task<IEnumerable< Models.Pica>> GetPiceAsync(CancellationToken ct);

        public Task<Guid> CreatePiacaAsync(CancellationToken ct, string nazivPice, string kratak_opis, int cena);

        public Task DeletePicaAsync(CancellationToken ct, Guid id);
    }
}
