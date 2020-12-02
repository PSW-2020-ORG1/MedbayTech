using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class first_migration : Migration
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
                    Company = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
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
                name: "MedicationUsageReports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(type: "date", nullable: true),
                    Until = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationUsageReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    APIKey = table.Column<string>(nullable: true),
                    APIEndpoint = table.Column<string>(nullable: true),
                    RecieveNotificationFrom = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    PharmacyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyNotifications", x => x.Id);
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
                name: "Shift",
                columns: table => new
                {
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
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
                    RoomLabel = table.Column<string>(nullable: true),
                    RoomUse = table.Column<string>(nullable: true),
                    BedsCapacity = table.Column<int>(nullable: false),
                    BedsFree = table.Column<int>(nullable: false),
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
                name: "HospitalEquipments",
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
                    table.PrimaryKey("PK_HospitalEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalEquipments_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalEquipments_Rooms_RoomId",
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
                    Confirmed = table.Column<bool>(nullable: true),
                    Blocked = table.Column<bool>(nullable: true),
                    Token = table.Column<string>(nullable: true),
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
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AdditionalNotes = table.Column<string>(nullable: true),
                    AverageGrade = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_RegisteredUsers_PatientId",
                        column: x => x.PatientId,
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
                name: "Occupation",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: true),
                    BedId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Occupation_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occupation_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
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
                    SpecializationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCategories_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
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
                    ExaminationSurgeryId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Med = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Dosage = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    MedicationCategoryId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_MedicationCategories_MedicationCategoryId",
                        column: x => x.MedicationCategoryId,
                        principalTable: "MedicationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medications_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
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
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Allergen = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DosageOfIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    MedicationIngredientId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageOfIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DosageOfIngredient_MedicationIngredients_MedicationIngredien~",
                        column: x => x.MedicationIngredientId,
                        principalTable: "MedicationIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationUsages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usage = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    MedicationId = table.Column<int>(nullable: false),
                    MedicationUsageReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationUsages_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationUsages_MedicationUsageReports_MedicationUsageRepor~",
                        column: x => x.MedicationUsageReportId,
                        principalTable: "MedicationUsageReports",
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
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
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
                name: "SideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Frequency = table.Column<int>(nullable: false),
                    SideEffectsId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideEffects_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[,]
                {
                    { 23, "Tweezers" },
                    { 21, "Pean" },
                    { 22, "Scissors" },
                    { 40, "Dialysis machine" },
                    { 24, "Surgical mask" },
                    { 25, "Surgical gloves" },
                    { 26, "Bandage" },
                    { 27, "Gauze" },
                    { 28, "Cotton pad" },
                    { 29, "Adhesive tape" },
                    { 30, "Alcohol" },
                    { 31, "Iodine" },
                    { 32, "Hydrogen peroxide" },
                    { 33, "Bed" },
                    { 34, "Table" },
                    { 35, "Chair" },
                    { 36, "Computer" },
                    { 37, "Examining table" },
                    { 20, "Scalpel" },
                    { 38, "Weelchair" },
                    { 19, "Needle" },
                    { 17, "Stethoscope" },
                    { 1, "Mamogram" },
                    { 2, "X-ray" },
                    { 3, "CT" },
                    { 4, "MRI" },
                    { 5, "Ultra sound" },
                    { 6, "EKG" },
                    { 7, "Holter" },
                    { 18, "Suringe" },
                    { 8, "Heart rate monitor" },
                    { 10, "Blood shugar monitor" },
                    { 11, "Defibrilator" },
                    { 12, "Oxygen" },
                    { 13, "Respirator" },
                    { 14, "Gastroscope" },
                    { 15, "Colonoscope" },
                    { 16, "Blood test machine" },
                    { 9, "Blood preasure monitor" },
                    { 39, "Thermometer" }
                });

            migrationBuilder.InsertData(
                table: "InsurancePolicies",
                columns: new[] { "Id", "Company", "EndTime", "StartTime" },
                values: new object[] { "policy1", "Dunav osiguranje d.o.o", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MedicationIngredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ibuprofen" },
                    { 2, "Paracetamol" }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "APIEndpoint", "APIKey", "RecieveNotificationFrom" },
                values: new object[,]
                {
                    { "Jankovic", "jankovic.rs", "ID1APIKEYAAAA", true },
                    { "Liman", "liman.li", "ID2APIKEYAAAA", true }
                });

            migrationBuilder.InsertData(
                table: "PharmacyNotifications",
                columns: new[] { "Id", "Approved", "Content", "PharmacyId" },
                values: new object[,]
                {
                    { 1, true, "Lexapro on sale! Get 15% off!", "Jankovic" },
                    { 2, true, "Aspirin on sale! Get 11% off!", "Liman" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "DoctorId", "SpecializationName" },
                values: new object[,]
                {
                    { 1, null, "Interna medicina" },
                    { 2, null, "Hirurgija" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Serbia" });

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
                    { 1, 100.0, null, 1 },
                    { 2, 120.0, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "MedicationCategories",
                columns: new[] { "Id", "CategoryName", "SpecializationId" },
                values: new object[,]
                {
                    { 1, "Drug", 1 },
                    { 2, "Kategorija1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "CityId", "Floor", "Number", "Street" },
                values: new object[,]
                {
                    { 1, 0, 21000, 0, 4, "Radnicka" },
                    { 2, 0, 11000, 0, 5, "Gospodara Vucica" },
                    { 3, 0, 11000, 0, 28, "Stefana Nemanje" },
                    { 4, 0, 11000, 0, 27, "Stefana Nemanje" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "AddressId", "Description", "Name" },
                values: new object[,]
                {
                    { 3, 1, "blablal", "Medbay" },
                    { 1, 3, "Hospital 1", "Hospital 1" },
                    { 2, 4, "Hospital 2", "Hospital 2" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username" },
                values: new object[] { "2406978890045", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RegisteredUser", 2, "marko@gmail.com", 0, "policy1", "Marko", null, "marko1978", "065/123-4554", 11000, "vodoinstalater", ".", "Markovic", "markic" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Floor", "HospitalId", "Name" },
                values: new object[,]
                {
                    { 13, 1, 3, "Infektivno" },
                    { 10, 1, 2, "Hematology" },
                    { 9, 1, 2, "Gastroenterology" },
                    { 8, 0, 2, "Dialysis" },
                    { 7, 0, 2, "General H2" },
                    { 6, 2, 1, "Intensive Care" },
                    { 5, 2, 1, "Neurology" },
                    { 11, 2, 2, "Rheumatology" },
                    { 4, 1, 1, "Radiology" },
                    { 2, 0, 1, "Cardiology" },
                    { 1, 0, 1, "General H1" },
                    { 3, 1, 1, "Oncology" },
                    { 12, 2, 2, "Infectous Diseases" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "AdditionalNotes", "AllowedForPublishing", "Anonymous", "Approved", "Date", "Grade", "RegisteredUserId" },
                values: new object[,]
                {
                    { 4, "Odlicno!", false, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 3, "Predivno, ali i ruzno! Sramite se! Cestitke... <3", false, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 2, "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!", true, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" },
                    { 1, "Sve je super!", true, false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2406978890045" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCapacity", "BedsFree", "DepartmentId", "RoomLabel", "RoomNumber", "RoomType", "RoomUse" },
                values: new object[,]
                {
                    { 1, 10, 3, 1, "null", 1, 1, "null" },
                    { 2110, 10, 3, 9, "1F-GE10", 10, 3, "Auxiliary room" },
                    { 2109, 10, 3, 9, "1F-GE9", 9, 0, "Patient room" },
                    { 2108, 10, 3, 9, "1F-GE8", 8, 1, "Examination room" },
                    { 2107, 10, 3, 9, "1F-GE7", 7, 4, "Storage room" },
                    { 2106, 10, 3, 9, "1F-GE6", 6, 4, "Storage room" },
                    { 2105, 10, 3, 9, "1F-GE5", 5, 1, "Examination room" },
                    { 2104, 10, 3, 9, "1F-GE4", 4, 1, "Examination room" },
                    { 2103, 10, 3, 9, "1F-GE3", 3, 4, "Storage room" },
                    { 2102, 10, 3, 9, "1F-GE2", 2, 4, "Storage room" },
                    { 2101, 10, 3, 9, "1F-GE1", 1, 1, "Examination room" },
                    { 2016, 10, 3, 8, "0F-DY8", 16, 3, "Elevator" },
                    { 2015, 10, 3, 8, "0F-DY7", 15, 3, "Elevator" },
                    { 2014, 10, 3, 8, "0F-DY6", 14, 0, "Patient room" },
                    { 2013, 10, 3, 8, "0F-DY5", 13, 2, "Operation room" },
                    { 2012, 10, 3, 8, "0F-DY4", 12, 0, "Patient room" },
                    { 2011, 10, 3, 8, "0F-DY3", 11, 0, "Patient room" },
                    { 2010, 10, 3, 8, "0F-DY2", 10, 2, "Operation room" },
                    { 2009, 10, 3, 8, "0F-DY1", 9, 0, "Patient room" },
                    { 2008, 10, 3, 7, "0F-EM8", 8, 1, "Examination room" },
                    { 2007, 10, 3, 7, "0F-EM7", 7, 1, "Examination room" },
                    { 2006, 10, 3, 7, "0F-EM6", 6, 3, "Auxiliary room" },
                    { 2005, 10, 3, 7, "0F-EM5", 5, 1, "Examination room" },
                    { 2004, 10, 3, 7, "0F-EM4", 4, 1, "Examination room" },
                    { 2003, 10, 3, 7, "0F-EM3", 3, 3, "Auxiliary room" },
                    { 2002, 10, 3, 7, "0F-EM2", 2, 1, "Examination room" },
                    { 2001, 10, 3, 7, "0F-EM1", 1, 1, "Examination room" },
                    { 1222, 10, 3, 6, "2F-IC7", 22, 3, "Elevator" },
                    { 2111, 10, 3, 9, "1F-GE11", 11, 0, "Patient room" },
                    { 2112, 10, 3, 9, "1F-GE12", 12, 0, "Patient room" },
                    { 2113, 10, 3, 9, "1F-GE13", 13, 3, "Auxiliary room" },
                    { 2114, 10, 3, 9, "1F-GE14", 14, 0, "Patient room" },
                    { 2220, 10, 3, 12, "2F-ID6", 20, 2, "Operation room" },
                    { 2219, 10, 3, 12, "2F-ID5", 19, 0, "Patient room" },
                    { 2218, 10, 3, 12, "2F-ID4", 18, 0, "Patient room" },
                    { 2217, 10, 3, 12, "2F-ID3", 17, 0, "Patient room" },
                    { 2216, 10, 3, 12, "2F-ID2", 16, 0, "Patient room" },
                    { 2215, 10, 3, 12, "2F-ID1", 15, 2, "Operation room" },
                    { 2214, 10, 3, 11, "2F-RM14", 14, 0, "Patient room" },
                    { 2213, 10, 3, 11, "2F-RM13", 13, 3, "Auxiliary room" },
                    { 2212, 10, 3, 11, "2F-RM12", 12, 3, "Auxiliary room" },
                    { 2211, 10, 3, 11, "2F-RM11", 11, 3, "Auxiliary room" },
                    { 2210, 10, 3, 11, "2F-RM10", 10, 1, "Examination room" },
                    { 2209, 10, 3, 11, "2F-RM9", 9, 3, "Auxiliary room" },
                    { 2208, 10, 3, 11, "2F-RM8", 8, 3, "Auxiliary room" },
                    { 1221, 10, 3, 6, "2F-IC7", 21, 3, "Elevator" },
                    { 2207, 10, 3, 11, "2F-RM7", 7, 3, "Auxiliary room" },
                    { 2205, 10, 3, 11, "2F-RM5", 5, 1, "Examination room" },
                    { 2204, 10, 3, 11, "2F-RM4", 4, 1, "Examination room" },
                    { 2203, 10, 3, 11, "2F-RM3", 3, 1, "Examination room" },
                    { 2202, 10, 3, 11, "2F-RM2", 2, 3, "Auxiliary room" },
                    { 2201, 10, 3, 11, "2F-RM1", 1, 0, "Patient room" },
                    { 2122, 10, 3, 10, "1F-HM8", 22, 3, "Elevator" },
                    { 2121, 10, 3, 10, "1F-HM7", 21, 3, "Elevator" },
                    { 2120, 10, 3, 10, "1F-HM6", 20, 0, "Patient room" },
                    { 2119, 10, 3, 10, "1F-HM5", 19, 0, "Patient room" },
                    { 2118, 10, 3, 10, "1F-HM4", 18, 2, "Operation room" },
                    { 2117, 10, 3, 10, "1F-HM3", 17, 2, "Operation room" },
                    { 2116, 10, 3, 10, "1F-HM2", 16, 0, "Patient room" },
                    { 2115, 10, 3, 10, "1F-HM1", 15, 0, "Patient room" },
                    { 2206, 10, 3, 11, "2F-RM6", 6, 3, "Auxiliary room" },
                    { 1220, 10, 3, 6, "2F-IC6", 20, 0, "Patient room" },
                    { 1219, 10, 3, 6, "2F-IC5", 19, 0, "Patient room" },
                    { 1218, 10, 3, 6, "2F-IC4", 18, 2, "Operation room" },
                    { 1106, 10, 3, 3, "1F-ON6", 6, 0, "Patient room" },
                    { 1105, 10, 3, 3, "1F-ON5", 5, 3, "Auxiliary room" },
                    { 1104, 10, 3, 3, "1F-ON4", 4, 0, "Patient room" },
                    { 1103, 10, 3, 3, "1F-ON3", 3, 1, "Examination room" },
                    { 1102, 10, 3, 3, "1F-ON2", 2, 3, "Auxiliary room" },
                    { 1101, 10, 3, 3, "1F-ON1", 1, 3, "Auxiliary room" },
                    { 1021, 10, 3, 2, "0F-CA10", 21, 3, "Elevator" },
                    { 1020, 10, 3, 2, "0F-CA9", 20, 3, "Elevator" },
                    { 1019, 10, 3, 2, "0F-CA8", 19, 1, "Examination room" },
                    { 1018, 10, 3, 2, "0F-CA7", 18, 0, "Patient room" },
                    { 1017, 10, 3, 2, "0F-CA6", 17, 0, "Patient room" },
                    { 1016, 10, 3, 2, "0F-CA5", 16, 0, "Patient room" },
                    { 1015, 10, 3, 2, "0F-CA4", 15, 0, "Patient room" },
                    { 1107, 10, 3, 3, "1F-ON7", 7, 0, "Patient room" },
                    { 1014, 10, 3, 2, "0F-CA3", 14, 0, "Patient room" },
                    { 1012, 10, 3, 2, "0F-CA1", 12, 1, "Examination room" },
                    { 2, 10, 3, 2, "null", 2, 1, "null" },
                    { 1011, 10, 3, 1, "0F-GN11", 11, 1, "Examination room" },
                    { 1010, 10, 3, 1, "0F-GN10", 10, 3, "Auxiliary room" },
                    { 1009, 10, 3, 1, "0F-GN9", 9, 1, "Examination room" },
                    { 1008, 10, 3, 1, "0F-GN8", 8, 1, "Examination room" },
                    { 1007, 10, 3, 1, "0F-GN7", 7, 3, "Auxiliary room" },
                    { 1006, 10, 3, 1, "0F-GN6", 6, 1, "Examination room" },
                    { 1005, 10, 3, 1, "0F-GN5", 5, 1, "Examination room" },
                    { 1004, 10, 3, 1, "0F-GN4", 4, 3, "Auxiliary room" },
                    { 1003, 10, 3, 1, "0F-GN3", 3, 1, "Examination room" },
                    { 1002, 10, 3, 1, "0F-GN2", 2, 3, "Auxiliary room" },
                    { 1001, 10, 3, 1, "0F-GN1", 1, 3, "Auxiliary room" },
                    { 1013, 10, 3, 2, "0F-CA2", 13, 0, "Patient room" },
                    { 2221, 10, 3, 12, "2F-ID7", 21, 3, "Elevator" },
                    { 1108, 10, 3, 3, "1F-ON8", 8, 3, "Auxiliary room" },
                    { 1110, 10, 3, 3, "1F-ON10", 10, 1, "Examination room" },
                    { 1217, 10, 3, 6, "2F-IC3", 17, 2, "Operation room" },
                    { 1216, 10, 3, 6, "2F-IC2", 16, 0, "Patient room" },
                    { 1215, 10, 3, 6, "2F-IC1", 15, 0, "Patient room" },
                    { 1214, 10, 3, 5, "2F-NE14", 14, 4, "Storage room" },
                    { 1213, 10, 3, 5, "2F-NE13", 13, 4, "Storage room" },
                    { 1212, 10, 3, 5, "2F-NE12", 12, 3, "Auxiliary room" },
                    { 1211, 10, 3, 5, "2F-NE11", 11, 3, "Auxiliary room" },
                    { 1210, 10, 3, 5, "2F-NE10", 10, 3, "Auxiliary room" },
                    { 1209, 10, 3, 5, "2F-NE9", 9, 3, "Auxiliary room" },
                    { 1208, 10, 3, 5, "2F-NE8", 8, 3, "Auxiliary room" },
                    { 1207, 10, 3, 5, "2F-NE7", 7, 3, "Auxiliary room" },
                    { 1206, 10, 3, 5, "2F-NE6", 6, 3, "Auxiliary room" },
                    { 1205, 10, 3, 5, "2F-NE5", 5, 1, "Examination room" },
                    { 1109, 10, 3, 3, "1F-ON9", 9, 0, "Patient room" },
                    { 1204, 10, 3, 5, "2F-NE4", 4, 1, "Examination room" },
                    { 1202, 10, 3, 5, "2F-NE2", 2, 1, "Examination room" },
                    { 1201, 10, 3, 5, "2F-NE1", 1, 3, "Auxiliary room" },
                    { 1121, 10, 3, 4, "1F-RD8", 21, 3, "Elevator" },
                    { 1120, 10, 3, 4, "1F-RD7", 20, 3, "Elevator" },
                    { 1119, 10, 3, 4, "1F-RD6", 19, 2, "Operation room" },
                    { 1118, 10, 3, 4, "1F-RD5", 18, 0, "Patient room" },
                    { 1117, 10, 3, 4, "1F-RD4", 17, 0, "Patient room" },
                    { 1116, 10, 3, 4, "1F-RD3", 16, 1, "Examination room" },
                    { 1115, 10, 3, 4, "1F-RD2", 15, 1, "Examination room" },
                    { 1114, 10, 3, 4, "1F-RD1", 14, 2, "Operation room" },
                    { 1113, 10, 3, 4, "1F-ON13", 13, 1, "Examination room" },
                    { 1112, 10, 3, 3, "1F-ON12", 12, 4, "Storage room" },
                    { 1111, 10, 3, 3, "1F-ON11", 11, 4, "Storage room" },
                    { 1203, 10, 3, 5, "2F-NE3", 3, 1, "Examination room" },
                    { 2222, 10, 3, 12, "2F-ID8", 22, 3, "Elevator" }
                });

            migrationBuilder.InsertData(
                table: "HospitalEquipments",
                columns: new[] { "Id", "EquipmentTypeId", "QuantityInRoom", "QuantityInStorage", "RoomId" },
                values: new object[,]
                {
                    { 1, 9, 1, 8, 1003 },
                    { 63, 17, 1, 5, 2005 },
                    { 64, 18, 20, 100, 2005 },
                    { 65, 19, 20, 100, 2005 },
                    { 66, 22, 2, 9, 2005 },
                    { 67, 23, 2, 11, 2005 },
                    { 68, 24, 20, 100, 2005 },
                    { 117, 35, 4, 20, 2217 },
                    { 70, 26, 70, 250, 2005 },
                    { 71, 27, 90, 300, 2005 },
                    { 72, 28, 100, 500, 2005 },
                    { 73, 29, 3, 6, 2005 },
                    { 74, 30, 1, 12, 2005 },
                    { 75, 31, 1, 13, 2005 },
                    { 76, 32, 1, 14, 2005 },
                    { 77, 34, 1, 10, 2005 },
                    { 62, 10, 1, 8, 2005 },
                    { 78, 35, 3, 20, 2005 },
                    { 61, 9, 1, 8, 2005 },
                    { 59, 31, 1, 13, 1217 },
                    { 44, 12, 1, 2, 1217 },
                    { 45, 13, 1, 2, 1217 },
                    { 46, 18, 20, 100, 1217 },
                    { 47, 19, 20, 100, 1217 },
                    { 48, 20, 3, 30, 1217 },
                    { 49, 21, 3, 30, 1217 },
                    { 50, 22, 2, 9, 1217 },
                    { 51, 23, 2, 11, 1217 },
                    { 52, 24, 20, 100, 1217 },
                    { 53, 25, 50, 200, 1217 },
                    { 54, 26, 70, 250, 1217 },
                    { 55, 27, 90, 300, 1217 },
                    { 56, 28, 100, 500, 1217 },
                    { 57, 29, 3, 6, 1217 },
                    { 58, 30, 1, 12, 1217 },
                    { 60, 32, 1, 14, 1217 },
                    { 79, 36, 1, 5, 2005 },
                    { 80, 37, 1, 5, 2005 },
                    { 81, 8, 4, 8, 2009 },
                    { 102, 17, 1, 5, 2210 },
                    { 103, 24, 20, 100, 2210 },
                    { 104, 25, 50, 200, 2210 },
                    { 105, 34, 1, 10, 2210 },
                    { 106, 35, 3, 20, 2210 },
                    { 107, 36, 1, 5, 2210 },
                    { 108, 37, 1, 5, 2210 },
                    { 109, 8, 4, 8, 2217 },
                    { 110, 9, 4, 8, 2217 },
                    { 111, 10, 4, 8, 2217 },
                    { 112, 11, 1, 2, 2217 },
                    { 113, 12, 1, 2, 2217 },
                    { 114, 13, 1, 2, 2217 },
                    { 115, 33, 4, 15, 2217 },
                    { 116, 34, 2, 10, 2217 },
                    { 101, 36, 3, 5, 2209 },
                    { 100, 35, 3, 20, 2209 },
                    { 99, 34, 3, 10, 2209 },
                    { 98, 36, 3, 5, 2208 },
                    { 82, 9, 4, 8, 2009 },
                    { 83, 10, 4, 8, 2009 },
                    { 84, 11, 1, 2, 2009 },
                    { 85, 12, 1, 2, 2009 },
                    { 86, 33, 4, 15, 2009 },
                    { 87, 34, 2, 10, 2009 },
                    { 88, 35, 4, 20, 2009 },
                    { 43, 11, 1, 2, 1217 },
                    { 89, 39, 4, 40, 2009 },
                    { 91, 40, 4, 8, 2013 },
                    { 92, 14, 1, 5, 2105 },
                    { 93, 15, 1, 6, 2108 },
                    { 94, 16, 2, 7, 2117 },
                    { 95, 16, 2, 7, 2118 },
                    { 96, 34, 3, 10, 2208 },
                    { 97, 35, 3, 20, 2208 },
                    { 90, 40, 4, 8, 2010 },
                    { 42, 8, 1, 8, 1217 },
                    { 69, 25, 50, 200, 2005 },
                    { 118, 39, 4, 40, 2217 },
                    { 38, 4, 1, 0, 1119 },
                    { 37, 3, 1, 0, 1116 },
                    { 36, 1, 1, 1, 1115 },
                    { 20, 37, 1, 5, 1003 },
                    { 35, 2, 1, 0, 1114 },
                    { 27, 12, 1, 2, 1014 },
                    { 21, 6, 1, 2, 1012 },
                    { 22, 7, 4, 16, 1012 },
                    { 26, 11, 1, 2, 1014 },
                    { 25, 10, 4, 8, 1014 },
                    { 24, 9, 4, 8, 1014 },
                    { 33, 3, 1, 0, 1110 },
                    { 32, 6, 1, 2, 1019 },
                    { 31, 5, 1, 4, 1019 },
                    { 30, 35, 4, 20, 1014 },
                    { 29, 34, 2, 10, 1014 },
                    { 28, 33, 4, 15, 1014 },
                    { 39, 34, 3, 10, 1210 },
                    { 40, 35, 3, 20, 1210 },
                    { 34, 1, 1, 1, 1113 },
                    { 19, 36, 1, 5, 1003 },
                    { 2, 10, 1, 8, 1003 },
                    { 3, 17, 1, 5, 1003 },
                    { 4, 18, 20, 100, 1003 },
                    { 5, 19, 20, 100, 1003 },
                    { 6, 22, 2, 9, 1003 },
                    { 7, 23, 2, 11, 1003 },
                    { 8, 24, 20, 100, 1003 },
                    { 9, 25, 50, 200, 1003 },
                    { 41, 36, 3, 5, 1210 },
                    { 23, 8, 4, 8, 1014 },
                    { 18, 35, 3, 20, 1003 },
                    { 17, 34, 1, 10, 1003 },
                    { 16, 32, 1, 14, 1003 },
                    { 15, 31, 1, 13, 1003 },
                    { 14, 30, 1, 12, 1003 },
                    { 10, 26, 70, 250, 1003 },
                    { 13, 29, 3, 6, 1003 },
                    { 12, 28, 100, 500, 1003 },
                    { 11, 27, 90, 300, 1003 }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Company", "Dosage", "Med", "MedicationCategoryId", "MedicationId", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 68, "Famar", "25mg", "Claritin", 1, null, 15, 2106, 1 },
                    { 81, "Hemofarm", "250mg", "Amoksicilin", 1, null, 15, 2107, 1 },
                    { 80, "Hemofarm", "30mg", "Demerol", 1, null, 15, 2107, 1 },
                    { 79, "Galenika", "20mg", "Klonopin", 1, null, 15, 2107, 1 },
                    { 78, "Hemofarm", "100mg", "Hemomicin", 1, null, 15, 2107, 1 },
                    { 77, "Famar", "80mg", "Adderall", 1, null, 15, 2107, 1 },
                    { 76, "Hemofarm", "50mg", "Vicodin", 1, null, 15, 2107, 1 },
                    { 75, "Goodwill", "400mg", "Andol", 1, null, 15, 2107, 1 },
                    { 73, "Hemofarm", "200mg", "Panadon", 1, null, 15, 2107, 1 },
                    { 72, "Goodwill", "40mg", "Xanax", 1, null, 15, 2107, 1 },
                    { 71, "Famar", "200mg", "Brufen", 1, null, 10, 2106, 0 },
                    { 70, "Galenika", "75mg", "Lasix", 1, null, 15, 2106, 1 },
                    { 69, "Hemofarm", "500mg", "Flobian", 1, null, 15, 2106, 1 },
                    { 67, "Galenika", "100mg", "Letrox", 1, null, 15, 2106, 1 },
                    { 74, "Famar", "60mg", "Diazepam", 1, null, 15, 2107, 1 },
                    { 93, "Galenika", "100mg", "Plavix", 1, null, 15, 2206, 1 },
                    { 83, "Goodwill", "200mg", "Zoloft", 1, null, 15, 2202, 1 },
                    { 101, "Bosnalijek", "100mg", "Penicillin", 1, null, 15, 2206, 1 },
                    { 100, "Famar", "100mg", "Eritromicin", 1, null, 15, 2206, 1 },
                    { 99, "Bosnalijek", "40mg", "Ritalin", 1, null, 15, 2206, 1 },
                    { 98, "Goodwill", "30mg", "Percocet", 1, null, 15, 2206, 1 },
                    { 97, "Famar", "25mg", "OxyCotin", 1, null, 15, 2206, 1 },
                    { 96, "Hemofarm", "60mg", "Demerol", 1, null, 15, 2206, 1 },
                    { 95, "Galenika", "100mg", "Ranisan", 1, null, 15, 2206, 1 },
                    { 94, "Famar", "50mg", "Ambien", 1, null, 15, 2206, 1 },
                    { 82, "Galenika", "100mg", "Cefaleksin", 1, null, 15, 2202, 1 },
                    { 65, "Hemofarm", "50mg", "Bensedin", 1, null, 15, 2106, 1 },
                    { 91, "Famar", "125mg", "Reglan", 1, null, 15, 2202, 1 },
                    { 90, "Goodwill", "150mg", "Andol", 1, null, 15, 2202, 1 },
                    { 89, "Famar", "800mg", "Diazepam", 1, null, 15, 2202, 1 },
                    { 88, "Hemofarm", "250mg", "Panadon", 1, null, 15, 2202, 1 },
                    { 87, "Goodwill", "60mg", "Xanax", 1, null, 15, 2202, 1 },
                    { 86, "Famar", "100mg", "Brufen", 1, null, 10, 2202, 0 },
                    { 85, "Hemofarm", "10mg", "Bensedin", 1, null, 15, 2202, 1 },
                    { 84, "Famar", "80mg", "Lexilium", 1, null, 15, 2202, 1 },
                    { 92, "Bosnalijek", "200mg", "Caffetin", 1, null, 15, 2206, 1 },
                    { 64, "Famar", "40mg", "Lexilium", 1, null, 15, 2106, 1 },
                    { 56, "Famar", "40mg", "OxyCotin", 1, null, 15, 2103, 1 },
                    { 62, "Galenika", "200mg", "Cefaleksin", 1, null, 15, 2106, 1 },
                    { 12, "Famar", "40mg", "Adderall", 1, null, 15, 1112, 1 },
                    { 13, "Hemofarm", "100mg", "Hemomicin", 1, null, 15, 1112, 1 },
                    { 14, "Galenika", "20mg", "Klonopin", 1, null, 15, 1112, 1 },
                    { 15, "Hemofarm", "30mg", "Demerol", 1, null, 15, 1112, 1 },
                    { 16, "Famar", "40mg", "OxyCotin", 1, null, 15, 1112, 1 },
                    { 17, "Goodwill", "60mg", "Percocet", 1, null, 15, 1112, 1 },
                    { 18, "Bosnalijek", "80mg", "Ritalin", 1, null, 15, 1112, 1 },
                    { 19, "Famar", "100mg", "Eritromicin", 1, null, 15, 1112, 1 },
                    { 20, "Bosnalijek", "200mg", "Penicillin", 1, null, 15, 1112, 1 },
                    { 21, "Hemofarm", "150mg", "Amoksicilin", 1, null, 15, 1213, 1 },
                    { 22, "Galenika", "200mg", "Cefaleksin", 1, null, 15, 1213, 1 },
                    { 23, "Goodwill", "500mg", "Zoloft", 1, null, 15, 1213, 1 },
                    { 24, "Famar", "40mg", "Lexilium", 1, null, 15, 1213, 1 },
                    { 25, "Hemofarm", "50mg", "Bensedin", 1, null, 15, 1213, 1 },
                    { 26, "Hemofarm", "50mg", "Benedril", 1, null, 15, 1213, 1 },
                    { 27, "Galenika", "100mg", "Letrox", 1, null, 15, 1213, 1 },
                    { 28, "Famar", "25mg", "Claritin", 1, null, 15, 1213, 1 },
                    { 29, "Hemofarm", "500mg", "Flobian", 1, null, 15, 1213, 1 },
                    { 30, "Galenika", "75mg", "Lasix", 1, null, 15, 1213, 1 },
                    { 31, "Famar", "200mg", "Brufen", 1, null, 10, 1214, 0 },
                    { 32, "Goodwill", "40mg", "Xanax", 1, null, 15, 1214, 1 },
                    { 33, "Hemofarm", "200mg", "Panadon", 1, null, 15, 1214, 1 },
                    { 34, "Famar", "60mg", "Diazepam", 1, null, 15, 1214, 1 },
                    { 40, "Hemofarm", "30mg", "Demerol", 1, null, 15, 1214, 1 },
                    { 39, "Galenika", "20mg", "Klonopin", 1, null, 15, 1214, 1 },
                    { 38, "Hemofarm", "100mg", "Hemomicin", 1, null, 15, 1214, 1 },
                    { 37, "Famar", "80mg", "Adderall", 1, null, 15, 1214, 1 },
                    { 11, "Hemofarm", "50mg", "Vicodin", 1, null, 15, 1112, 1 },
                    { 63, "Goodwill", "500mg", "Zoloft", 1, null, 15, 2106, 1 },
                    { 10, "Galenika", "200mg", "Ranisan", 1, null, 15, 1111, 1 },
                    { 8, "Galenika", "50mg", "Plavix", 1, null, 15, 1111, 1 },
                    { 61, "Hemofarm", "150mg", "Amoksicilin", 1, null, 15, 2106, 1 },
                    { 60, "Bosnalijek", "200mg", "Penicillin", 1, null, 15, 2103, 1 },
                    { 59, "Famar", "100mg", "Eritromicin", 1, null, 15, 2103, 1 },
                    { 58, "Bosnalijek", "80mg", "Ritalin", 1, null, 15, 2103, 1 },
                    { 57, "Goodwill", "60mg", "Percocet", 1, null, 15, 2103, 1 },
                    { 35, "Goodwill", "400mg", "Andol", 1, null, 15, 1214, 1 },
                    { 55, "Hemofarm", "30mg", "Demerol", 1, null, 15, 2103, 1 },
                    { 54, "Galenika", "20mg", "Klonopin", 1, null, 15, 2103, 1 },
                    { 53, "Hemofarm", "100mg", "Hemomicin", 1, null, 15, 2103, 1 },
                    { 52, "Famar", "40mg", "Adderall", 1, null, 15, 2103, 1 },
                    { 51, "Hemofarm", "50mg", "Vicodin", 1, null, 15, 2103, 1 },
                    { 50, "Galenika", "200mg", "Ranisan", 1, null, 15, 2102, 1 },
                    { 49, "Famar", "25mg", "Ambien", 1, null, 15, 2102, 1 },
                    { 48, "Galenika", "50mg", "Plavix", 1, null, 15, 2102, 1 },
                    { 47, "Bosnalijek", "400mg", "Caffetin", 1, null, 15, 2102, 1 },
                    { 46, "Famar", "100mg", "Reglan", 1, null, 15, 2102, 1 },
                    { 45, "Goodwill", "200mg", "Andol", 1, null, 15, 2102, 1 },
                    { 44, "Famar", "30mg", "Diazepam", 1, null, 15, 2102, 1 },
                    { 43, "Hemofarm", "500mg", "Panadon", 1, null, 15, 2102, 1 },
                    { 42, "Goodwill", "20mg", "Xanax", 1, null, 15, 2102, 1 },
                    { 41, "Famar", "400mg", "Brufen", 1, null, 10, 2102, 0 },
                    { 1, "Famar", "400mg", "Brufen", 1, null, 10, 1111, 0 },
                    { 2, "Goodwill", "20mg", "Xanax", 1, null, 15, 1111, 1 },
                    { 3, "Hemofarm", "500mg", "Panadon", 1, null, 15, 1111, 1 },
                    { 4, "Famar", "30mg", "Diazepam", 1, null, 15, 1111, 1 },
                    { 5, "Goodwill", "200mg", "Andol", 1, null, 15, 1111, 1 },
                    { 6, "Famar", "100mg", "Reglan", 1, null, 15, 1111, 1 },
                    { 7, "Bosnalijek", "400mg", "Caffetin", 1, null, 15, 1111, 1 },
                    { 9, "Famar", "25mg", "Ambien", 1, null, 15, 1111, 1 },
                    { 36, "Hemofarm", "50mg", "Vicodin", 1, null, 15, 1214, 1 }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username", "Biography", "CurrentlyWorking", "VacationLeave", "WorkersID", "DepartmentId", "ExaminationRoomId", "LicenseNumber", "OnCall", "OperationRoomId", "PatientReview" },
                values: new object[] { "2406978890047", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 2, "mika@gmail.com", 0, "policy1", "Milan", null, "mika1978", "065/123-4554", 11000, "vodoinstalater", ".", "Milanovic", "mika", null, false, false, 0, 1, 1003, "001", true, 1114, 4.5 });

            migrationBuilder.InsertData(
                table: "MedicationUsages",
                columns: new[] { "Id", "Date", "MedicationId", "MedicationUsageReportId", "Usage" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 4 },
                    { 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 50 },
                    { 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 10 },
                    { 4, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "CurrResidenceId", "DateOfBirth", "DateOfCreation", "Discriminator", "EducationLevel", "Email", "Gender", "InsurancePolicyId", "Name", "NotificationId", "Password", "Phone", "PlaceOfBirthId", "Profession", "ProfileImage", "Surname", "Username", "Blocked", "ChosenDoctorId", "Confirmed", "IsGuestAccount", "Token" },
                values: new object[] { "2406978890046", 1, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", 2, "pera@gmail.com", 0, "policy1", "Petar", null, "pera1978", "065/123-4554", 11000, "vodoinstalater", "http://localhost:8080/Resources/Images/1234567891989/among-us-5659730_1280.png", "Petrovic", "pera", false, "2406978890047", false, false, null });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "BloodType", "CurrHealthState", "PatientId" },
                values: new object[] { 1, 2, 2, "2406978890046" });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Allergen", "MedicalRecordId", "MedicationId" },
                values: new object[,]
                {
                    { 1, "Polen", 1, null },
                    { 2, "Prasina", 1, null }
                });

            migrationBuilder.InsertData(
                table: "ExaminationSurgeries",
                columns: new[] { "Id", "DoctorId", "MedicalRecordId", "StartTime", "Type" },
                values: new object[,]
                {
                    { 1, "2406978890047", 1, new DateTime(2020, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "2406978890047", 1, new DateTime(2020, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
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
                table: "Diagnoses",
                columns: new[] { "Id", "ExaminationSurgeryId", "FamilyIllnessHistoryId", "MedicalRecordId", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "Dijagnoza1" },
                    { 2, 1, null, 1, "Dijagnoza2" }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AdditionalNotes", "Date", "Discriminator", "ExaminationSurgeryId", "Type", "EndDate", "HourlyIntake", "MedicationId", "Reserved", "StartDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prescription", 1, 0, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, true, new DateTime(2020, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2020, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prescription", 1, 0, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, true, new DateTime(2020, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AdditionalNotes", "Date", "Discriminator", "ExaminationSurgeryId", "Type" },
                values: new object[,]
                {
                    { 3, ".", new DateTime(2020, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treatment", 1, 0 },
                    { 4, ".", new DateTime(2020, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treatment", 1, 0 }
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
                values: new object[] { 1, 2, null, 1 });

            migrationBuilder.InsertData(
                table: "SideEffects",
                columns: new[] { "Id", "Frequency", "MedicationId", "SideEffectsId" },
                values: new object[] { 2, 1, null, 1 });

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
                name: "IX_HospitalEquipments_EquipmentTypeId",
                table: "HospitalEquipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEquipments_RoomId",
                table: "HospitalEquipments",
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
                name: "IX_MedicationCategories_SpecializationId",
                table: "MedicationCategories",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicationCategoryId",
                table: "Medications",
                column: "MedicationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicationId",
                table: "Medications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_RoomId",
                table: "Medications",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUsages_MedicationId",
                table: "MedicationUsages",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUsages_MedicationUsageReportId",
                table: "MedicationUsages",
                column: "MedicationUsageReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RegisteredUserId",
                table: "Notifications",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupation_BedId",
                table: "Occupation",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupation_MedicalRecordId",
                table: "Occupation",
                column: "MedicalRecordId");

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
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PatientId",
                table: "Surveys",
                column: "PatientId");

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
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "DoctorReviews");

            migrationBuilder.DropTable(
                name: "DosageOfIngredient");

            migrationBuilder.DropTable(
                name: "EmergencyRequests");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HospitalEquipments");

            migrationBuilder.DropTable(
                name: "MedicationUsages");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyNotifications");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "SideEffects");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

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
                name: "MedicationUsageReports");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "PostContents");

            migrationBuilder.DropTable(
                name: "QuestionReplies");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "MedicationCategories");

            migrationBuilder.DropTable(
                name: "ExaminationSurgeries");

            migrationBuilder.DropTable(
                name: "FamilyIllnessHistories");

            migrationBuilder.DropTable(
                name: "Specializations");

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
