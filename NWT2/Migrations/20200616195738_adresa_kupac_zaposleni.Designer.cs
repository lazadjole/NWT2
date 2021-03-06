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
    [Migration("20200616195738_adresa_kupac_zaposleni")]
    partial class adresa_kupac_zaposleni
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
