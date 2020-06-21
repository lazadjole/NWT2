using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class VoziloService : IVoziloService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public VoziloService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Vozilo>> GetVoziloAsync(CancellationToken ct)
        {    var vozilo = await _dbContext.Vozila.ToArrayAsync();
            if (vozilo == null) return null;

            return _mapper.Map<IEnumerable<Entities.Vozilo>, IEnumerable<Models.Vozilo>>(vozilo);

        }

        public async Task<Vozilo> GetVoziloByIdAsync(Guid id, CancellationToken ct)
        {
            var vozilo = await _dbContext.Vozila.FirstOrDefaultAsync(x => x.VoziloID == id);
            if (vozilo == null) return null;

            return _mapper.Map<Entities.Vozilo, Models.Vozilo>(vozilo);

        }
    }
}
