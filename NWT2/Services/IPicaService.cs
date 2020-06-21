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

    }
}
