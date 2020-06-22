using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
        public interface IkupacService
    {
        Task<Models.Kupac> GetKupacByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<Models.Kupac>> GetKupaceAsync( CancellationToken ct);

        public Task<Guid> CreateKupacAsync(CancellationToken ct, string ime, string prezime, string telefon, Guid idAdresa);

        public Task DeleteKupacAsync(CancellationToken ct, Guid id);

    }
}
