using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class DetaljiNarudzbeniceService : IDetaljiNarudzbeniceService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;
        
        public DetaljiNarudzbeniceService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task DeleteDetaljiNarudzbeniceAsync(CancellationToken ct, Guid id)
        {
            var detaljNarudzbenice = await _dbContext.DetaljiNarudzbenice.FirstOrDefaultAsync(x => x.DetaljiNarudzbeniceID == id);

            if (detaljNarudzbenice == null) return;

            _dbContext.DetaljiNarudzbenice.Remove(detaljNarudzbenice);

            await _dbContext.SaveChangesAsync(ct);


        }

        public async Task<PagedResults<DetaljiNarudzbenice>> GetDetaljiNarudzbeniceAsync(CancellationToken ct, PaginigOptions paginigOptions, string nazivPice)
        {


            var query = queryForm(null,nazivPice);

            var rezultati = await query.ToArrayAsync();
            if (rezultati == null) return null;
            List<Entities.DetaljiNarudzbenice> detaljiNarudzbenicesList = new List<Entities.DetaljiNarudzbenice>();
            foreach (var prom in rezultati)
            {
                detaljiNarudzbenicesList.Add(prom.detaljiNarudzbenice);
            }
            var mapDetaljNarudzbenice = _mapper.Map<IEnumerable<Entities.DetaljiNarudzbenice>, IEnumerable<Models.DetaljiNarudzbenice>>(detaljiNarudzbenicesList);


            var pageDetaljNarudzbenice = mapDetaljNarudzbenice.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);
            return new PagedResults<DetaljiNarudzbenice>
            {
                Items = pageDetaljNarudzbenice,
                TotalSize = mapDetaljNarudzbenice.Count()
            };
        }

        public async Task<DetaljiNarudzbenice> GetDetaljiNarudzbeniceByIdAsync(Guid id, CancellationToken ct)
        {
            var query = queryForm(id,null);

            var rezultat = await query.FirstAsync();

            if (rezultat == null) return null;

            return _mapper.Map<Entities.DetaljiNarudzbenice, Models.DetaljiNarudzbenice>(rezultat.detaljiNarudzbenice);

        }

        public async Task<Guid> PostDetaljiNarudzbeniceAsync(CancellationToken ct, Guid picaId, Guid narudzbenicaId, int kolicina)
        {

            Guid ID = Guid.NewGuid();

            var newdetaljNarudzbenice = _dbContext.DetaljiNarudzbenice.Add
                (
                    new Entities.DetaljiNarudzbenice
                    {
                        DetaljiNarudzbeniceID = ID,
                        NarudzbenicaID = narudzbenicaId,
                        PicaID = picaId,
                        Kolicina = kolicina
                    }
                );
            var created = await _dbContext.SaveChangesAsync(ct);
            if (created < 1) throw new InvalidOperationException("can't create new detaljiNarudzbenice");
            return ID;
        }

        public IQueryable<DetaljiNarudzbenicePom> queryForm(Guid? id, string nazivPice)
    {
        if (id == null && nazivPice == null)
        {
                return from detaljiDb in _dbContext.DetaljiNarudzbenice
                       join picaDb in _dbContext.Pice on detaljiDb.PicaID equals picaDb.PicaID
                       join narudzbenicaDb in _dbContext.Narudzbenica on detaljiDb.NarudzbenicaID equals narudzbenicaDb.NarudzbenicaID
                       select new DetaljiNarudzbenicePom { detaljiNarudzbenice = detaljiDb, pica = picaDb, Narudzbenica = narudzbenicaDb };
         }

        else if (id!= null && nazivPice == null)
            { return from detaljiDb in _dbContext.DetaljiNarudzbenice
                     join picaDb in _dbContext.Pice on detaljiDb.PicaID equals picaDb.PicaID
                     join narudzbenicaDb in _dbContext.Narudzbenica on detaljiDb.NarudzbenicaID equals narudzbenicaDb.NarudzbenicaID
                     where detaljiDb.DetaljiNarudzbeniceID == id
                     select new DetaljiNarudzbenicePom { detaljiNarudzbenice = detaljiDb, pica = picaDb, Narudzbenica = narudzbenicaDb };
            }
            else
            {
                return from detaljiDb in _dbContext.DetaljiNarudzbenice
                       join picaDb in _dbContext.Pice on detaljiDb.PicaID equals picaDb.PicaID
                       join narudzbenicaDb in _dbContext.Narudzbenica on detaljiDb.NarudzbenicaID equals narudzbenicaDb.NarudzbenicaID
                       where picaDb.NazivPice== nazivPice
                       select new DetaljiNarudzbenicePom { detaljiNarudzbenice = detaljiDb, pica = picaDb, Narudzbenica = narudzbenicaDb };
            }
        }

}
}
