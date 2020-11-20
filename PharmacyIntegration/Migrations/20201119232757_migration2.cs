using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyIntegration.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "APIEndpoint",
                table: "Pharmacies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: "Jankovic",
                column: "APIEndpoint",
                value: "jankovic.rs");

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: "Liman",
                column: "APIEndpoint",
                value: "liman.li");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APIEndpoint",
                table: "Pharmacies");
        }
    }
}
