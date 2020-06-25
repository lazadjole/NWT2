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

        public async Task<Guid> CreateStatusDostaveAsync(CancellationToken ct, string nazivStatusaDostave)
        {
            Guid ID = Guid.NewGuid();
            var newAdresa = _dbContext.StatusDostave.Add(
                new Entities.StatusDostave
                {
                   StatusDostaveID=ID,
                   NazivStatusa=nazivStatusaDostave
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeleteStatusDostaveAsync(CancellationToken ct, Guid id)
        {
            var statusDostave = await _dbContext.StatusDostave.FirstOrDefaultAsync(x => x.StatusDostaveID == id);
            if (statusDostave == null) return;

            _dbContext.StatusDostave.Remove(statusDostave);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<PagedResults<StatusDostave>> GetStatusDostaveAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {
            var statusDostave = await _dbContext.StatusDostave.ToArrayAsync();
            if (statusDostave == null) return null;

            var statusMap= _mapper.Map<IEnumerable<Entities.StatusDostave>, IEnumerable<Models.StatusDostave>>(statusDostave);
            var statusPadge=statusMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<StatusDostave>
            {
                Items = statusPadge,
                TotalSize = statusMap.Count()
            };

        }

        public async Task<StatusDostave> GetStatusDostavebByIdAsync(Guid id, CancellationToken ct)
        {
            var statusDostave = await _dbContext.StatusDostave.FirstOrDefaultAsync(x => x.StatusDostaveID == id);
            if (statusDostave == null) return null;

            return _mapper.Map<Entities.StatusDostave, Models.StatusDostave>(statusDostave);
        }
    }
}
