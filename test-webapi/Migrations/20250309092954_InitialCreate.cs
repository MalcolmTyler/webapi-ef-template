using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Summaries",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Freezing" },
                    { 2, "Bracing" },
                    { 3, "Chilly" },
                    { 4, "Cool" },
                    { 5, "Mild" },
                    { 6, "Warm" },
                    { 7, "Balmy" },
                    { 8, "Hot" },
                    { 9, "Sweltering" },
                    { 10, "Scorching" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summaries");
        }
    }
}
