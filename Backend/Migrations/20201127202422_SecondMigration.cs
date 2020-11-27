using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Medications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.UpdateData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Dosage", "RoomId" },
                values: new object[] { "400mg", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_RoomId",
                table: "Medications",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Rooms_RoomId",
                table: "Medications",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Rooms_RoomId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_RoomId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Medications");
        }
    }
}
