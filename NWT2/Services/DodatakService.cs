using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class DodatakService : IDodatakService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public DodatakService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dodatak>> GetDodaciAsync(CancellationToken ct)
        {
            var dodaci = await _dbContext.Dodaci.ToArrayAsync();
            if (dodaci == null) return null;

            return _mapper.Map<IEnumerable<Entities.Dodatak>, IEnumerable<Models.Dodatak>>(dodaci);
        }

        public async Task<Dodatak> GetDodatakByIdAsync(Guid id, CancellationToken ct)
        {
            var dodatak = await _dbContext.Dodaci.FirstOrDefaultAsync(x => x.DodatakID == id);
            if (dodatak == null) return null;
            return _mapper.Map<Entities.Dodatak, Models.Dodatak>(dodatak);
        }
    }
}
