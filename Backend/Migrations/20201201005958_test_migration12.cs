using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class test_migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipment_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipment_Rooms_RoomId",
                table: "HospitalEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEquipment",
                table: "HospitalEquipment");

            migrationBuilder.RenameTable(
                name: "HospitalEquipment",
                newName: "HospitalEquipments");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEquipment_RoomId",
                table: "HospitalEquipments",
                newName: "IX_HospitalEquipments_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEquipment_EquipmentTypeId",
                table: "HospitalEquipments",
                newName: "IX_HospitalEquipments_EquipmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEquipments",
                table: "HospitalEquipments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipments_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipments_Rooms_RoomId",
                table: "HospitalEquipments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipments_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEquipments_Rooms_RoomId",
                table: "HospitalEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEquipments",
                table: "HospitalEquipments");

            migrationBuilder.RenameTable(
                name: "HospitalEquipments",
                newName: "HospitalEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEquipments_RoomId",
                table: "HospitalEquipment",
                newName: "IX_HospitalEquipment_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEquipments_EquipmentTypeId",
                table: "HospitalEquipment",
                newName: "IX_HospitalEquipment_EquipmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEquipment",
                table: "HospitalEquipment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipment_EquipmentType_EquipmentTypeId",
                table: "HospitalEquipment",
                column: "EquipmentTypeId",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEquipment_Rooms_RoomId",
                table: "HospitalEquipment",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
