using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RegisteredUser_RegisteredUserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUser_Address_CurrResidenceId",
                table: "RegisteredUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUser_InsurancePolicy_InsurancePolicyId",
                table: "RegisteredUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUser_City_PlaceOfBirthId",
                table: "RegisteredUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredUser",
                table: "RegisteredUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "RegisteredUser",
                newName: "RegisteredUsers");

            migrationBuilder.RenameTable(
                name: "InsurancePolicy",
                newName: "InsurancePolicies");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUser_PlaceOfBirthId",
                table: "RegisteredUsers",
                newName: "IX_RegisteredUsers_PlaceOfBirthId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUser_InsurancePolicyId",
                table: "RegisteredUsers",
                newName: "IX_RegisteredUsers_InsurancePolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUser_CurrResidenceId",
                table: "RegisteredUsers",
                newName: "IX_RegisteredUsers_CurrResidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_City_StateId",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RegisteredUsers_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUsers_Addresses_CurrResidenceId",
                table: "RegisteredUsers",
                column: "CurrResidenceId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUsers_InsurancePolicies_InsurancePolicyId",
                table: "RegisteredUsers",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUsers_Cities_PlaceOfBirthId",
                table: "RegisteredUsers",
                column: "PlaceOfBirthId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RegisteredUsers_RegisteredUserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUsers_Addresses_CurrResidenceId",
                table: "RegisteredUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUsers_InsurancePolicies_InsurancePolicyId",
                table: "RegisteredUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUsers_Cities_PlaceOfBirthId",
                table: "RegisteredUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "RegisteredUsers",
                newName: "RegisteredUser");

            migrationBuilder.RenameTable(
                name: "InsurancePolicies",
                newName: "InsurancePolicy");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUsers_PlaceOfBirthId",
                table: "RegisteredUser",
                newName: "IX_RegisteredUser_PlaceOfBirthId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUsers_InsurancePolicyId",
                table: "RegisteredUser",
                newName: "IX_RegisteredUser_InsurancePolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredUsers_CurrResidenceId",
                table: "RegisteredUser",
                newName: "IX_RegisteredUser_CurrResidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                table: "City",
                newName: "IX_City_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Address",
                newName: "IX_Address_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredUser",
                table: "RegisteredUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RegisteredUser_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUser_Address_CurrResidenceId",
                table: "RegisteredUser",
                column: "CurrResidenceId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUser_InsurancePolicy_InsurancePolicyId",
                table: "RegisteredUser",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUser_City_PlaceOfBirthId",
                table: "RegisteredUser",
                column: "PlaceOfBirthId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
