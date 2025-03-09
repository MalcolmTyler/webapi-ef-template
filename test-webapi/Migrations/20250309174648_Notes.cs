using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class Notes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteID);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteID", "CustID", "Date", "Notes" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 9, 17, 46, 47, 905, DateTimeKind.Local).AddTicks(5407), "Dummy note 1 for customer 1" },
                    { 2, 1, new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9838), "Dummy note 2 for customer 1" },
                    { 3, 2, new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9874), "Dummy note 1 for customer 2" },
                    { 4, 2, new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9907), "Dummy note 2 for customer 2" },
                    { 5, 3, new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9910), "Dummy note 1 for customer 3" },
                    { 6, 3, new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9913), "Dummy note 2 for customer 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
