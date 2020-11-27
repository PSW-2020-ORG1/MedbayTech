using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyNotifications_Pharmacies_PharmacyID",
                table: "PharmacyNotifications");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyNotifications_PharmacyID",
                table: "PharmacyNotifications");

            migrationBuilder.DropColumn(
                name: "PharmacyID",
                table: "PharmacyNotifications");

            migrationBuilder.UpdateData(
                table: "PharmacyNotifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Aspirin nam je jeftin. Bas jako.");

            migrationBuilder.UpdateData(
                table: "PharmacyNotifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Brufen nam je jeftin. Bas jako.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PharmacyID",
                table: "PharmacyNotifications",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PharmacyNotifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "PharmacyID" },
                values: new object[] { "Aspirin nam je jeftin. Bas jako. Ide gaso!", "Jankovic" });

            migrationBuilder.UpdateData(
                table: "PharmacyNotifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "PharmacyID" },
                values: new object[] { "Brufen nam je jeftin. Bas jako. Ide gaso!", "Liman" });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyNotifications_PharmacyID",
                table: "PharmacyNotifications",
                column: "PharmacyID");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyNotifications_Pharmacies_PharmacyID",
                table: "PharmacyNotifications",
                column: "PharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
