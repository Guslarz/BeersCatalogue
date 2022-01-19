using Kaczmarek.BeersCatalogue.Core;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kaczmarek.BeersCatalogue.DaoSql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    BreweryId = table.Column<int>(nullable: true),
                    Ibu = table.Column<int>(nullable: false),
                    Abv = table.Column<double>(nullable: false),
                    Style = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "Name", "City" },
                values: new object[,]
                {
                    { 1, "Pinta", "Wieprz" },
                    { 2, "Browar Fortuna", "Miłosław" },
                    { 3, "Browar Za Miastem", "Rumianek" }
                }
            );

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "Name", "BreweryId", "Ibu", "Abv", "Style" },
                values: new object[,]
                {
                    { 1, "Atak Chmielu", 1, 58, 0.061, (int) BeerStyle.Ipa },
                    { 2, "Na Wypasie", 3, 35, 0.045, (int) BeerStyle.Ipa },
                    { 3, "Dobra Noc", 3, 30, 0.058, (int) BeerStyle.Stout },
                    { 4, "Komes Porter Bałtycki", 2, 35, 0.09, (int) BeerStyle.Porter },
                    { 5, "Miłosław Witbier", 2, 17, 0.048, (int) BeerStyle.Other },
                    { 6, "Własne Sprawy", 3, 45, 0.056, (int) BeerStyle.Apa },
                    { 7, "Miłosław Chmielowy Lager", 2, 27, 0.045, (int) BeerStyle.Lager }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
