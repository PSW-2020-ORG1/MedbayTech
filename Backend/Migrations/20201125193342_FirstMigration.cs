using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class FirstMigration : Migration
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
                name: "InsurancePolicies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Med = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    MedicationCategoryId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    ContentTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContents", x => x.Id);
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
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    QuestionType = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DosageOfIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    MedicationIngredientId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageOfIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_MedicationIngredients_MedicationIngredien~",
                        column: x => x.MedicationIngredientId,
                        principalTable: "MedicationIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<long>(nullable: false)
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
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
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
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
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
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrentlyFree = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
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
                    RoomId = table.Column<int>(nullable: false),
                    EquipmentTypeId = table.Column<int>(nullable: false)
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
                        name: "FK_HospitalEquipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renovations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MoveEquipment = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renovations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
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
                    Gender = table.Column<int>(nullable: false),
                    PlaceOfBirthId = table.Column<int>(nullable: false),
                    CurrResidenceId = table.Column<int>(nullable: false),
                    InsurancePolicyId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    NotificationId = table.Column<int>(nullable: true),
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
                        name: "FK_RegisteredUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Rooms_ExaminationRoomId",
                        column: x => x.ExaminationRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredUsers_Rooms_OperationRoomId",
                        column: x => x.OperationRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    PostContentId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_PostContents_PostContentId",
                        column: x => x.PostContentId,
                        principalTable: "PostContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfReview = table.Column<DateTime>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_RegisteredUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    AllowedForPublishing = table.Column<bool>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
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
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_RegisteredUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    NotificationCategory = table.Column<int>(nullable: false),
                    RegisteredUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionReplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionReplies_RegisteredUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecializationName = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReasonForVacation = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_RegisteredUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValidationMeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SideNotes = table.Column<string>(nullable: true),
                    DateOfValidation = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Reviewed = table.Column<bool>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationMeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationMeds_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidationMeds_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDays_RegisteredUsers_EmployeeId",
                        column: x => x.EmployeeId,
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
                    MedicalRecordId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergens_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergens_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOfAppointment = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Urgent = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    WeeklyAppointmentReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationSurgeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationSurgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationSurgeries_RegisteredUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationSurgeries_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyIllnessHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelativeMember = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyIllnessHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyIllnessHistories_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HourConsumption = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapies_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapies_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    FrequentlyAsked = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    PostContentId = table.Column<int>(nullable: false),
                    QuestionReplyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_RegisteredUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_PostContents_PostContentId",
                        column: x => x.PostContentId,
                        principalTable: "PostContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionReplies_QuestionReplyId",
                        column: x => x.QuestionReplyId,
                        principalTable: "QuestionReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOfAppointment = table.Column<int>(nullable: false),
                    SideNotes = table.Column<string>(nullable: true),
                    SpecializationId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyRequests_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyRequests_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    SpecializationId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCategories_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationCategories_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false),
                    SurveyQuestions = table.Column<string>(nullable: true),
                    SurveyAnswers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ExaminationSurgeryId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    Reserved = table.Column<bool>(nullable: true),
                    HourlyIntake = table.Column<int>(nullable: true),
                    MedicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_ExaminationSurgeries_ExaminationSurgeryId",
                        column: x => x.ExaminationSurgeryId,
                        principalTable: "ExaminationSurgeries",
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
                    MedicalRecordId = table.Column<int>(nullable: false),
                    ExaminationSurgeryId = table.Column<int>(nullable: true),
                    FamilyIllnessHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_ExaminationSurgeries_ExaminationSurgeryId",
                        column: x => x.ExaminationSurgeryId,
                        principalTable: "ExaminationSurgeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DiagnosisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Frequency = table.Column<int>(nullable: false),
                    SideEffectsId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideEffects_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SideEffects_Symptoms_SideEffectsId",
                        column: x => x.SideEffectsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Krevet" });

            migrationBuilder.InsertData(
                table: "InsurancePolicies",
                columns: new[] { "Id", "Company" },
                values: new object[] { "policy1", "Dunav osiguranje d.o.o" });

            migrationBuilder.InsertData(
                table: "MedicationIngredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ibuprofen" },
                    { 2, "Paracetamol" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Med", "MedicationCategoryId", "MedicationId", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, "Famar", "Brufen", 1, null, 10, 0 },
                    { 2, "Goodwill", "Metafex", 1, null, 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Serbia" });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Question", "QuestionType", "Status" },
                values: new object[] { 1, "Rate work of Doctor", 0, true });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 21000, "Novi Sad", 1L },
                    { 11000, "Beograd", 1L }
                });

            migrationBuilder.InsertData(
                table: "DosageOfIngredient",
                columns: new[] { "Id", "Amount", "MedicationId", "MedicationIngredientId" },
                values: new object[,]
                {
                    { 1, 100.0, 1, 1 },
                    { 2, 120.0, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "CityId", "Floor", "Number", "Street" },
                values: new object[] { 1, 0, 21000, 0, 4, "Radnicka" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "CityId", "Floor", "Number", "Street" },
                values: new object[] { 2, 0, 11000, 0, 5, "Gospodara Vucica" });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "AddressId", "Description", "Name" },
                values: new object[] { 1, 1, "blablal", "Medbay" });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username" },
                values: new object[] { "2406978890045", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RegisteredUser", 2, "marko@gmail.com", 0, "policy1", "Marko", null, "marko1978", "065/123-4554", 11000, "vodoinstalater", ".", "Markovic", "markic" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Floor", "HospitalId", "Name" },
                values: new object[] { 1, 1, 1, "Infektivno" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "AdditionalNotes", "AllowedForPublishing", "Anonymous", "Approved", "Date", "Grade", "RegisteredUserId" },
                values: new object[,]
                {
                    { 1, "Sve je super!", true, false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 2, "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!", true, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 3, "Predivno, ali i ruzno! Sramite se! Cestitke... <3", false, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 4, "Odlicno!", false, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DepartmentId", "RoomNumber", "RoomType" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DepartmentId", "RoomNumber", "RoomType" },
                values: new object[] { 2, 1, 2, 0 });

            migrationBuilder.InsertData(
                table: "HospitalEquipment",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[] { 1, 1, 5, 15, 1 });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username", "Biography", "CurrentlyWorking", "VacationLeave", "WorkersID", "DepartmentId", "ExaminationRoomId", "LicenseNumber", "OnCall", "OperationRoomId", "PatientReview" },
                values: new object[] { "2406978890047", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 2, "mika@gmail.com", 0, "policy1", "Milan", null, "mika1978", "065/123-4554", 11000, "vodoinstalater", ".", "Milanovic", "mika", null, false, false, 0, 1, 1, "001", true, 2, 4.5 });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username", "ChosenDoctorId", "IsGuestAccount" },
                values: new object[] { "2406978890046", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", 2, "pera@gmail.com", 0, "policy1", "Petar", null, "pera1978", "065/123-4554", 11000, "vodoinstalater", ".", "Petrovic", "pera", "2406978890047", false });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "DoctorId", "SpecializationName" },
                values: new object[] { 1, "2406978890047", "Interna medicina" });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "DoctorId", "SpecializationName" },
                values: new object[] { 2, "2406978890047", "Hirurgija" });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "BloodType", "CurrHealthState", "PatientId" },
                values: new object[] { 1, 2, 2, "2406978890046" });

            migrationBuilder.InsertData(
                table: "MedicationCategories",
                columns: new[] { "Id", "CategoryName", "MedicationId", "SpecializationId" },
                values: new object[] { 1, "Kategorija1", 1, 1 });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Allergen", "MedicalRecordId", "MedicationId" },
                values: new object[,]
                {
                    { 1, "Polen", 1, 1 },
                    { 2, "Prasina", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Deleted", "DoctorId", "Finished", "MedicalRecordId", "RoomId", "ShortDescription", "TypeOfAppointment", "Urgent", "WeeklyAppointmentReportId" },
                values: new object[] { 1, false, "2406978890047", true, 1, 1, "standard appointment", 0, true, 1 });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "ExaminationSurgeryId", "FamilyIllnessHistoryId", "MedicalRecordId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, 1, "Dijagnoza1" },
                    { 2, null, null, 1, "Dijagnoza2" }
                });

            migrationBuilder.InsertData(
                table: "FamilyIllnessHistories",
                columns: new[] { "Id", "MedicalRecordId", "RelativeMember" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Therapies",
                columns: new[] { "Id", "HourConsumption", "MedicalRecordId", "MedicationId" },
                values: new object[,]
                {
                    { 1, 6, 1, 1 },
                    { 2, 10, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "Id", "MedicalRecordId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Grip" },
                    { 2, 1, "Male boginje" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "DiagnosisId", "Name" },
                values: new object[] { 1, 1, "Kasalj" });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "DiagnosisId", "Name" },
                values: new object[] { 2, 1, "Temperatura" });

            migrationBuilder.InsertData(
                table: "SideEffects",
                columns: new[] { "Id", "Frequency", "MedicationId", "SideEffectsId" },
                values: new object[] { 1, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "SideEffects",
                columns: new[] { "Id", "Frequency", "MedicationId", "SideEffectsId" },
                values: new object[] { 2, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_MedicalRecordId",
                table: "Allergens",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_MedicationId",
                table: "Allergens",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicalRecordId",
                table: "Appointments",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DoctorId",
                table: "Articles",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PostContentId",
                table: "Articles",
                column: "PostContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HospitalId",
                table: "Departments",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_ExaminationSurgeryId",
                table: "Diagnoses",
                column: "ExaminationSurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_FamilyIllnessHistoryId",
                table: "Diagnoses",
                column: "FamilyIllnessHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_MedicalRecordId",
                table: "Diagnoses",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_DoctorId",
                table: "DoctorReviews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_PatientId",
                table: "DoctorReviews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DosageOfIngredient_MedicationId",
                table: "DosageOfIngredient",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DosageOfIngredient_MedicationIngredientId",
                table: "DosageOfIngredient",
                column: "MedicationIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRequests_MedicalRecordId",
                table: "EmergencyRequests",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRequests_SpecializationId",
                table: "EmergencyRequests",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSurgeries_DoctorId",
                table: "ExaminationSurgeries",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSurgeries_MedicalRecordId",
                table: "ExaminationSurgeries",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyIllnessHistories_MedicalRecordId",
                table: "FamilyIllnessHistories",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RegisteredUserId",
                table: "Feedbacks",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEquipment_EquipmentTypeId",
                table: "HospitalEquipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEquipment_RoomId",
                table: "HospitalEquipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AddressId",
                table: "Hospitals",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategories_MedicationId",
                table: "MedicationCategories",
                column: "MedicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategories_SpecializationId",
                table: "MedicationCategories",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicationId",
                table: "Medications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RegisteredUserId",
                table: "Notifications",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReplies_AuthorId",
                table: "QuestionReplies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AuthorId",
                table: "Questions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PostContentId",
                table: "Questions",
                column: "PostContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionReplyId",
                table: "Questions",
                column: "QuestionReplyId");

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
                name: "IX_RegisteredUsers_NotificationId",
                table: "RegisteredUsers",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_PlaceOfBirthId",
                table: "RegisteredUsers",
                column: "PlaceOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovations_RoomId",
                table: "Renovations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DepartmentId",
                table: "Rooms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffects_MedicationId",
                table: "SideEffects",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffects_SideEffectsId",
                table: "SideEffects",
                column: "SideEffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_DoctorId",
                table: "Specializations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Surveys",
                column: "AppointmentId");

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
                name: "IX_Treatments_DepartmentId",
                table: "Treatments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MedicationId",
                table: "Treatments",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_ExaminationSurgeryId",
                table: "Treatments",
                column: "ExaminationSurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_EmployeeId",
                table: "VacationRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_MedicalRecordId",
                table: "Vaccines",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationMeds_DoctorId",
                table: "ValidationMeds",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationMeds_MedicationId",
                table: "ValidationMeds",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDays_EmployeeId",
                table: "WorkDays",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUsers_Notifications_NotificationId",
                table: "RegisteredUsers",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUsers_Cities_PlaceOfBirthId",
                table: "RegisteredUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_RegisteredUsers_RegisteredUserId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "DoctorReviews");

            migrationBuilder.DropTable(
                name: "DosageOfIngredient");

            migrationBuilder.DropTable(
                name: "EmergencyRequests");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HospitalEquipment");

            migrationBuilder.DropTable(
                name: "MedicationCategories");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.DropTable(
                name: "SideEffects");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "ValidationMeds");

            migrationBuilder.DropTable(
                name: "WorkDays");

            migrationBuilder.DropTable(
                name: "MedicationIngredients");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "PostContents");

            migrationBuilder.DropTable(
                name: "QuestionReplies");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "ExaminationSurgeries");

            migrationBuilder.DropTable(
                name: "FamilyIllnessHistories");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
