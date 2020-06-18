using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class tipVozila_vozilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoviVozila",
                columns: table => new
                {
                    ID_tipVozila = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    vrstaVozila = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviVozila", x => x.ID_tipVozila);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    ID_Vozila = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TipVozilaID = table.Column<Guid>(nullable: false),
                    EvidencioniBr = table.Column<string>(maxLength: 15, nullable: false),
                    MarkaVozila = table.Column<string>(maxLength: 10, nullable: false),
                    DetaljiVozila = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.ID_Vozila);
                    table.ForeignKey(
                        name: "FK_Vozilo_TipoviVozila_TipVozilaID",
                        column: x => x.TipVozilaID,
                        principalTable: "TipoviVozila",
                        principalColumn: "ID_tipVozila",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_TipVozilaID",
                table: "Vozilo",
                column: "TipVozilaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "TipoviVozila");
        }
    }
}
