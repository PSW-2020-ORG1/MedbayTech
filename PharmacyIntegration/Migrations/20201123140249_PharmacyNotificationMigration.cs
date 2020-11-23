using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyIntegration.Migrations
{
    public partial class PharmacyNotificationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    PharmacyID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyNotifications_Pharmacies_PharmacyID",
                        column: x => x.PharmacyID,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PharmacyNotifications",
                columns: new[] { "Id", "Approved", "Content", "PharmacyID" },
                values: new object[] { 1, true, "Aspirin nam je jeftin. Bas jako. Ide gaso!", "Jankovic" });

            migrationBuilder.InsertData(
                table: "PharmacyNotifications",
                columns: new[] { "Id", "Approved", "Content", "PharmacyID" },
                values: new object[] { 2, true, "Brufen nam je jeftin. Bas jako. Ide gaso!", "Liman" });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyNotifications_PharmacyID",
                table: "PharmacyNotifications",
                column: "PharmacyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyNotifications");
        }
    }
}
