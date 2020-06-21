using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class NarudzbenicaService : INarudzbenicaService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public NarudzbenicaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Narudzbenica> GetNarudzbenicaByIdAsync(Guid id, CancellationToken ct)
        {
            var narudzbenica = await _dbContext.Narudzbenica.FirstOrDefaultAsync(x => x.NarudzbenicaID == id);
            if (narudzbenica == null) return null;

            return _mapper.Map<Entities.Narudzbenica, Models.Narudzbenica>(narudzbenica);
        }

        public async Task<IEnumerable<Narudzbenica>> GetNarudzbeniceAsync(CancellationToken ct)
        {
            var narudzbenice = await _dbContext.Narudzbenica.ToArrayAsync();
            if (narudzbenice == null) return null;

            return _mapper.Map<IEnumerable<Entities.Narudzbenica>, IEnumerable<Models.Narudzbenica>>(narudzbenice);
        }
    }
}
