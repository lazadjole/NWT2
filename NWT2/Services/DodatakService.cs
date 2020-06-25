using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class DodatakService : IDodatakService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public DodatakService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDodatakAsync(CancellationToken ct, string nazivDodatka, int cena)
        {
            Guid ID = Guid.NewGuid();
            var newDodatak = _dbContext.Dodaci.Add(
                new Entities.Dodatak
                {
                    DodatakID = ID,
                    Naziv_dodatka = nazivDodatka,
                    Cena = cena,
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeleteDodatakAsync(CancellationToken ct, Guid id)
        {
            var dodatak = await _dbContext.Dodaci.FirstOrDefaultAsync(x => x.DodatakID == id);
            if (dodatak == null) return;

            _dbContext.Dodaci.Remove(dodatak);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<PagedResults<Dodatak>> GetDodaciAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {
            var dodaci = await _dbContext.Dodaci.ToArrayAsync();
            if (dodaci == null) return null;

            var dodaciMap= _mapper.Map<IEnumerable<Entities.Dodatak>, IEnumerable<Models.Dodatak>>(dodaci);

            var pagedDodaci = dodaciMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Dodatak>
            {
                Items=pagedDodaci,
                TotalSize=dodaciMap.Count()
            };
        }

        public async Task<Dodatak> GetDodatakByIdAsync(Guid id, CancellationToken ct)
        {
            var dodatak = await _dbContext.Dodaci.FirstOrDefaultAsync(x => x.DodatakID == id);
            if (dodatak == null) return null;
            return _mapper.Map<Entities.Dodatak, Models.Dodatak>(dodatak);
        }
    }
}
