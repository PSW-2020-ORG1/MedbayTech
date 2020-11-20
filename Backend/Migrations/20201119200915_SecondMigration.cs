using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_Surveys_SurveyId",
                table: "SurveyQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RegisteredUsers_PatientId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_PatientId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions");

            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "SurveyQuestions");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyQuestions");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "SurveyQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SurveyQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SurveyId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    SurveyQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Question", "QuestionType", "Status" },
                values: new object[] { 1, "Rate work of Doctor", 0, true });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Surveys",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyId",
                table: "SurveyAnswer",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Appointments_AppointmentId",
                table: "Surveys",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Appointments_AppointmentId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Surveys");

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "SurveyQuestions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SurveyQuestions");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "Surveys",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AverageGrade",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Surveys",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "SurveyQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "SurveyQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PatientId",
                table: "Surveys",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_Surveys_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RegisteredUsers_PatientId",
                table: "Surveys",
                column: "PatientId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
