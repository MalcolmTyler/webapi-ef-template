using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddInspectionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    UniqueRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingID = table.Column<int>(type: "int", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleInspectedOn = table.Column<int>(type: "int", nullable: true),
                    RecentCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeWorking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Defects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rectified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiscNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasSubPlant = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.UniqueRef);
                    table.ForeignKey(
                        name: "FK_Inspections_PlantHoldings_HoldingID",
                        column: x => x.HoldingID,
                        principalTable: "PlantHoldings",
                        principalColumn: "HoldingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_HoldingID",
                table: "Inspections",
                column: "HoldingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
