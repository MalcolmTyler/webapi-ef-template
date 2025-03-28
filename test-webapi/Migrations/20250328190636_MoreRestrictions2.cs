using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class MoreRestrictions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllPlant_PlantCategories_PlantCategory",
                table: "AllPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantHoldings_Customers_CustID",
                table: "PlantHoldings");

            migrationBuilder.AddForeignKey(
                name: "FK_AllPlant_PlantCategories_PlantCategory",
                table: "AllPlant",
                column: "PlantCategory",
                principalTable: "PlantCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantHoldings_Customers_CustID",
                table: "PlantHoldings",
                column: "CustID",
                principalTable: "Customers",
                principalColumn: "CustID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllPlant_PlantCategories_PlantCategory",
                table: "AllPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantHoldings_Customers_CustID",
                table: "PlantHoldings");

            migrationBuilder.AddForeignKey(
                name: "FK_AllPlant_PlantCategories_PlantCategory",
                table: "AllPlant",
                column: "PlantCategory",
                principalTable: "PlantCategories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantHoldings_Customers_CustID",
                table: "PlantHoldings",
                column: "CustID",
                principalTable: "Customers",
                principalColumn: "CustID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
