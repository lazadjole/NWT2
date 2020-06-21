using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class NacinPlacanjaService : INacinPlacanjaService
    {

        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public NacinPlacanjaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.NacinPlacanja>> GetNacinPlacanjaAsync(CancellationToken ct)
        {
            var nacinPlacanja = await _dbContext.NacinPlacanja.ToArrayAsync();
            if (nacinPlacanja == null) return null;

            return _mapper.Map<IEnumerable<Entities.NacinPlacanja>, IEnumerable<Models.NacinPlacanja>>(nacinPlacanja);
        }

        public async Task<NacinPlacanja> GetNacinPlacanjaById(Guid id, CancellationToken ct)
        {
            var nacinPlacanja = await _dbContext.NacinPlacanja.FirstOrDefaultAsync(x => x.NacinPlacanjaID == id);
            if (nacinPlacanja == null) return null;

            return _mapper.Map<Entities.NacinPlacanja, Models.NacinPlacanja>(nacinPlacanja);
        }
    }
}
