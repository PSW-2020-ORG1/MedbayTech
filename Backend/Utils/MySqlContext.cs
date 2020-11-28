using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Backend.Examinations.Model;
using Backend.Records.Model;
using Backend.Medications;
using Model.Schedule;
using Model.Users;
using MySql.Data.MySqlClient;
using Backend.Utils;
using Model.Rooms;
using System.Linq;
using Backend.Medications.Model;
using Backend.Records.Model.Enums;
using ZdravoKorporacija.Model.Users;

namespace Model
{
    public class MySqlContext : DbContext
    {

        private int mySqlConnectionPort = 3306;
        private string mySqlConnectionUid = "root";
        private string mySqlConnectionPassword = "root";
        private string mySqlDatabaseName = "newdb";
        private string mySqlHostAddress = "localhost";


        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionReply> QuestionReplies { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DoctorReview> DoctorReviews { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Renovation> Renovations { get; set; }
        public DbSet<HospitalEquipment> HospitalEquipment { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Symptoms> Symptoms { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<FamilyIllnessHistory> FamilyIllnessHistories { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ValidationMed> ValidationMeds { get; set; }
        public DbSet<SideEffect> SideEffects { get; set; }
        public DbSet<MedicationIngredient> MedicationIngredients { get; set; }
        public DbSet<MedicationCategory> MedicationCategories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<HospitalTreatment> HospitalTreatments { get; set; }
        public DbSet<ExaminationSurgery> ExaminationSurgeries { get; set; }
        public DbSet<EmergencyRequest> EmergencyRequests { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
        public MySqlContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*This is not good solution, must be refactored*/
            //optionsBuilder.UseMySql(@"server=" + mySqlHostAddress + ";port=" + mySqlConnectionPort + ";database=" + mySqlDatabaseName + ";uid=" + mySqlConnectionUid + ";password=" + mySqlConnectionPassword);
            //optionsBuilder.UseLazyLoadingProxies(true);

            // NOTE(Jovan): When using Backend DB inside project, create appsettings.json inside
            // that project
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=newdb;user=root;password=root").UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(

                 new City { Id = 21000, Name = "Novi Sad", StateId = 1 },
                 new City { Id = 11000, Name = "Beograd", StateId = 1 }
                 );

            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Name = "Serbia" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "Radnicka", Number = 4, CityId = 21000 },
                new Address { Id = 2, Street = "Gospodara Vucica", Number = 5, CityId = 11000 },
                new Address { Id = 3, Street = "Stefana Nemanje", Number = 28, CityId = 11000 },
                new Address { Id = 4, Street = "Stefana Nemanje", Number = 27, CityId = 11000 }
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy { Company = "Dunav osiguranje d.o.o", Id = "policy1", Period = new Period(new DateTime(2020, 11, 1), new DateTime(2020, 11, 1)) }
            );

            modelBuilder.Entity<RegisteredUser>().HasData(
                new RegisteredUser
                {
                    Id = "2406978890045",
                    CurrResidenceId = 1,
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "marko@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicyId = "policy1",
                    Name = "Marko",
                    Surname = "Markovic",
                    Username = "markic",
                    Password = "marko1978",
                    Phone = "065/123-4554",
                    PlaceOfBirthId = 11000,
                    Profession = "vodoinstalater",
                    ProfileImage = "."

                }
                );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, AdditionalNotes = "Sve je super!", Approved = true, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = true },
                new Feedback { Id = 2, AdditionalNotes = "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = true },
                new Feedback { Id = 3, AdditionalNotes = "Predivno, ali i ruzno! Sramite se! Cestitke... <3", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = false },
                new Feedback { Id = 4, AdditionalNotes = "Odlicno!", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = false }
            );

            modelBuilder.Entity<Vaccines>().HasData(
                new Vaccines { Id = 1, Name = "Grip", MedicalRecordId = 1 },
                new Vaccines { Id = 2, Name = "Male boginje", MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { Id = 1, Name = "Kasalj", DiagnosisId = 1 },
                new Symptoms { Id = 2, Name = "Temperatura", DiagnosisId = 1 }
            );

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { Id = 1, Name = "Dijagnoza1", Symptoms = new List<Symptoms>(), MedicalRecordId = 1 },
                new Diagnosis { Id = 2, Name = "Dijagnoza2", Symptoms = new List<Symptoms>(), MedicalRecordId = 1 }
            );

            modelBuilder.Entity<FamilyIllnessHistory>().HasData(
                new FamilyIllnessHistory { Id = 1, RelativeMember = Relative.Father, Diagnosis = new List<Diagnosis>(), MedicalRecordId = 1 },
                new FamilyIllnessHistory { Id = 2, RelativeMember = Relative.Grandparents, Diagnosis = new List<Diagnosis>(), MedicalRecordId = 1 }
            );

            modelBuilder.Entity<MedicationIngredient>().HasData(
                new MedicationIngredient { Id = 1, Name = "Ibuprofen" },
                new MedicationIngredient { Id = 2, Name = "Paracetamol" }
            );

            modelBuilder.Entity<DosageOfIngredient>().HasData(
                new DosageOfIngredient { Id = 1, Amount = 100.0, MedicationIngredientId = 1, MedicationId = 1 },
                new DosageOfIngredient { Id = 2, Amount = 120.0, MedicationIngredientId = 2, MedicationId = 1 }
            );

            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { Id = 1, SpecializationName = "Interna medicina", DoctorId = "2406978890047" },
                new Specialization { Id = 2, SpecializationName = "Hirurgija", DoctorId = "2406978890047" }
            );

            modelBuilder.Entity<MedicationCategory>().HasData(
                new MedicationCategory { Id = 1, CategoryName = "Kategorija1", SpecializationId = 1, MedicationId = 1 }
            );

            modelBuilder.Entity<SideEffect>().HasData(
                new SideEffect { Id = 1, Frequency = SideEffectFrequency.Rare, SideEffectsId = 1, MedicationId = 1 },
                new SideEffect { Id = 2, Frequency = SideEffectFrequency.Common, SideEffectsId = 1, MedicationId = 1 }
            );

            modelBuilder.Entity<Medication>().HasData(
                new Medication { Id = 1, Med = "Brufen", Dosage="400mg", RoomId=1, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 2, Med = "Metafex", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 3, Med = "Neoangin", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 4, Med = "Phlebodia", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 5, Med = "Sirup", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 6, Med = "Grafalon", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 7, Med = "Zalfija", Dosage = "400mg", RoomId = 1, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() }
            );

            modelBuilder.Entity<Therapy>().HasData(
                new Therapy { Id = 1, HourConsumption = 6, MedicationId = 1, MedicalRecordId = 1 },
                new Therapy { Id = 2, HourConsumption = 10, MedicationId = 2, MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Allergens>().HasData(
                new Allergens { Id = 1, Allergen = "Polen", MedicalRecordId = 1, MedicationId = 1 },
                new Allergens { Id = 2, Allergen = "Prasina", MedicalRecordId = 1, MedicationId = 2 }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = "2406978890046",
                    CurrResidenceId = 1,
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "pera@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicyId = "policy1",
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "pera",
                    Password = "pera1978",
                    Phone = "065/123-4554",
                    PlaceOfBirthId = 11000,
                    Profession = "vodoinstalater",
                    ProfileImage = ".",
                    IsGuestAccount = false,
                    ChosenDoctorId = "2406978890047"
                }
            );

            modelBuilder.Entity<Doctor>().HasData(
             new Doctor
             {
                 Id = "2406978890047",
                 CurrResidenceId = 1,
                 DateOfBirth = new DateTime(1978, 6, 24),
                 DateOfCreation = new DateTime(),
                 EducationLevel = EducationLevel.bachelor,
                 Email = "mika@gmail.com",
                 Gender = Gender.MALE,
                 InsurancePolicyId = "policy1",
                 Name = "Milan",
                 Surname = "Milanovic",
                 Username = "mika",
                 Password = "mika1978",
                 Phone = "065/123-4554",
                 PlaceOfBirthId = 11000,
                 Profession = "vodoinstalater",
                 ProfileImage = ".",
                 LicenseNumber = "001",
                 OnCall = true,
                 PatientReview = 4.5,
                 DepartmentId = 1,
                 ExaminationRoomId = 1,
                 OperationRoomId = 2,
                 Specializations = new List<Specialization>()
             }
            );

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord
                {
                    Id = 1,
                    CurrHealthState = PatientCondition.HospitalTreatment,
                    BloodType = BloodType.ANeg,
                    Allergies = new List<Allergens>(),
                    Vaccines = new List<Vaccines>(),
                    IllnessHistory = new List<Diagnosis>(),
                    FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                    PatientId = "2406978890046",
                    Therapies = new List<Therapy>()
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Infektivno", Floor = 1, HospitalId = 1 },
                new Department { Id = 2, Name = "Radiology", Floor = 1, HospitalId = 2 },
                new Department { Id = 3, Name = "Neurology", Floor = 1, HospitalId = 2 },
                new Department { Id = 4, Name = "Oncology", Floor = 1, HospitalId = 2 },
                new Department { Id = 5, Name = "Cardiology", Floor = 1, HospitalId = 2 },
                new Department { Id = 6, Name = "Intensive Care", Floor = 1, HospitalId = 2 },
                new Department { Id = 7, Name = "Gastroenterology", Floor = 1, HospitalId = 3 },
                new Department { Id = 8, Name = "Hematology", Floor = 1, HospitalId = 3 },
                new Department { Id = 9, Name = "Dialysis", Floor = 1, HospitalId = 3 },
                new Department { Id = 10, Name = "Rheumatology", Floor = 1, HospitalId = 3 },
                new Department { Id = 11, Name = "Infectous Diseases", Floor = 1, HospitalId = 3 }
            );

            modelBuilder.Entity<Hospital>().HasData(

                new Hospital { Id = 1, Description = "blablal", Name = "Medbay", AddressId = 1 },
                new Hospital { Id = 2, Description = "Nebitno 1", Name = "Hospital 1", AddressId = 3 },
                new Hospital { Id = 3, Description = "Nebitno 2", Name = "Hospital 2", AddressId = 4 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = 1, RoomLabel = "F2-G3", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Examination, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2, RoomNumber = 2, RoomLabel = "F1-C3", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Ordination, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 3, RoomNumber = 3, RoomLabel="F1-C5", RoomUse="Soba za pregledanje", BedsCapacity=10, BedsFree=3, RoomType = RoomType.Patientroom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 4, RoomNumber = 4, RoomLabel = "F1-R5", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Patientroom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 5, RoomNumber = 5, RoomLabel = "F2-C4", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Storage, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 6, RoomNumber = 6, RoomLabel = "F1-G1", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Storage, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 7, RoomNumber = 7, RoomLabel = "F2-C2", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Ordination, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 8, RoomNumber = 8, RoomLabel = "F1-R2", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.Examination, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() }
            );

            modelBuilder.Entity<HospitalEquipment>().HasData(
                new HospitalEquipment { Id = 1, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 1, EquipmentTypeId = 1 },
                new HospitalEquipment { Id = 2, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 2, EquipmentTypeId = 2 },
                new HospitalEquipment { Id = 3, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 3, EquipmentTypeId = 3 },
                new HospitalEquipment { Id = 4, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 2, EquipmentTypeId = 4 },
                new HospitalEquipment { Id = 5, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 3, EquipmentTypeId = 5 },
                new HospitalEquipment { Id = 6, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 4, EquipmentTypeId = 6 },
                new HospitalEquipment { Id = 7, QuantityInRoom = 5, QuantityInStorage = 15, RoomId = 4, EquipmentTypeId = 7 }

            );

            modelBuilder.Entity<EquipmentType>().HasData(
                new EquipmentType { Id = 1, Name = "Krevet" },
                new EquipmentType { Id = 2, Name = "Metla" },
                new EquipmentType { Id = 3, Name = "Sapun" },
                new EquipmentType { Id = 4, Name = "Spric" },
                new EquipmentType { Id = 5, Name = "Papir" },
                new EquipmentType { Id = 6, Name = "Krpa" },
                new EquipmentType { Id = 7, Name = "Sljivovica za smirenje zivaca" }

            );
        }
    }
}