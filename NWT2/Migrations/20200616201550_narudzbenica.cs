using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class narudzbenica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaciniPlacanja",
                columns: table => new
                {
                    ID_NacinPlacanja = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    NazivNacinaPlacanja = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaciniPlacanja", x => x.ID_NacinPlacanja);
                });

            migrationBuilder.CreateTable(
                name: "statusiDostave",
                columns: table => new
                {
                    ID_statusa = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    NazivStatusa = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusiDostave", x => x.ID_statusa);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbenice",
                columns: table => new
                {
                    ID_Narudzbenice = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BrojNarudzbenice = table.Column<string>(maxLength: 15, nullable: false),
                    KupacID = table.Column<Guid>(nullable: false),
                    ZaposleniId = table.Column<Guid>(nullable: false),
                    StatusDostaveID = table.Column<Guid>(nullable: false),
                    NacinPlacanjaID = table.Column<Guid>(nullable: true),
                    datumPrijema = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    VoziloID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbenice", x => x.ID_Narudzbenice);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "ID_Kupca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_NaciniPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NaciniPlacanja",
                        principalColumn: "ID_NacinPlacanja",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_statusiDostave_StatusDostaveID",
                        column: x => x.StatusDostaveID,
                        principalTable: "statusiDostave",
                        principalColumn: "ID_statusa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "ID_Vozila",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_Zaposleni_ZaposleniId",
                        column: x => x.ZaposleniId,
                        principalTable: "Zaposleni",
                        principalColumn: "ID_zaposlen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_KupacID",
                table: "Narudzbenice",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_NacinPlacanjaID",
                table: "Narudzbenice",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_StatusDostaveID",
                table: "Narudzbenice",
                column: "StatusDostaveID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_VoziloID",
                table: "Narudzbenice",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_ZaposleniId",
                table: "Narudzbenice",
                column: "ZaposleniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narudzbenice");

            migrationBuilder.DropTable(
                name: "NaciniPlacanja");

            migrationBuilder.DropTable(
                name: "statusiDostave");
        }
    }
}
