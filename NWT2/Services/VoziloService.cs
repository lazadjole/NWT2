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

        public async Task<Guid> CreateVoziloAsync(CancellationToken ct, Guid tipVozila, string evidencioniBr, string markaVozila, string detaljiVozila)
        {
            Guid ID = Guid.NewGuid();
            var newVozilo = _dbContext.Vozila.Add(
                new Entities.Vozilo
                {
                    VoziloID=ID,
                    EvidencioniBr=evidencioniBr,
                    MarkaVozila=markaVozila,
                    DetaljiVozila=detaljiVozila,
                    TipVozilaID=tipVozila
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;
        }

        public async Task DeleteVoziloAsync(CancellationToken ct, Guid id)
        {
            var Vozilo = await _dbContext.Vozila.FirstOrDefaultAsync(x => x.VoziloID == id);
            if (Vozilo == null) return;

            _dbContext.Vozila.Remove(Vozilo);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<PagedResults<Vozilo>> GetVoziloAsync(CancellationToken ct, PaginigOptions paginigOptions)
        {    var vozilo = await _dbContext.Vozila.ToArrayAsync();
            if (vozilo == null) return null;

            var mapVozilo=  _mapper.Map<IEnumerable<Entities.Vozilo>, IEnumerable<Models.Vozilo>>(vozilo);

            var pagedVozilo = mapVozilo.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Vozilo>
            {
                Items = pagedVozilo,
                TotalSize = mapVozilo.Count()
            };

        }

        public async Task<Vozilo> GetVoziloByIdAsync(Guid id, CancellationToken ct)
        {
            var vozilo = await _dbContext.Vozila.FirstOrDefaultAsync(x => x.VoziloID == id);
            if (vozilo == null) return null;

            return _mapper.Map<Entities.Vozilo, Models.Vozilo>(vozilo);

        }
    }
}
