using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class DetaljiNarudzbeniceService : IDetaljiNarudzbeniceService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public DetaljiNarudzbeniceService(PicerijaDbContext dbContext,AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetaljiNarudzbenice>> GetDetaljiNarudzbeniceAsync(CancellationToken ct)
        {
            var detaljiNarudzbenica = await _dbContext.DetaljiNarudzbenice.ToArrayAsync();
            if (detaljiNarudzbenica == null) return null;

            return _mapper.Map<IEnumerable<Entities.DetaljiNarudzbenice>, IEnumerable<Models.DetaljiNarudzbenice>>(detaljiNarudzbenica);
        }

        public async Task<DetaljiNarudzbenice> GetDetaljiNarudzbeniceByIdAsync(Guid id, CancellationToken ct)
        {
            var detaljiNarudzbenice = await _dbContext.DetaljiNarudzbenice.FirstOrDefaultAsync(x=>x.DetaljiNarudzbeniceID==id);
            if (detaljiNarudzbenice == null) return null;

            return _mapper.Map<Entities.DetaljiNarudzbenice, Models.DetaljiNarudzbenice>(detaljiNarudzbenice);

        }
    }
}
