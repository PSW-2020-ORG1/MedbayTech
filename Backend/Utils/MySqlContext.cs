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
            optionsBuilder.UseMySql(configuration.GetConnectionString("MySqlConnectionString")).UseLazyLoadingProxies();

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
                new Medication { Id = 1, Med = "Brufen", Dosage="400mg", RoomId= 1001, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 2, Med = "Xanax", Dosage = "20mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 3, Med = "Panadon", Dosage = "500mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 4, Med = "Diazepam", Dosage = "30mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 5, Med = "Andol", Dosage = "200mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 6, Med = "Reglan", Dosage = "100mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 7, Med = "Caffetin", Dosage = "400mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 8, Med = "Plavix", Dosage = "50mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 9, Med = "Ambien", Dosage = "25mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 10, Med = "Ranisan", Dosage = "200mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 11, Med = "Vicodin", Dosage = "50mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 12, Med = "Adderall", Dosage = "40mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 13, Med = "Hemomicin", Dosage = "100mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 14, Med = "Klonopin", Dosage = "20mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 15, Med = "Demerol", Dosage = "30mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 16, Med = "OxyCotin", Dosage = "40mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 17, Med = "Percocet", Dosage = "60mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 18, Med = "Ritalin", Dosage = "80mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 19, Med = "Eritromicin", Dosage = "100mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 20, Med = "Penicillin", Dosage = "200mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 21, Med = "Amoksicilin", Dosage = "150mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 22, Med = "Cefaleksin", Dosage = "200mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 23, Med = "Zoloft", Dosage = "500mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 24, Med = "Lexilium", Dosage = "40mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 25, Med = "Bensedin", Dosage = "50mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 27, Med = "Letrox", Dosage = "100mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 28, Med = "Claritin", Dosage = "25mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 29, Med = "Flobian", Dosage = "500mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 30, Med = "Lasix", Dosage = "75mg", RoomId = 1001, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() }

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
                new Department { Id = 1, Name = "General H1", Floor = 0, HospitalId = 1 },
                new Department { Id = 2, Name = "Cardiology", Floor = 0, HospitalId = 1 },
                new Department { Id = 3, Name = "Oncology", Floor = 1, HospitalId = 1 },
                new Department { Id = 4, Name = "Radiology", Floor = 1, HospitalId = 1 },
                new Department { Id = 5, Name = "Neurology", Floor = 2, HospitalId = 1 },
                new Department { Id = 6, Name = "Intensive Care", Floor = 2, HospitalId = 1 },
                new Department { Id = 7, Name = "General H2", Floor = 0, HospitalId = 2 },
                new Department { Id = 8, Name = "Dialysis", Floor = 0, HospitalId = 2 },
                new Department { Id = 9, Name = "Gastroenterology", Floor = 1, HospitalId = 2 },
                new Department { Id = 10, Name = "Hematology", Floor = 1, HospitalId = 2 },
                new Department { Id = 11, Name = "Rheumatology", Floor = 2, HospitalId = 2 },
                new Department { Id = 12, Name = "Infectous Diseases", Floor = 2, HospitalId = 2 },
                new Department { Id = 13, Name = "Infektivno", Floor = 1, HospitalId = 3 }
            );

            modelBuilder.Entity<Hospital>().HasData(

                new Hospital { Id = 3, Description = "blablal", Name = "Medbay", AddressId = 1 },
                new Hospital { Id = 1, Description = "Hospital 1", Name = "Hospital 1", AddressId = 3 },
                new Hospital { Id = 2, Description = "Hospital 2", Name = "Hospital 2", AddressId = 4 }
            );
            
            modelBuilder.Entity<Room>().HasData(

                new Room { Id = 1, RoomNumber = 1, RoomLabel = "F2-G3", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2, RoomNumber = 2, RoomLabel = "F1-C3", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 3, RoomNumber = 3, RoomLabel="F1-C5", RoomUse="Soba za pregledanje", BedsCapacity=10, BedsFree=3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 4, RoomNumber = 4, RoomLabel = "F1-R5", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 5, RoomNumber = 5, RoomLabel = "F2-C4", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 6, RoomNumber = 6, RoomLabel = "F1-G1", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 7, RoomNumber = 7, RoomLabel = "F2-C2", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 8, RoomNumber = 8, RoomLabel = "F1-R2", RoomUse = "Soba za pregledanje", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1001, RoomNumber = 1, RoomLabel = "0F-GH1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1002, RoomNumber = 2, RoomLabel = "0F-GH2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1003, RoomNumber = 3, RoomLabel = "0F-GH3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1004, RoomNumber = 4, RoomLabel = "0F-GH4", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1005, RoomNumber = 5, RoomLabel = "0F-GH5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1006, RoomNumber = 6, RoomLabel = "0F-GH6", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1007, RoomNumber = 7, RoomLabel = "0F-GH7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1008, RoomNumber = 8, RoomLabel = "0F-GH8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1009, RoomNumber = 9, RoomLabel = "0F-GH9", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1010, RoomNumber = 10, RoomLabel = "0F-GH10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1011, RoomNumber = 11, RoomLabel = "0F-GH11", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1012, RoomNumber = 12, RoomLabel = "0F-C1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1013, RoomNumber = 13, RoomLabel = "0F-c2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1014, RoomNumber = 14, RoomLabel = "0F-C3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1015, RoomNumber = 15, RoomLabel = "0F-C4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1016, RoomNumber = 16, RoomLabel = "0F-C5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1017, RoomNumber = 17, RoomLabel = "0F-C6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1018, RoomNumber = 18, RoomLabel = "0F-C7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1019, RoomNumber = 19, RoomLabel = "0F-C8", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1020, RoomNumber = 20, RoomLabel = "0F-E1", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1021, RoomNumber = 21, RoomLabel = "0F-E2", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1101, RoomNumber = 1, RoomLabel = "1F-O1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1102, RoomNumber = 2, RoomLabel = "1F-O2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1103, RoomNumber = 3, RoomLabel = "1F-O3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1104, RoomNumber = 4, RoomLabel = "1F-O4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1105, RoomNumber = 5, RoomLabel = "1F-O5", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1106, RoomNumber = 6, RoomLabel = "1F-O6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1107, RoomNumber = 7, RoomLabel = "1F-O7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1108, RoomNumber = 8, RoomLabel = "1F-O8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1109, RoomNumber = 9, RoomLabel = "1F-O9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1110, RoomNumber = 10, RoomLabel = "1F-O10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1111, RoomNumber = 11, RoomLabel = "1F-O11", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1112, RoomNumber = 12, RoomLabel = "1F-O12", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1113, RoomNumber = 13, RoomLabel = "1F-O13", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1114, RoomNumber = 14, RoomLabel = "1F-R1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1115, RoomNumber = 15, RoomLabel = "1F-R2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1116, RoomNumber = 16, RoomLabel = "1F-R3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1117, RoomNumber = 17, RoomLabel = "1F-R4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1118, RoomNumber = 18, RoomLabel = "1F-R5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1119, RoomNumber = 19, RoomLabel = "1F-R6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1120, RoomNumber = 20, RoomLabel = "1F-R7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1121, RoomNumber = 21, RoomLabel = "1F-R8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1201, RoomNumber = 1, RoomLabel = "2F-N1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1202, RoomNumber = 2, RoomLabel = "2F-N2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1203, RoomNumber = 3, RoomLabel = "2F-N3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1204, RoomNumber = 4, RoomLabel = "2F-N4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1205, RoomNumber = 5, RoomLabel = "2F-N5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1206, RoomNumber = 6, RoomLabel = "2F-N6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1207, RoomNumber = 7, RoomLabel = "2F-N7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1208, RoomNumber = 8, RoomLabel = "2F-N8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1209, RoomNumber = 9, RoomLabel = "2F-N9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1210, RoomNumber = 10, RoomLabel = "2F-N10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1211, RoomNumber = 11, RoomLabel = "2F-N11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1212, RoomNumber = 12, RoomLabel = "2F-N12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1213, RoomNumber = 13, RoomLabel = "2F-N13", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1214, RoomNumber = 14, RoomLabel = "2F-N14", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1215, RoomNumber = 15, RoomLabel = "2F-IC1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1216, RoomNumber = 16, RoomLabel = "2F-IC2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1217, RoomNumber = 17, RoomLabel = "2F-IC3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1218, RoomNumber = 18, RoomLabel = "2F-IC4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1219, RoomNumber = 19, RoomLabel = "2F-IC5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1220, RoomNumber = 20, RoomLabel = "2F-IC6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1221, RoomNumber = 21, RoomLabel = "2F-IC7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1222, RoomNumber = 22, RoomLabel = "2F-IC7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() }
            );

            modelBuilder.Entity<HospitalEquipment>().HasData(
                new HospitalEquipment { Id = 1, QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 1002, EquipmentTypeId = 1 },
                new HospitalEquipment { Id = 2, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1002, EquipmentTypeId = 2 },
                new HospitalEquipment { Id = 3, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1002, EquipmentTypeId = 3 },
                new HospitalEquipment { Id = 4, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1002, EquipmentTypeId = 4 },
                new HospitalEquipment { Id = 5, QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 1002, EquipmentTypeId = 5 },
                new HospitalEquipment { Id = 6, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1002, EquipmentTypeId = 6 },
                new HospitalEquipment { Id = 7, QuantityInRoom = 1, QuantityInStorage = 4, RoomId = 1002, EquipmentTypeId = 7 },
                new HospitalEquipment { Id = 8, QuantityInRoom = 1, QuantityInStorage = 3, RoomId = 1002, EquipmentTypeId = 8 },
                new HospitalEquipment { Id = 9, QuantityInRoom = 2, QuantityInStorage = 15, RoomId = 1002, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 10, QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 1002, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 11, QuantityInRoom = 2, QuantityInStorage = 20, RoomId = 1002, EquipmentTypeId = 11 },
                new HospitalEquipment { Id = 12, QuantityInRoom = 5, QuantityInStorage = 100, RoomId = 1002, EquipmentTypeId = 12 },
                new HospitalEquipment { Id = 13, QuantityInRoom = 5, QuantityInStorage = 200, RoomId = 1002, EquipmentTypeId = 13 },
                new HospitalEquipment { Id = 14, QuantityInRoom = 3, QuantityInStorage = 14, RoomId = 1002, EquipmentTypeId = 14 },
                new HospitalEquipment { Id = 15, QuantityInRoom = 3, QuantityInStorage = 13, RoomId = 1002, EquipmentTypeId = 15 },
                new HospitalEquipment { Id = 16, QuantityInRoom = 3, QuantityInStorage = 16, RoomId = 1002, EquipmentTypeId = 16 },
                new HospitalEquipment { Id = 17, QuantityInRoom = 10, QuantityInStorage = 500, RoomId = 1002, EquipmentTypeId = 17 },
                new HospitalEquipment { Id = 18, QuantityInRoom = 10, QuantityInStorage = 1000, RoomId = 1002, EquipmentTypeId = 18 },
                new HospitalEquipment { Id = 19, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 1002, EquipmentTypeId = 19 },
                new HospitalEquipment { Id = 20, QuantityInRoom = 4, QuantityInStorage = 5, RoomId = 1002, EquipmentTypeId = 20 }

            );

            modelBuilder.Entity<EquipmentType>().HasData(
                new EquipmentType { Id = 1, Name = "Mamogram" },
                new EquipmentType { Id = 2, Name = "X-ray" },
                new EquipmentType { Id = 3, Name = "CT" },
                new EquipmentType { Id = 4, Name = "MRI" },
                new EquipmentType { Id = 5, Name = "Ultra sound" },
                new EquipmentType { Id = 6, Name = "EKG" },
                new EquipmentType { Id = 7, Name = "Holter" },
                new EquipmentType { Id = 8, Name = "Gastroscope" },
                new EquipmentType { Id = 9, Name = "Blood preasure monitor" },
                new EquipmentType { Id = 10, Name = "Otoscope" },
                new EquipmentType { Id = 11, Name = "Stethoscope" },
                new EquipmentType { Id = 12, Name = "Suringe" },
                new EquipmentType { Id = 13, Name = "Needle" },
                new EquipmentType { Id = 14, Name = "Scalpel" },
                new EquipmentType { Id = 15, Name = "Pean" },
                new EquipmentType { Id = 16, Name = "Scissors" },
                new EquipmentType { Id = 17, Name = "Surgical mask" },
                new EquipmentType { Id = 18, Name = "Surgical gloves" },
                new EquipmentType { Id = 19, Name = "Computer" },
                new EquipmentType { Id = 20, Name = "Bed" }
            


            );
        }
    }
}