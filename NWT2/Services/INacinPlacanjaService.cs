using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public interface INacinPlacanjaService
    {

        public Task<Models.NacinPlacanja> GetNacinPlacanjaById(Guid id, CancellationToken ct);

        public Task<IEnumerable< Models.NacinPlacanja>> GetNacinPlacanjaAsync(CancellationToken ct);


    }
}
