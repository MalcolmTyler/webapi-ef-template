using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Summaries",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Summaries");
        }
    }
}
