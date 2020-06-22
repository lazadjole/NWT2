 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IAdresaService
    {
       public Task<Models.Adresa> GetAdresaByIdAsync(Guid id, CancellationToken ct);
       public Task<IEnumerable<Models.Adresa>> GetAdreseAsync(CancellationToken ct);

        public Task<Guid> CreateAdresaAsync(CancellationToken ct, string ulica, int broj, string grad);

        public Task DeleteAdresaAsync(CancellationToken ct, Guid id);
    }
}
