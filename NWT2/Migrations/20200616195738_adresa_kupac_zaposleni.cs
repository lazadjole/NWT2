using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class adresa_kupac_zaposleni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    ID_Adrese = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Ulica = table.Column<string>(maxLength: 60, nullable: false),
                    Broj = table.Column<int>(nullable: false),
                    Grad = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.ID_Adrese);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    ID_Kupca = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Ime = table.Column<string>(maxLength: 18, nullable: false),
                    Prezime = table.Column<string>(maxLength: 18, nullable: false),
                    Telefon = table.Column<string>(maxLength: 18, nullable: false),
                    AdresaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.ID_Kupca);
                    table.ForeignKey(
                        name: "FK_Kupci_Adrese_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adrese",
                        principalColumn: "ID_Adrese",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    ID_zaposlen = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    AdresaID = table.Column<Guid>(nullable: false),
                    BrojTelefona = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.ID_zaposlen);
                    table.ForeignKey(
                        name: "FK_Zaposleni_Adrese_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adrese",
                        principalColumn: "ID_Adrese",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_AdresaID",
                table: "Kupci",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleni_AdresaID",
                table: "Zaposleni",
                column: "AdresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Adrese");
        }
    }
}
