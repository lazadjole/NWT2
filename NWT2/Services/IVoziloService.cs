using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IVoziloService
    {
        public Task<Models.Vozilo> GetVoziloByIdAsync(Guid id, CancellationToken ct);
        public Task<IEnumerable< Models.Vozilo>> GetVoziloAsync(CancellationToken ct);

    }
}
