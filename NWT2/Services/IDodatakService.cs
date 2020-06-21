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
        public Task<IEnumerable<Models.Dodatak>> GetDodaciAsync(CancellationToken ct);

    }
}
