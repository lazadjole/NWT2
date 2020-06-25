using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface ITipVozilaService
    {

        public Task<Models.TipVozila> GetTipVozilaByIdAsync(Guid id, CancellationToken ct);
        public Task<PagedResults<Models.TipVozila>> GetTipVozilaAsync(CancellationToken ct, PaginigOptions paginigOptions);
        public Task<Guid> CreateTipVozilaAsync(CancellationToken ct, string vrstaVozila);

        public Task DeleteTipVozilaAsync(CancellationToken ct, Guid id);
    }
}
