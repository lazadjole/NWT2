 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IAdresaService
    {
        Task<Models.Adresa> GetAdresaByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<Models.Adresa>> GetAdreseAsync(CancellationToken ct);
    
    }
}
