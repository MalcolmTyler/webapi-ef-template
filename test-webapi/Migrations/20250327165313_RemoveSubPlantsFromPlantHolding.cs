using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSubPlantsFromPlantHolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantHoldings_PlantHoldings_PlantHoldingHoldingID",
                table: "PlantHoldings");

            migrationBuilder.DropIndex(
                name: "IX_PlantHoldings_PlantHoldingHoldingID",
                table: "PlantHoldings");

            migrationBuilder.DropColumn(
                name: "HasSubPlant",
                table: "PlantHoldings");

            migrationBuilder.DropColumn(
                name: "PlantHoldingHoldingID",
                table: "PlantHoldings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSubPlant",
                table: "PlantHoldings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantHoldingHoldingID",
                table: "PlantHoldings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantHoldings_PlantHoldingHoldingID",
                table: "PlantHoldings",
                column: "PlantHoldingHoldingID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantHoldings_PlantHoldings_PlantHoldingHoldingID",
                table: "PlantHoldings",
                column: "PlantHoldingHoldingID",
                principalTable: "PlantHoldings",
                principalColumn: "HoldingID");
        }
    }
}
