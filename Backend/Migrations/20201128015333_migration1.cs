using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationUsageReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationUsageReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationUsage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usage = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true),
                    MedicationUsageReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationUsage_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicationUsage_MedicationUsageReports_MedicationUsageReport~",
                        column: x => x.MedicationUsageReportId,
                        principalTable: "MedicationUsageReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUsage_MedicationId",
                table: "MedicationUsage",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUsage_MedicationUsageReportId",
                table: "MedicationUsage",
                column: "MedicationUsageReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationUsage");

            migrationBuilder.DropTable(
                name: "MedicationUsageReports");
        }
    }
}
