using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class PicaService : IPicaService
    {

        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public PicaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Pica> GetPicaByIdAsync(Guid id, CancellationToken ct)
        {
            var pica = await _dbContext.Pice.FirstOrDefaultAsync(x => x.PicaID == id);
            if (pica == null) return null;

            return _mapper.Map<Entities.Pica, Models.Pica>(pica);
        }

        public async Task<IEnumerable<Pica>> GetPiceAsync(CancellationToken ct)
        {
            var pice = await _dbContext.Pice.ToArrayAsync();
            if (pice == null) return null;

            return _mapper.Map<IEnumerable<Entities.Pica>, IEnumerable<Models.Pica>>(pice);
        }
    }
}
