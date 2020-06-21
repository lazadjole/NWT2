using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class StatusDostaveService : IStatusDostaveService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public StatusDostaveService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusDostave>> GetStatusDostaveAsync(CancellationToken ct)
        {
            var statusDostave = await _dbContext.StatusDostave.ToArrayAsync();
            if (statusDostave == null) return null;

            return _mapper.Map<IEnumerable<Entities.StatusDostave>, IEnumerable<Models.StatusDostave>>(statusDostave);

        }

        public async Task<StatusDostave> GetStatusDostavebByIdAsync(Guid id, CancellationToken ct)
        {
            var statusDostave = await _dbContext.StatusDostave.FirstOrDefaultAsync(x => x.StatusDostaveID == id);
            if (statusDostave == null) return null;

            return _mapper.Map<Entities.StatusDostave, Models.StatusDostave>(statusDostave);
        }
    }
}
