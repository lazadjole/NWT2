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

        public async Task<Guid> CreateNarudzbenicaAsync(CancellationToken ct, string BrojNarudzbenice, Guid idKupac, Guid idZaposleni, Guid idStatusDostave, string nacinPlacanja, DateTime datumPrijema, Guid idVozilo)
        {
            Guid ID = Guid.NewGuid();
            var newNarudzbenica = _dbContext.Narudzbenica.Add(
                new Entities.Narudzbenica
                {
                    NarudzbenicaID=ID,
                    BrojNarudzbenice=BrojNarudzbenice,
                    datumPrijema=datumPrijema,
                    KupacID=idKupac,
                    NacinPlacanja= nacinPlacanja,
                    StatusDostaveID=idStatusDostave,
                    VoziloID=idVozilo,
                    ZaposleniId=idZaposleni
                    
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeleteNarudzbenicaAsync(CancellationToken ct, Guid id)
        {
            var narudzbenica = await _dbContext.Narudzbenica.FirstOrDefaultAsync(x => x.NarudzbenicaID == id);
            if (narudzbenica == null) return;

            _dbContext.Narudzbenica.Remove(narudzbenica);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<Narudzbenica> GetNarudzbenicaByIdAsync(Guid id, CancellationToken ct)
        {
            var narudzbenica = await _dbContext.Narudzbenica.FirstOrDefaultAsync(x => x.NarudzbenicaID == id);
            if (narudzbenica == null) return null;

            return _mapper.Map<Entities.Narudzbenica, Models.Narudzbenica>(narudzbenica);
        }

        public async Task<PagedResults<Narudzbenica>> GetNarudzbeniceAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {
            var narudzbenice = await _dbContext.Narudzbenica.ToArrayAsync();
            if (narudzbenice == null) return null;

            var narudzbenicaMap= _mapper.Map<IEnumerable<Entities.Narudzbenica>, IEnumerable<Models.Narudzbenica>>(narudzbenice);

            var narudzbenicaPagin = narudzbenicaMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Narudzbenica>
            {
                Items = narudzbenicaPagin,
                TotalSize = narudzbenicaMap.Count()
            };
        }
    }
}
