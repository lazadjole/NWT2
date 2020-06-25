using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class ZaposleniService : IZaposleniService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ZaposleniService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateZaposleniAsync(CancellationToken ct, string ime, string prezime, Guid idAdresa, string brTelefona)
        {
            Guid ID = Guid.NewGuid();
            var newAdresa = _dbContext.Zaposleni.Add(
                new Entities.Zaposleni
                {
                    ZaposleniId=ID,
                    Ime=ime,
                    Prezime=prezime,
                    BrojTelefona=brTelefona,
                    FKAdresaID=idAdresa

                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

     

        public async Task DeleteZaposleniAsync(CancellationToken ct, Guid id)
        {
            var zaposleni = await _dbContext.Zaposleni.FirstOrDefaultAsync(x => x.ZaposleniId == id);
            if (zaposleni == null) return;

            _dbContext.Zaposleni.Remove(zaposleni);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<Zaposlen> GetZaposlenByIdAsync(Guid id, CancellationToken ct)
        {
            var zaposlen = await _dbContext.Zaposleni.FirstOrDefaultAsync(x => x.ZaposleniId == id);
            if (zaposlen == null) return null;

            return _mapper.Map<Entities.Zaposleni, Models.Zaposlen>(zaposlen);
        }

        public async Task<PagedResults<Zaposlen>> GetZaposleneAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {
            var zaposleni = await _dbContext.Zaposleni.ToArrayAsync();
            if (zaposleni == null) return null;

            var zaposleniMap= _mapper.Map<IEnumerable<Entities.Zaposleni>, IEnumerable<Models.Zaposlen>>(zaposleni);

            var pagedZaposleni= zaposleniMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Zaposlen>
            {
                Items = pagedZaposleni,
                TotalSize = zaposleniMap.Count()
            };
        }
    }
}
