using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class cetvrtaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Treatments",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LabTestingId",
                table: "LabTestTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AdditionalNotes", "Date", "Discriminator", "Type" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LabTesting", 0 });

            migrationBuilder.UpdateData(
                table: "LabTestTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LabTestingId", "TestName" },
                values: new object[] { 1, "LDL" });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestTypes_LabTestingId",
                table: "LabTestTypes",
                column: "LabTestingId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTestTypes_Treatments_LabTestingId",
                table: "LabTestTypes",
                column: "LabTestingId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTestTypes_Treatments_LabTestingId",
                table: "LabTestTypes");

            migrationBuilder.DropIndex(
                name: "IX_LabTestTypes_LabTestingId",
                table: "LabTestTypes");

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "LabTestingId",
                table: "LabTestTypes");

            migrationBuilder.UpdateData(
                table: "LabTestTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TestName",
                value: "LDL i HDL");
        }
    }
}
