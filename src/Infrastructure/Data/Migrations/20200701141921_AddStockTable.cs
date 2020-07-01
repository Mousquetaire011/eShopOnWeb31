using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    public partial class AddStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankingOperations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationLabel = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    Credit = table.Column<double>(nullable: false),
                    Debit = table.Column<double>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    BankingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankingOperations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankingOperations_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogItemId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    Buyprice = table.Column<double>(nullable: false),
                    IsFull = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Catalog_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stock_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankingOperations_OrderId",
                table: "BankingOperations",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BankingOperations_SupplierId",
                table: "BankingOperations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CatalogItemId",
                table: "Stock",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SupplierId",
                table: "Stock",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankingOperations");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
