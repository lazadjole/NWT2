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

        public async Task<Guid> CreatePiacaAsync(CancellationToken ct, string nazivPice, string kratak_opis, int cena)
        {
            Guid ID = Guid.NewGuid();
            var newPica = _dbContext.Pice.Add(
                new Entities.Pica
                {
                   PicaID=ID,
                   NazivPice=nazivPice,
                   Kratak_opis=kratak_opis,
                   Cena=cena
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeletePicaAsync(CancellationToken ct, Guid id)
        {
            var pica = await _dbContext.Pice.FirstOrDefaultAsync(x => x.PicaID == id);
            if (pica == null) return;

            _dbContext.Pice.Remove(pica);
            await _dbContext.SaveChangesAsync(ct);
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
