using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    public partial class ProvidersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogHasProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDelayDays = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    catalogId = table.Column<int>(nullable: false),
                    providerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogHasProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<decimal>(nullable: false),
                    AddressNumber = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<int>(nullable: false),
                    AddressPostcode = table.Column<int>(nullable: false),
                    AddressCity = table.Column<int>(nullable: false),
                    Siren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogHasProviders");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
