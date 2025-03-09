using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 905, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 3, 9, 17, 46, 47, 907, DateTimeKind.Local).AddTicks(9913));
        }
    }
}
