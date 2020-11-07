using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class HopeReturns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowedForPublishing",
                table: "Feedbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "AllowedForPublishing",
                value: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "AllowedForPublishing",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedForPublishing",
                table: "Feedbacks");
        }
    }
}
