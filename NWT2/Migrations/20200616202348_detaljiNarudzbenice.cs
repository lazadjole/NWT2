using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class detaljiNarudzbenice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pice",
                columns: table => new
                {
                    ID_Pice = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    NazivPice = table.Column<string>(maxLength: 18, nullable: false),
                    Kratak_opis = table.Column<string>(maxLength: 18, nullable: false),
                    Cena = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pice", x => x.ID_Pice);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiNarudzbenica",
                columns: table => new
                {
                    ID_DetNarudzbenice = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PicaID = table.Column<Guid>(nullable: false),
                    NarudzbenicaID = table.Column<Guid>(nullable: false),
                    Kolicina = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiNarudzbenica", x => x.ID_DetNarudzbenice);
                    table.ForeignKey(
                        name: "FK_DetaljiNarudzbenica_Narudzbenice_NarudzbenicaID",
                        column: x => x.NarudzbenicaID,
                        principalTable: "Narudzbenice",
                        principalColumn: "ID_Narudzbenice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaljiNarudzbenica_Pice_PicaID",
                        column: x => x.PicaID,
                        principalTable: "Pice",
                        principalColumn: "ID_Pice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiNarudzbenica_NarudzbenicaID",
                table: "DetaljiNarudzbenica",
                column: "NarudzbenicaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiNarudzbenica_PicaID",
                table: "DetaljiNarudzbenica",
                column: "PicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaljiNarudzbenica");

            migrationBuilder.DropTable(
                name: "Pice");
        }
    }
}
