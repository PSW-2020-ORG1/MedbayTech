using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegisteredUserId",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    PolicyStartDate = table.Column<DateTime>(nullable: false),
                    PolicyEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Apartment = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    EducationLevel = table.Column<int>(nullable: false),
                    Profession = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    PlaceOfBirthId = table.Column<int>(nullable: true),
                    CurrResidenceId = table.Column<int>(nullable: true),
                    InsurancePolicyId = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredUser_Address_CurrResidenceId",
                        column: x => x.CurrResidenceId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUser_InsurancePolicy_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUser_City_PlaceOfBirthId",
                        column: x => x.PlaceOfBirthId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUser_CurrResidenceId",
                table: "RegisteredUser",
                column: "CurrResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUser_InsurancePolicyId",
                table: "RegisteredUser",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUser_PlaceOfBirthId",
                table: "RegisteredUser",
                column: "PlaceOfBirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RegisteredUser_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RegisteredUser_RegisteredUserId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "RegisteredUser");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "InsurancePolicy");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_RegisteredUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "RegisteredUserId",
                table: "Feedbacks");
        }
    }
}
