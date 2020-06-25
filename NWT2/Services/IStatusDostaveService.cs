using NWT2.Models;
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
        public Task<PagedResults<Models.StatusDostave>> GetStatusDostaveAsync(CancellationToken ct, PaginigOptions paginigOptions);
        public Task<Guid> CreateStatusDostaveAsync(CancellationToken ct, string nazivStatusaDostave);

        public Task DeleteStatusDostaveAsync(CancellationToken ct, Guid id);
    }
}
