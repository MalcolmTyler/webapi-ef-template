using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantAndCategoryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AllPlant",
                columns: table => new
                {
                    PlantNameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantCategory = table.Column<int>(type: "int", nullable: true),
                    PlantDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalPrice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllPlant", x => x.PlantNameID);
                    table.ForeignKey(
                        name: "FK_AllPlant_PlantCategories_PlantCategory",
                        column: x => x.PlantCategory,
                        principalTable: "PlantCategories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllPlant_PlantCategory",
                table: "AllPlant",
                column: "PlantCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllPlant");

            migrationBuilder.DropTable(
                name: "PlantCategories");
        }
    }
}
