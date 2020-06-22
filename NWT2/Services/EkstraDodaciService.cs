using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class EkstraDodaciService : IEkstraDodaciService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public EkstraDodaciService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateEkstraDodaciAsync(CancellationToken ct, Guid IdDodatak, Guid IdDetaljiNardzbenice)
        {
            Guid ID = Guid.NewGuid();
            var newEkstraDodatak = _dbContext.EkstraDodaci.Add(
                new Entities.EkstraDodaci
                {
                    Ekstra_dodaciID = ID,
                    FKDetaljiNarudzbeniceID=IdDetaljiNardzbenice,
                    FKDodatakID=IdDodatak
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new ekstraDodatak");

            return ID;
        }

        public async Task DeleteEkstraDodatakAsync(CancellationToken ct, Guid id)
        {
            var ekstraDodaci = await _dbContext.EkstraDodaci.FirstOrDefaultAsync(x => x.Ekstra_dodaciID == id);
            if (ekstraDodaci == null) return;

            _dbContext.EkstraDodaci.Remove(ekstraDodaci);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<EkstraDodaci>> GetEkstraDodaciAsync(CancellationToken ct)
        {
            var ekstraDodaci = await _dbContext.EkstraDodaci.ToArrayAsync();
            if (ekstraDodaci == null) return null;

            return _mapper.Map<IEnumerable<Entities.EkstraDodaci>, IEnumerable<Models.EkstraDodaci>>(ekstraDodaci);
        }

        public async Task<EkstraDodaci> GetEkstraDodaciByIdAsync(Guid id, CancellationToken ct)
        {
            var Edodaci = await _dbContext.EkstraDodaci.FirstOrDefaultAsync(x => x.Ekstra_dodaciID == id);
            if (Edodaci == null) return null;

            return _mapper.Map<Entities.EkstraDodaci, Models.EkstraDodaci>(Edodaci);
        }
    }
}
