using Microsoft.EntityFrameworkCore;
using NWT2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class PicerijaDbContext: DbContext
    {
        public PicerijaDbContext(DbContextOptions<PicerijaDbContext> options) : base(options)
        {

        }

        public DbSet<Entities.Adresa> Adrese { get; set; }
        public DbSet<Entities.Kupac> Kupci { get; set; }

        public DbSet<Entities.Zaposleni> Zaposleni { get; set; }

        public DbSet<Entities.TipVozila> TipVozila { get; set; }

        public DbSet<Entities.Vozilo> Vozila { get; set; }

        public DbSet<Entities.NacinPlacanja> NacinPlacanja { get; set; }

        public DbSet<Entities.Narudzbenica> Narudzbenica { get; set; }

        public DbSet<Entities.StatusDostave> StatusDostave { get; set; }

        public DbSet<DetaljiNarudzbenice> DetaljiNarudzbenice { get; set; }

        public DbSet<Pica> Pice { get; set; }


    }
}
