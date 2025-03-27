using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class statusplantholding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "PlantHoldings",
                columns: table => new
                {
                    HoldingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustID = table.Column<int>(type: "int", nullable: true),
                    PlantNameID = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    HasSubPlant = table.Column<bool>(type: "bit", nullable: true),
                    SWL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantHoldingHoldingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantHoldings", x => x.HoldingID);
                    table.ForeignKey(
                        name: "FK_PlantHoldings_AllPlant_PlantNameID",
                        column: x => x.PlantNameID,
                        principalTable: "AllPlant",
                        principalColumn: "PlantNameID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlantHoldings_Customers_CustID",
                        column: x => x.CustID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlantHoldings_PlantHoldings_PlantHoldingHoldingID",
                        column: x => x.PlantHoldingHoldingID,
                        principalTable: "PlantHoldings",
                        principalColumn: "HoldingID");
                    table.ForeignKey(
                        name: "FK_PlantHoldings_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantHoldings_CustID",
                table: "PlantHoldings",
                column: "CustID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantHoldings_PlantHoldingHoldingID",
                table: "PlantHoldings",
                column: "PlantHoldingHoldingID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantHoldings_PlantNameID",
                table: "PlantHoldings",
                column: "PlantNameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantHoldings_StatusID",
                table: "PlantHoldings",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantHoldings");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
