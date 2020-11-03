using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    PolicyStartDate = table.Column<DateTime>(nullable: false),
                    PolicyEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AdditionalNotes = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Apartment = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlaceOfBirthId = table.Column<int>(nullable: false),
                    CurrResidenceId = table.Column<int>(nullable: false),
                    InsurancePolicyId = table.Column<string>(nullable: true),
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
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Addresses_CurrResidenceId",
                        column: x => x.CurrResidenceId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Cities_PlaceOfBirthId",
                        column: x => x.PlaceOfBirthId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AdditionalNotes = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    RegisteredUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "InsurancePolicies",
                columns: new[] { "Id", "Company", "PolicyEndDate", "PolicyStartDate" },
                values: new object[] { "policy1", "Dunav osiguranje d.o.o", new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Serbia" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 21000, "Novi Sad", 1L });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 11000, "Beograd", 1L });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "CityId", "Floor", "Number", "Street" },
                values: new object[] { 1, 0, 21000, 0, 4, "Radnicka" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "CityId", "Floor", "Number", "Street" },
                values: new object[] { 2, 0, 11000, 0, 5, "Gospodara Vucica" });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username" },
                values: new object[] { "2406978890045", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "marko@gmail.com", 0, "policy1", "Marko", "marko1978", "065/123-4554", 11000, "vodoinstalater", ".", "Markovic", "markic" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "AdditionalNotes", "Approved", "Date", "RegisteredUserId" },
                values: new object[] { 1, "Sve je super!", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2406978890045" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_CurrResidenceId",
                table: "RegisteredUsers",
                column: "CurrResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_InsurancePolicyId",
                table: "RegisteredUsers",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_PlaceOfBirthId",
                table: "RegisteredUsers",
                column: "PlaceOfBirthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
