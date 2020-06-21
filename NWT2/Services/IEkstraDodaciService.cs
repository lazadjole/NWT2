using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface IEkstraDodaciService
    {
        public Task<Models.EkstraDodaci> GetEkstraDodaciByIdAsync(Guid id, CancellationToken ct);

        public Task<IEnumerable< Models.EkstraDodaci>> GetEkstraDodaciAsync(CancellationToken ct);

    }
}
