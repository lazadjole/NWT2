using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class ekstraDodaci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dodaci",
                columns: table => new
                {
                    ID_Dodaci = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Naziv_dodatka = table.Column<string>(maxLength: 18, nullable: false),
                    Cena = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dodaci", x => x.ID_Dodaci);
                });

            migrationBuilder.CreateTable(
                name: "EkstraDodaci",
                columns: table => new
                {
                    ID_Dodaci = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    DodatakID = table.Column<Guid>(nullable: false),
                    DetaljiNarudzbeniceID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkstraDodaci", x => x.ID_Dodaci);
                    table.ForeignKey(
                        name: "FK_EkstraDodaci_DetaljiNarudzbenica_DetaljiNarudzbeniceID",
                        column: x => x.DetaljiNarudzbeniceID,
                        principalTable: "DetaljiNarudzbenica",
                        principalColumn: "ID_DetNarudzbenice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkstraDodaci_Dodaci_DodatakID",
                        column: x => x.DodatakID,
                        principalTable: "Dodaci",
                        principalColumn: "ID_Dodaci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EkstraDodaci_DetaljiNarudzbeniceID",
                table: "EkstraDodaci",
                column: "DetaljiNarudzbeniceID");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraDodaci_DodatakID",
                table: "EkstraDodaci",
                column: "DodatakID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EkstraDodaci");

            migrationBuilder.DropTable(
                name: "Dodaci");
        }
    }
}
