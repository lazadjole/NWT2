using Microsoft.EntityFrameworkCore;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWT2.Services
{
    public class AdresaService : IAdresaService
    {
        private readonly PicerijaDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public AdresaService(PicerijaDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAdresaAsync(CancellationToken ct, string ulica, int broj, string grad)
        {
            Guid ID =Guid.NewGuid();
            var newAdresa = _dbContext.Adrese.Add(
                new Entities.Adresa
                {
                    AdresaID = ID,
                    Broj = broj,
                    Grad = grad,
                    Ulica = ulica
                }
                );

            var created = await _dbContext.SaveChangesAsync(ct);

            if (created < 1) throw new InvalidOperationException("Can't created new resource");

            return ID;

        }

        public async Task DeleteAdresaAsync(CancellationToken ct, Guid id)
        {
            var adresa = await _dbContext.Adrese.FirstOrDefaultAsync(x => x.AdresaID == id);
            if (adresa == null) return ;

            _dbContext.Adrese.Remove(adresa);
            await _dbContext.SaveChangesAsync(ct);

        }

        public async Task<Models.Adresa> GetAdresaByIdAsync(Guid id, CancellationToken ct)
        {
            var adresa = await _dbContext.Adrese.FirstOrDefaultAsync(x => x.AdresaID == id);
          
            if (adresa == null) return null;

            return _mapper.Map<Entities.Adresa, Models.Adresa>(adresa);
        }

        public async Task<PagedResults<Adresa>> GetAdreseAsync(CancellationToken ct,  PaginigOptions paginigOptions)
        {
            var adrese = await _dbContext.Adrese.ToArrayAsync();
            if (adrese == null) return null;

            var mapAdress = _mapper.Map<IEnumerable<Entities.Adresa>, IEnumerable<Models.Adresa>>(adrese);

            var pagedAdress = mapAdress.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);


            return new PagedResults<Adresa>
            { 
                Items= pagedAdress,
                TotalSize=mapAdress.Count()
            } ;

        }
    }
}
