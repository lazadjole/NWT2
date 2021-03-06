﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NWT2.Models;

namespace NWT2.Migrations
{
    [DbContext(typeof(PicerijaDbContext))]
    [Migration("20200616200635_tipVozila_vozilo")]
    partial class tipVozila_vozilo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NWT2.Entities.Adresa", b =>
                {
                    b.Property<Guid>("AdresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Adrese")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Broj")
                        .HasColumnType("int");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("AdresaID");

                    b.ToTable("Adrese");
                });

            modelBuilder.Entity("NWT2.Entities.Kupac", b =>
                {
                    b.Property<Guid>("KupacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Kupca")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.HasKey("KupacID");

                    b.HasIndex("AdresaID");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("NWT2.Entities.TipVozila", b =>
                {
                    b.Property<Guid>("TipVozilaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_tipVozila")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("vrstaVozila")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("TipVozilaID");

                    b.ToTable("TipoviVozila");
                });

            modelBuilder.Entity("NWT2.Entities.Vozilo", b =>
                {
                    b.Property<Guid>("VoziloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Vozila")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetaljiVozila")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("EvidencioniBr")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("MarkaVozila")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<Guid>("TipVozilaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VoziloID");

                    b.HasIndex("TipVozilaID");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("NWT2.Entities.Zaposleni", b =>
                {
                    b.Property<Guid>("ZaposleniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_zaposlen")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ZaposleniId");

                    b.HasIndex("AdresaID");

                    b.ToTable("Zaposleni");
                });

            modelBuilder.Entity("NWT2.Entities.Kupac", b =>
                {
                    b.HasOne("NWT2.Entities.Adresa", "Adresa")
                        .WithMany("Kupci")
                        .HasForeignKey("AdresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWT2.Entities.Vozilo", b =>
                {
                    b.HasOne("NWT2.Entities.TipVozila", "TipVozila")
                        .WithMany("Vozila")
                        .HasForeignKey("TipVozilaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NWT2.Entities.Zaposleni", b =>
                {
                    b.HasOne("NWT2.Entities.Adresa", "Adresa")
                        .WithMany("Zaposleni")
                        .HasForeignKey("AdresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
