using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

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
                name: "Medication",
                columns: table => new
                {
                    MedId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Med = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    MedicationMedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedId);
                    table.ForeignKey(
                        name: "FK_Medication_Medication_MedicationMedId",
                        column: x => x.MedicationMedId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Restrict);
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
                    Type = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DosageOfIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    MedicationIngredientId = table.Column<int>(nullable: false),
                    MedicationMedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageOfIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_Ingredients_MedicationIngredientId",
                        column: x => x.MedicationIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_Medication_MedicationMedId",
                        column: x => x.MedicationMedId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "LabTestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LabTestingId = table.Column<int>(nullable: false),
                    TestName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestTypes_Treatments_LabTestingId",
                        column: x => x.LabTestingId,
                        principalTable: "Treatments",
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
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospital_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantityInRoom = table.Column<int>(nullable: false),
                    QuantityInStorage = table.Column<int>(nullable: false),
                    RoomNumberIn = table.Column<int>(nullable: false),
                    EquipmentTypeId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalEquipment_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalEquipment_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Gender = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    WorkersID = table.Column<int>(nullable: true),
                    VacationLeave = table.Column<bool>(nullable: true),
                    CurrentlyWorking = table.Column<bool>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    OnCall = table.Column<bool>(nullable: true),
                    PatientReview = table.Column<double>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    ExaminationRoomId = table.Column<int>(nullable: true),
                    OperationRoomId = table.Column<int>(nullable: true),
                    IsGuestAccount = table.Column<bool>(nullable: true),
                    ChosenDoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Room_ExaminationRoomId",
                        column: x => x.ExaminationRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Room_OperationRoomId",
                        column: x => x.OperationRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_RegisteredUsers_ChosenDoctorId",
                        column: x => x.ChosenDoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Anonymous = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrHealthState = table.Column<int>(nullable: false),
                    BloodType = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    PatientId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_RegisteredUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecializationName = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialization_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Allergen = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: true),
                    MedicationMedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergens_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allergens_Medication_MedicationMedId",
                        column: x => x.MedicationMedId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyIllnessHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelativeMember = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyIllnessHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyIllnessHistories_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfTesting = table.Column<DateTime>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfResults_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HourConsumption = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapies_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Therapies_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    SpecializationId = table.Column<int>(nullable: false),
                    MedicationMedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCategory_Medication_MedicationMedId",
                        column: x => x.MedicationMedId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicationCategory_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FamilyIllnessHistoryId = table.Column<int>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_FamilyIllnessHistories_FamilyIllnessHistoryId",
                        column: x => x.FamilyIllnessHistoryId,
                        principalTable: "FamilyIllnessHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResultType = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    MaxRefValue = table.Column<double>(nullable: false),
                    MinRefValue = table.Column<double>(nullable: false),
                    ListOfResultsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabResults_ListOfResults_ListOfResultsId",
                        column: x => x.ListOfResultsId,
                        principalTable: "ListOfResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DiagnosisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SideEffect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Frequency = table.Column<int>(nullable: false),
                    SideEffectsId = table.Column<int>(nullable: false),
                    MedicationMedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideEffect_Medication_MedicationMedId",
                        column: x => x.MedicationMedId,
                        principalTable: "Medication",
                        principalColumn: "MedId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SideEffect_Symptoms_SideEffectsId",
                        column: x => x.SideEffectsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Allergen", "MedicalRecordId", "MedicationMedId" },
                values: new object[] { 1, "Amoksicilin", null, null });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "FamilyIllnessHistoryId", "MedicalRecordId", "Name" },
                values: new object[] { 1, null, null, "Dunav osiguranje d.o.o" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amoksicilin" },
                    { 2, "Kikiriki" }
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
                table: "Symptoms",
                columns: new[] { "Id", "DiagnosisId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Dunav osiguranje d.o.o" },
                    { 2, null, "Dunav  d.o.o" }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AdditionalNotes", "Date", "Discriminator", "Type" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LabTesting", 0 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 21000, "Novi Sad", 1L });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 11000, "Beograd", 1L });

            migrationBuilder.InsertData(
                table: "LabTestTypes",
                columns: new[] { "Id", "LabTestingId", "TestName" },
                values: new object[] { 1, 1, "LDL" });

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
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username" },
                values: new object[] { "2406978890045", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RegisteredUser", 2, "marko@gmail.com", 0, "policy1", "Marko", "marko1978", "065/123-4554", 11000, "vodoinstalater", ".", "Markovic", "markic" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "AdditionalNotes", "Anonymous", "Approved", "Date", "RegisteredUserId" },
                values: new object[] { 1, "Sve je super!", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2406978890045" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_MedicalRecordId",
                table: "Allergens",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_MedicationMedId",
                table: "Allergens",
                column: "MedicationMedId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_HospitalId",
                table: "Department",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_FamilyIllnessHistoryId",
                table: "Diagnoses",
                column: "FamilyIllnessHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_MedicalRecordId",
                table: "Diagnoses",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DosageOfIngredient_MedicationIngredientId",
                table: "DosageOfIngredient",
                column: "MedicationIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DosageOfIngredient_MedicationMedId",
                table: "DosageOfIngredient",
                column: "MedicationMedId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyIllnessHistories_MedicalRecordId",
                table: "FamilyIllnessHistories",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_AddressId",
                table: "Hospital",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEquipment_EquipmentTypeId",
                table: "HospitalEquipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEquipment_RoomId",
                table: "HospitalEquipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_ListOfResultsId",
                table: "LabResults",
                column: "ListOfResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestTypes_LabTestingId",
                table: "LabTestTypes",
                column: "LabTestingId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfResults_MedicalRecordId",
                table: "ListOfResults",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId1",
                table: "MedicalRecords",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicationMedId",
                table: "Medication",
                column: "MedicationMedId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategory_MedicationMedId",
                table: "MedicationCategory",
                column: "MedicationMedId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategory_SpecializationId",
                table: "MedicationCategory",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_DepartmentId",
                table: "RegisteredUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_ExaminationRoomId",
                table: "RegisteredUsers",
                column: "ExaminationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_OperationRoomId",
                table: "RegisteredUsers",
                column: "OperationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_ChosenDoctorId",
                table: "RegisteredUsers",
                column: "ChosenDoctorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Room_DepartmentId",
                table: "Room",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffect_MedicationMedId",
                table: "SideEffect",
                column: "MedicationMedId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffect_SideEffectsId",
                table: "SideEffect",
                column: "SideEffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_DoctorId",
                table: "Specialization",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_DiagnosisId",
                table: "Symptoms",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_MedicalRecordId",
                table: "Therapies",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_MedicationId",
                table: "Therapies",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_MedicalRecordId",
                table: "Vaccines",
                column: "MedicalRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "DosageOfIngredient");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HospitalEquipment");

            migrationBuilder.DropTable(
                name: "LabResults");

            migrationBuilder.DropTable(
                name: "LabTestTypes");

            migrationBuilder.DropTable(
                name: "MedicationCategory");

            migrationBuilder.DropTable(
                name: "SideEffect");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "ListOfResults");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "FamilyIllnessHistories");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
