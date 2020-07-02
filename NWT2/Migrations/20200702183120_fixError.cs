using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWT2.Migrations
{
    public partial class fixError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbenice_NaciniPlacanja_NacinPlacanjaID",
                table: "Narudzbenice");

            migrationBuilder.DropTable(
                name: "NaciniPlacanja");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbenice_NacinPlacanjaID",
                table: "Narudzbenice");

            migrationBuilder.DropColumn(
                name: "NacinPlacanjaID",
                table: "Narudzbenice");

            migrationBuilder.AddColumn<string>(
                name: "NacinPlacanja",
                table: "Narudzbenice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NacinPlacanja",
                table: "Narudzbenice");

            migrationBuilder.AddColumn<Guid>(
                name: "NacinPlacanjaID",
                table: "Narudzbenice",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NaciniPlacanja",
                columns: table => new
                {
                    ID_NacinPlacanja = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivNacinaPlacanja = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaciniPlacanja", x => x.ID_NacinPlacanja);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_NacinPlacanjaID",
                table: "Narudzbenice",
                column: "NacinPlacanjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbenice_NaciniPlacanja_NacinPlacanjaID",
                table: "Narudzbenice",
                column: "NacinPlacanjaID",
                principalTable: "NaciniPlacanja",
                principalColumn: "ID_NacinPlacanja",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
