using Microsoft.EntityFrameworkCore.Migrations;

namespace StockData.Worker.Migrations
{
    public partial class OneToManyBetweenCompanyAndStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                unique: true);
        }
    }
}
