using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test_webapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactFirstNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Line4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mailshot = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustID", "CompanyName", "ContactFirstNames", "ContactSurname", "ContactTitle", "Email", "Fax", "Line1", "Line2", "Line3", "Line4", "Mailshot", "Postcode", "Telephone" },
                values: new object[,]
                {
                    { 1, "Company A", "John", "Doe", "Mr.", "john.doe@companya.com", "123-456-7891", "123 Main St", "", "", "", true, "12345", "123-456-7890" },
                    { 2, "Company B", "Jane", "Smith", "Ms.", "jane.smith@companyb.com", "987-654-3211", "456 Elm St", "", "", "", false, "67890", "987-654-3210" },
                    { 3, "Company C", "Alice", "Johnson", "Dr.", "alice.johnson@companyc.com", "555-555-5556", "789 Oak St", "", "", "", true, "54321", "555-555-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
