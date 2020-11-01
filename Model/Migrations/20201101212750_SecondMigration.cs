using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anonymous",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "EverythingInGoodPlace",
                table: "Feedbacks");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "AdditionalNotes", "Approved", "Date", "RegisteredUserId" },
                values: new object[] { 1, "Sve je super!", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2406978890045" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "Anonymous",
                table: "Feedbacks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EverythingInGoodPlace",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
