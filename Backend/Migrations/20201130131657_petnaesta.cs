using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class petnaesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: "2406978890047",
                columns: new[] { "ExaminationRoomId", "OperationRoomId" },
                values: new object[] { 1003, 1114 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: "2406978890047",
                columns: new[] { "ExaminationRoomId", "OperationRoomId" },
                values: new object[] { 1, 2 });
        }
    }
}
