using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IStatusDostaveService
    {
        public Task<Models.StatusDostave> GetStatusDostavebByIdAsync(Guid id, CancellationToken ct);
        public Task<IEnumerable<Models.StatusDostave>> GetStatusDostaveAsync(CancellationToken ct);
        public Task<Guid> CreateStatusDostaveAsync(CancellationToken ct, string nazivStatusaDostave);

        public Task DeleteStatusDostaveAsync(CancellationToken ct, Guid id);
    }
}
