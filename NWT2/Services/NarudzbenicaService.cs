using Microsoft.EntityFrameworkCore;
using NWT2.Entities;
using NWT2.Migrations;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<Models.Narudzbenica> GetNarudzbenicaByIdAsync(Guid id, CancellationToken ct)
        {
            var query = queryForm(id, null, null, null, null);

            var rezulata = await query.FirstAsync();

            if (rezulata == null) return null;

            return _mapper.Map<Entities.Narudzbenica, Models.Narudzbenica>(rezulata.Narudzbenica);
        }

        public async Task<PagedResults<Models.Narudzbenica>> GetNarudzbeniceAsync(CancellationToken ct, PaginigOptions paginigOptions, NarudzbenicaOptions narudzbenicaOptions)
        {
            var query = queryForm(null, narudzbenicaOptions.imeZaposleng, narudzbenicaOptions.prezimeZaposlenog, narudzbenicaOptions.statusDostave, narudzbenicaOptions.datumPrijema);

            var narudzbenice = await query.ToArrayAsync();
            if (narudzbenice == null) return null;
            List<Entities.Narudzbenica> narudzbenicesList = new List<Entities.Narudzbenica>();
            foreach (var prom in narudzbenice)
            {
                narudzbenicesList.Add(prom.Narudzbenica);
            }
            var narudzbenicaMap= _mapper.Map<IEnumerable<Entities.Narudzbenica>, IEnumerable<Models.Narudzbenica>>(narudzbenicesList);

            var narudzbenicaPagin = narudzbenicaMap.Skip(paginigOptions.Offset.Value).Take(paginigOptions.Limit.Value);

            return new PagedResults<Models.Narudzbenica>
            {
                Items = narudzbenicaPagin,
                TotalSize = narudzbenicaMap.Count()
            };

            
        }
        public IQueryable<NarudzbenicaPom> queryForm(Guid? id, string imeZaposlenog, string prezimeZaposlenog, string statusDostave, DateTime? datumPrijema)
        {
            if (id == null && imeZaposlenog == null && prezimeZaposlenog == null && statusDostave == null && datumPrijema == null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };

            }
            else if (id != null && imeZaposlenog == null && prezimeZaposlenog == null && statusDostave == null && datumPrijema == null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where narudzbenicaDbo.NarudzbenicaID == id
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }

            else if (id == null && imeZaposlenog != null && prezimeZaposlenog != null && statusDostave == null && datumPrijema == null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where zaposleniDbo.Ime == imeZaposlenog && zaposleniDbo.Prezime == prezimeZaposlenog
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }
            else if (id == null && imeZaposlenog != null && prezimeZaposlenog != null && statusDostave != null && datumPrijema == null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where zaposleniDbo.Ime == imeZaposlenog && zaposleniDbo.Prezime == prezimeZaposlenog && statusDostavedbo.NazivStatusa == statusDostave
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }
            else if (id == null && imeZaposlenog != null && prezimeZaposlenog != null && statusDostave != null && datumPrijema != null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where zaposleniDbo.Ime == imeZaposlenog && zaposleniDbo.Prezime == prezimeZaposlenog && narudzbenicaDbo.datumPrijema == datumPrijema
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }
            else if (id == null && imeZaposlenog == null && prezimeZaposlenog == null && statusDostave != null && datumPrijema == null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where statusDostavedbo.NazivStatusa == statusDostave
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }
            else if (id == null && imeZaposlenog == null && prezimeZaposlenog == null && statusDostave != null && datumPrijema != null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where statusDostavedbo.NazivStatusa == statusDostave && narudzbenicaDbo.datumPrijema == datumPrijema
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };
            }
            else if (id == null && imeZaposlenog == null && prezimeZaposlenog == null && statusDostave == null && datumPrijema != null)
            {
                return from narudzbenicaDbo in _dbContext.Narudzbenica
                       join kupacDbo in _dbContext.Kupci on narudzbenicaDbo.KupacID equals kupacDbo.KupacID
                       join zaposleniDbo in _dbContext.Zaposleni on narudzbenicaDbo.ZaposleniId equals zaposleniDbo.ZaposleniId
                       join statusDostavedbo in _dbContext.StatusDostave on narudzbenicaDbo.StatusDostaveID equals statusDostavedbo.StatusDostaveID
                       join voziloDb in _dbContext.Vozila on narudzbenicaDbo.VoziloID equals voziloDb.VoziloID
                       where narudzbenicaDbo.datumPrijema == datumPrijema
                       select new NarudzbenicaPom { Narudzbenica = narudzbenicaDbo, Kupac = kupacDbo, Zaposleni = zaposleniDbo, StatusDostave = statusDostavedbo, Vozilo = voziloDb };

            }
            else
            { return null; }

        }
    }
}
