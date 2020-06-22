using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
     public interface IDetaljiNarudzbeniceService
    {
        public Task<Models.DetaljiNarudzbenice> GetDetaljiNarudzbeniceByIdAsync(Guid id, CancellationToken ct);

        public Task<IEnumerable<Models.DetaljiNarudzbenice>> GetDetaljiNarudzbeniceAsync(CancellationToken ct);

        public Task<Guid> PostDetaljiNarudzbeniceAsync(CancellationToken ct, Guid picaId, Guid narudzbenicaId, int kolicina);

        public Task DeleteDetaljiNarudzbeniceAsync(CancellationToken ct, Guid id);
    }
}
