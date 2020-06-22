using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface INarudzbenicaService
    {
        public Task<Models.Narudzbenica> GetNarudzbenicaByIdAsync(Guid id, CancellationToken ct);
        public Task<IEnumerable< Models.Narudzbenica>> GetNarudzbeniceAsync(CancellationToken ct);
        public Task<Guid> CreateNarudzbenicaAsync(CancellationToken ct, string BrojNarudzbenice, Guid idKupac, Guid idZaposleni, Guid idStatusDostave, Guid idNacinPlacanja, DateTime datumPrijema, Guid idVozilo);

        public Task DeleteNarudzbenicaAsync(CancellationToken ct, Guid id);
    }
}
