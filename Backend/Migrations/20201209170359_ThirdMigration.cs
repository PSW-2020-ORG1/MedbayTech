using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipments_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentType",
                table: "EquipmentType");

            migrationBuilder.RenameTable(
                name: "EquipmentType",
                newName: "EquipmentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentTypes",
                table: "EquipmentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipments_EquipmentTypes_EquipmentTypeId",
                table: "HospitalEquipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipments_EquipmentTypes_EquipmentTypeId",
                table: "HospitalEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentTypes",
                table: "EquipmentTypes");

            migrationBuilder.RenameTable(
                name: "EquipmentTypes",
                newName: "EquipmentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentType",
                table: "EquipmentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipments_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
