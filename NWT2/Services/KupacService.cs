using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class KupacService : IkupacService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public KupacService  (PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async  Task<Guid> CreateKupacAsync(CancellationToken ct, string ime, string prezime, string telefon, Guid idAdresa)
        {
            Guid ID = Guid.NewGuid();
            var newAdresa = _dbContext.Kupci.Add(
                new Entities.Kupac
                {
                    KupacID = ID,
                    Ime=ime,
                    Prezime=prezime,
                    Telefon=telefon,
                    FKAdresaID=idAdresa
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeleteKupacAsync(CancellationToken ct, Guid id)
        {
            var Kupac = await _dbContext.Kupci.FirstOrDefaultAsync(x => x.KupacID == id);
            if (Kupac == null) return;

            _dbContext.Kupci.Remove(Kupac);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<Kupac> GetKupacByIdAsync(Guid id, CancellationToken ct)
        {
            var kupac = await _dbContext.Kupci.FirstOrDefaultAsync(x => x.KupacID == id);
            if (kupac == null) return null;

            return _mapper.Map<Entities.Kupac, Models.Kupac>(kupac);
        }

        public async Task<PagedResults<Kupac>> GetKupaceAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {
            var kupci = await _dbContext.Kupci.ToArrayAsync();
            if (kupci == null) return null;

            var kupacMap= _mapper.Map<IEnumerable<Entities.Kupac>, IEnumerable<Models.Kupac>>(kupci);

            var padgeKupac = kupacMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Kupac>
            {
                Items = kupacMap,
                TotalSize = kupacMap.Count()
            };


        }
    }
}
