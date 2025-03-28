using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class RestrictPlantDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantHoldings_AllPlant_PlantNameID",
                table: "PlantHoldings");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantHoldings_AllPlant_PlantNameID",
                table: "PlantHoldings",
                column: "PlantNameID",
                principalTable: "AllPlant",
                principalColumn: "PlantNameID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantHoldings_AllPlant_PlantNameID",
                table: "PlantHoldings");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantHoldings_AllPlant_PlantNameID",
                table: "PlantHoldings",
                column: "PlantNameID",
                principalTable: "AllPlant",
                principalColumn: "PlantNameID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
