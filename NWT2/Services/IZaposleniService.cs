using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
     public  interface IZaposleniService
    {

        public Task<Models.Zaposlen> GetZaposlenByIdAsync(Guid id, CancellationToken ct);

        public Task<IEnumerable<Models.Zaposlen>> GetZaposleneAsync(CancellationToken ct);

    }
}
