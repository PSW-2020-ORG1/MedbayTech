using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class trecaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anonymous",
                table: "Feedbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LabTestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LabTestTypes",
                columns: new[] { "Id", "TestName" },
                values: new object[] { 1, "LDL i HDL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestTypes");

            migrationBuilder.DropColumn(
                name: "Anonymous",
                table: "Feedbacks");
        }
    }
}
