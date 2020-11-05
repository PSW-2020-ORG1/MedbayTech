using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationCategory_Specialization_SpecializationId",
                table: "MedicationCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialization_RegisteredUsers_DoctorId",
                table: "Specialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "Specializations");

            migrationBuilder.RenameIndex(
                name: "IX_Specialization_DoctorId",
                table: "Specializations",
                newName: "IX_Specializations_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "DoctorId", "SpecializationName" },
                values: new object[] { 1, null, "Specijalista hirurgije" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationCategory_Specializations_SpecializationId",
                table: "MedicationCategory",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_RegisteredUsers_DoctorId",
                table: "Specializations",
                column: "DoctorId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationCategory_Specializations_SpecializationId",
                table: "MedicationCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_RegisteredUsers_DoctorId",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations");

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Specializations",
                newName: "Specialization");

            migrationBuilder.RenameIndex(
                name: "IX_Specializations_DoctorId",
                table: "Specialization",
                newName: "IX_Specialization_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationCategory_Specialization_SpecializationId",
                table: "MedicationCategory",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialization_RegisteredUsers_DoctorId",
                table: "Specialization",
                column: "DoctorId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
