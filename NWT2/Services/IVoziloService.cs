using NWT2.Models;
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
        public Task<PagedResults< Models.Vozilo>> GetVoziloAsync(CancellationToken ct, PaginigOptions paginigOptions);

        public Task<Guid> CreateVoziloAsync(CancellationToken ct, Guid tipVozila,string evidencioniBr, string markaVozila, string detaljiVozila);

        public Task DeleteVoziloAsync(CancellationToken ct, Guid id);
    }
}
