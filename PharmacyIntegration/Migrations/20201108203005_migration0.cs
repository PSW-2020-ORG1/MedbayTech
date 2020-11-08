using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyIntegration.Migrations
{
    public partial class migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    APIKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "APIKey" },
                values: new object[] { "Jankovic", "ID1APIKEYAAAA" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "APIKey" },
                values: new object[] { "Liman", "ID2APIKEYAAAA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
