using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class KupacService : IkupacService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public KupacService  (PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Kupac> GetKupacByIdAsync(Guid id, CancellationToken ct)
        {
            var kupac = await _dbContext.Kupci.FirstOrDefaultAsync(x => x.KupacID == id);
            if (kupac == null) return null;

            return _mapper.Map<Entities.Kupac, Models.Kupac>(kupac);
        }

        public async Task<IEnumerable<Kupac>> GetKupaceAsync(CancellationToken ct)
        {
            var kupci = await _dbContext.Kupci.ToArrayAsync();
            if (kupci == null) return null;

            return _mapper.Map<IEnumerable<Entities.Kupac>, IEnumerable<Models.Kupac>>(kupci);
        }
    }
}
