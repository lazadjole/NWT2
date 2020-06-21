using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class ZaposleniService : IZaposleniService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ZaposleniService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Zaposlen> GetZaposlenByIdAsync(Guid id, CancellationToken ct)
        {
            var zaposlen = await _dbContext.Zaposleni.FirstOrDefaultAsync(x => x.ZaposleniId == id);
            if (zaposlen == null) return null;

            return _mapper.Map<Entities.Zaposleni, Models.Zaposlen>(zaposlen);
        }

        public async Task<IEnumerable<Zaposlen>> GetZaposleneAsync(CancellationToken ct)
        {
            var zaposleni = await _dbContext.Zaposleni.ToArrayAsync();
            if (zaposleni == null) return null;

            return _mapper.Map<IEnumerable<Entities.Zaposleni>, IEnumerable<Models.Zaposlen>>(zaposleni);
        }
    }
}
