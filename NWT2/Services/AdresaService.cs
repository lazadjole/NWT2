using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class AdresaService : IAdresaService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public AdresaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Models.Adresa> GetAdresaByIdAsync(Guid id, CancellationToken ct)
        {
            var adresa = await _dbContext.Adrese.FirstOrDefaultAsync(x => x.AdresaID == id);
          
            if (adresa == null) return null;

            return _mapper.Map<Entities.Adresa, Models.Adresa>(adresa);
        }

        public async Task<IEnumerable<Adresa>> GetAdreseAsync(CancellationToken ct)
        {
            var adrese = await _dbContext.Adrese.ToArrayAsync();
            if (adrese == null) return null;

            return _mapper.Map<IEnumerable<Entities.Adresa>, IEnumerable< Models.Adresa>>(adrese);

        }
    }
}
