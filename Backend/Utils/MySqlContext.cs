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
                
                new Medication { Id = 1, Med = "Brufen", Dosage="400mg", RoomId= 1111, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 2, Med = "Xanax", Dosage = "20mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 3, Med = "Panadon", Dosage = "500mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 4, Med = "Diazepam", Dosage = "30mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 5, Med = "Andol", Dosage = "200mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 6, Med = "Reglan", Dosage = "100mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 7, Med = "Caffetin", Dosage = "400mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 8, Med = "Plavix", Dosage = "50mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 9, Med = "Ambien", Dosage = "25mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 10, Med = "Ranisan", Dosage = "200mg", RoomId = 1111, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 11, Med = "Vicodin", Dosage = "50mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 12, Med = "Adderall", Dosage = "40mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 13, Med = "Hemomicin", Dosage = "100mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 14, Med = "Klonopin", Dosage = "20mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 15, Med = "Demerol", Dosage = "30mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 16, Med = "OxyCotin", Dosage = "40mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 17, Med = "Percocet", Dosage = "60mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 18, Med = "Ritalin", Dosage = "80mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 19, Med = "Eritromicin", Dosage = "100mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 20, Med = "Penicillin", Dosage = "200mg", RoomId = 1112, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 21, Med = "Amoksicilin", Dosage = "150mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 22, Med = "Cefaleksin", Dosage = "200mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 23, Med = "Zoloft", Dosage = "500mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 24, Med = "Lexilium", Dosage = "40mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 25, Med = "Bensedin", Dosage = "50mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 26, Med = "Benedril", Dosage = "50mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 27, Med = "Letrox", Dosage = "100mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 28, Med = "Claritin", Dosage = "25mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 29, Med = "Flobian", Dosage = "500mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 30, Med = "Lasix", Dosage = "75mg", RoomId = 1213, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 31, Med = "Brufen", Dosage="200mg", RoomId= 1214, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 32, Med = "Xanax", Dosage = "40mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 33, Med = "Panadon", Dosage = "200mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 34, Med = "Diazepam", Dosage = "60mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 35, Med = "Andol", Dosage = "400mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 36, Med = "Vicodin", Dosage = "50mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 37, Med = "Adderall", Dosage = "80mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 38, Med = "Hemomicin", Dosage = "100mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 39, Med = "Klonopin", Dosage = "20mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 40, Med = "Demerol", Dosage = "30mg", RoomId = 1214, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 41, Med = "Brufen", Dosage="400mg", RoomId= 2102, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 42, Med = "Xanax", Dosage = "20mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 43, Med = "Panadon", Dosage = "500mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 44, Med = "Diazepam", Dosage = "30mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 45, Med = "Andol", Dosage = "200mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 46, Med = "Reglan", Dosage = "100mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 47, Med = "Caffetin", Dosage = "400mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 48, Med = "Plavix", Dosage = "50mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 49, Med = "Ambien", Dosage = "25mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 50, Med = "Ranisan", Dosage = "200mg", RoomId = 2102, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 51, Med = "Vicodin", Dosage = "50mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 52, Med = "Adderall", Dosage = "40mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 53, Med = "Hemomicin", Dosage = "100mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 54, Med = "Klonopin", Dosage = "20mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 55, Med = "Demerol", Dosage = "30mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 56, Med = "OxyCotin", Dosage = "40mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 57, Med = "Percocet", Dosage = "60mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 58, Med = "Ritalin", Dosage = "80mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 59, Med = "Eritromicin", Dosage = "100mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 60, Med = "Penicillin", Dosage = "200mg", RoomId = 2103, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 61, Med = "Amoksicilin", Dosage = "150mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 62, Med = "Cefaleksin", Dosage = "200mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 63, Med = "Zoloft", Dosage = "500mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 64, Med = "Lexilium", Dosage = "40mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 65, Med = "Bensedin", Dosage = "50mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 67, Med = "Letrox", Dosage = "100mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 68, Med = "Claritin", Dosage = "25mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 69, Med = "Flobian", Dosage = "500mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 70, Med = "Lasix", Dosage = "75mg", RoomId = 2106, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 71, Med = "Brufen", Dosage="200mg", RoomId= 2106, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 72, Med = "Xanax", Dosage = "40mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 73, Med = "Panadon", Dosage = "200mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 74, Med = "Diazepam", Dosage = "60mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 75, Med = "Andol", Dosage = "400mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 76, Med = "Vicodin", Dosage = "50mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 77, Med = "Adderall", Dosage = "80mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 78, Med = "Hemomicin", Dosage = "100mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 79, Med = "Klonopin", Dosage = "20mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 80, Med = "Demerol", Dosage = "30mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 81, Med = "Amoksicilin", Dosage = "250mg", RoomId = 2107, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 82, Med = "Cefaleksin", Dosage = "100mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 83, Med = "Zoloft", Dosage = "200mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 84, Med = "Lexilium", Dosage = "80mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 85, Med = "Bensedin", Dosage = "10mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 86, Med = "Brufen", Dosage="100mg", RoomId= 2202, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 87, Med = "Xanax", Dosage = "60mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 88, Med = "Panadon", Dosage = "250mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 89, Med = "Diazepam", Dosage = "800mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 90, Med = "Andol", Dosage = "150mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 91, Med = "Reglan", Dosage = "125mg", RoomId = 2202, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 92, Med = "Caffetin", Dosage = "200mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 93, Med = "Plavix", Dosage = "100mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 94, Med = "Ambien", Dosage = "50mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 95, Med = "Ranisan", Dosage = "100mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 96, Med = "Demerol", Dosage = "60mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 97, Med = "OxyCotin", Dosage = "25mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 98, Med = "Percocet", Dosage = "30mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 99, Med = "Ritalin", Dosage = "40mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 100, Med = "Eritromicin", Dosage = "100mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() },
                new Medication { Id = 101, Med = "Penicillin", Dosage = "100mg", RoomId = 2206, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() }


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

                new Room { Id = 1, RoomNumber = 1, RoomLabel = "null", RoomUse = "null", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2, RoomNumber = 2, RoomLabel = "null", RoomUse = "null", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1001, RoomNumber = 1, RoomLabel = "0F-GN1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1002, RoomNumber = 2, RoomLabel = "0F-GN2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1003, RoomNumber = 3, RoomLabel = "0F-GN3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1004, RoomNumber = 4, RoomLabel = "0F-GN4", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1005, RoomNumber = 5, RoomLabel = "0F-GN5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1006, RoomNumber = 6, RoomLabel = "0F-GN6", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1007, RoomNumber = 7, RoomLabel = "0F-GN7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1008, RoomNumber = 8, RoomLabel = "0F-GN8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1009, RoomNumber = 9, RoomLabel = "0F-GN9", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1010, RoomNumber = 10, RoomLabel = "0F-GN10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1011, RoomNumber = 11, RoomLabel = "0F-GN11", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1012, RoomNumber = 12, RoomLabel = "0F-CA1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1013, RoomNumber = 13, RoomLabel = "0F-CA2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1014, RoomNumber = 14, RoomLabel = "0F-CA3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1015, RoomNumber = 15, RoomLabel = "0F-CA4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1016, RoomNumber = 16, RoomLabel = "0F-CA5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1017, RoomNumber = 17, RoomLabel = "0F-CA6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1018, RoomNumber = 18, RoomLabel = "0F-CA7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1019, RoomNumber = 19, RoomLabel = "0F-CA8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1020, RoomNumber = 20, RoomLabel = "0F-CA9", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1021, RoomNumber = 21, RoomLabel = "0F-CA10", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1101, RoomNumber = 1, RoomLabel = "1F-ON1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1102, RoomNumber = 2, RoomLabel = "1F-ON2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1103, RoomNumber = 3, RoomLabel = "1F-ON3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1104, RoomNumber = 4, RoomLabel = "1F-ON4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1105, RoomNumber = 5, RoomLabel = "1F-ON5", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1106, RoomNumber = 6, RoomLabel = "1F-ON6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1107, RoomNumber = 7, RoomLabel = "1F-ON7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1108, RoomNumber = 8, RoomLabel = "1F-ON8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1109, RoomNumber = 9, RoomLabel = "1F-ON9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1110, RoomNumber = 10, RoomLabel = "1F-ON10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1111, RoomNumber = 11, RoomLabel = "1F-ON11", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1112, RoomNumber = 12, RoomLabel = "1F-ON12", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1113, RoomNumber = 13, RoomLabel = "1F-ON13", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1114, RoomNumber = 14, RoomLabel = "1F-RD1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1115, RoomNumber = 15, RoomLabel = "1F-RD2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1116, RoomNumber = 16, RoomLabel = "1F-RD3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1117, RoomNumber = 17, RoomLabel = "1F-RD4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1118, RoomNumber = 18, RoomLabel = "1F-RD5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1119, RoomNumber = 19, RoomLabel = "1F-RD6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1120, RoomNumber = 20, RoomLabel = "1F-RD7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1121, RoomNumber = 21, RoomLabel = "1F-RD8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 1201, RoomNumber = 1, RoomLabel = "2F-NE1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1202, RoomNumber = 2, RoomLabel = "2F-NE2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1203, RoomNumber = 3, RoomLabel = "2F-NE3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1204, RoomNumber = 4, RoomLabel = "2F-NE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1205, RoomNumber = 5, RoomLabel = "2F-NE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1206, RoomNumber = 6, RoomLabel = "2F-NE6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1207, RoomNumber = 7, RoomLabel = "2F-NE7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1208, RoomNumber = 8, RoomLabel = "2F-NE8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1209, RoomNumber = 9, RoomLabel = "2F-NE9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1210, RoomNumber = 10, RoomLabel = "2F-NE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1211, RoomNumber = 11, RoomLabel = "2F-NE11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1212, RoomNumber = 12, RoomLabel = "2F-NE12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1213, RoomNumber = 13, RoomLabel = "2F-NE13", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1214, RoomNumber = 14, RoomLabel = "2F-NE14", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1215, RoomNumber = 15, RoomLabel = "2F-IC1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1216, RoomNumber = 16, RoomLabel = "2F-IC2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1217, RoomNumber = 17, RoomLabel = "2F-IC3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1218, RoomNumber = 18, RoomLabel = "2F-IC4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1219, RoomNumber = 19, RoomLabel = "2F-IC5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1220, RoomNumber = 20, RoomLabel = "2F-IC6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1221, RoomNumber = 21, RoomLabel = "2F-IC7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 1222, RoomNumber = 22, RoomLabel = "2F-IC7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 2001, RoomNumber = 1, RoomLabel = "0F-EM1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2002, RoomNumber = 2, RoomLabel = "0F-EM2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2003, RoomNumber = 3, RoomLabel = "0F-EM3", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2004, RoomNumber = 4, RoomLabel = "0F-EM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2005, RoomNumber = 5, RoomLabel = "0F-EM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2006, RoomNumber = 6, RoomLabel = "0F-EM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2007, RoomNumber = 7, RoomLabel = "0F-EM7", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2008, RoomNumber = 8, RoomLabel = "0F-EM8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2009, RoomNumber = 9, RoomLabel = "0F-DY1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2010, RoomNumber = 10, RoomLabel = "0F-DY2", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2011, RoomNumber = 11, RoomLabel = "0F-DY3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2012, RoomNumber = 12, RoomLabel = "0F-DY4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2013, RoomNumber = 13, RoomLabel = "0F-DY5", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2014, RoomNumber = 14, RoomLabel = "0F-DY6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2015, RoomNumber = 15, RoomLabel = "0F-DY7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2016, RoomNumber = 16, RoomLabel = "0F-DY8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 2101, RoomNumber = 1, RoomLabel = "1F-GE1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2102, RoomNumber = 2, RoomLabel = "1F-GE2", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2103, RoomNumber = 3, RoomLabel = "1F-GE3", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2104, RoomNumber = 4, RoomLabel = "1F-GE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2105, RoomNumber = 5, RoomLabel = "1F-GE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2106, RoomNumber = 6, RoomLabel = "1F-GE6", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2107, RoomNumber = 7, RoomLabel = "1F-GE7", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2108, RoomNumber = 8, RoomLabel = "1F-GE8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2109, RoomNumber = 9, RoomLabel = "1F-GE9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2110, RoomNumber = 10, RoomLabel = "1F-GE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2111, RoomNumber = 11, RoomLabel = "1F-GE11", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2112, RoomNumber = 12, RoomLabel = "1F-GE12", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2113, RoomNumber = 13, RoomLabel = "1F-GE13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2114, RoomNumber = 14, RoomLabel = "1F-GE14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2115, RoomNumber = 15, RoomLabel = "1F-HM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2116, RoomNumber = 16, RoomLabel = "1F-HM2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2117, RoomNumber = 17, RoomLabel = "1F-HM3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2118, RoomNumber = 18, RoomLabel = "1F-HM4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2119, RoomNumber = 19, RoomLabel = "1F-HM5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2120, RoomNumber = 20, RoomLabel = "1F-HM6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2121, RoomNumber = 21, RoomLabel = "1F-HM7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2122, RoomNumber = 22, RoomLabel = "1F-HM8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() },

                new Room { Id = 2201, RoomNumber = 1, RoomLabel = "2F-RM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2202, RoomNumber = 2, RoomLabel = "2F-RM2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2203, RoomNumber = 3, RoomLabel = "2F-RM3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2204, RoomNumber = 4, RoomLabel = "2F-RM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2205, RoomNumber = 5, RoomLabel = "2F-RM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2206, RoomNumber = 6, RoomLabel = "2F-RM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2207, RoomNumber = 7, RoomLabel = "2F-RM7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2208, RoomNumber = 8, RoomLabel = "2F-RM8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2209, RoomNumber = 9, RoomLabel = "2F-RM9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2210, RoomNumber = 10, RoomLabel = "2F-RM10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2211, RoomNumber = 11, RoomLabel = "2F-RM11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2212, RoomNumber = 12, RoomLabel = "2F-RM12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2213, RoomNumber = 13, RoomLabel = "2F-RM13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2214, RoomNumber = 14, RoomLabel = "2F-RM14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2215, RoomNumber = 15, RoomLabel = "2F-ID1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2216, RoomNumber = 16, RoomLabel = "2F-ID2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2217, RoomNumber = 17, RoomLabel = "2F-ID3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2218, RoomNumber = 18, RoomLabel = "2F-ID4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2219, RoomNumber = 19, RoomLabel = "2F-ID5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2220, RoomNumber = 20, RoomLabel = "2F-ID6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2221, RoomNumber = 21, RoomLabel = "2F-ID7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() },
                new Room { Id = 2222, RoomNumber = 22, RoomLabel = "2F-ID8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() }
            );

            modelBuilder.Entity<HospitalEquipment>().HasData(

                new HospitalEquipment { Id = 1, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 2, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 3, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 1003, EquipmentTypeId = 17 },
                new HospitalEquipment { Id = 4, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 18 },
                new HospitalEquipment { Id = 5, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 19 },
                new HospitalEquipment { Id = 6, QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 1003, EquipmentTypeId = 22 },
                new HospitalEquipment { Id = 7, QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 1003, EquipmentTypeId = 23 },
                new HospitalEquipment { Id = 8, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 24 },
                new HospitalEquipment { Id = 9, QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 1003, EquipmentTypeId = 25 },
                new HospitalEquipment { Id = 10, QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 1003, EquipmentTypeId = 26 },
                new HospitalEquipment { Id = 11, QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 1003, EquipmentTypeId = 27 },
                new HospitalEquipment { Id = 12, QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 1003, EquipmentTypeId = 28 },
                new HospitalEquipment { Id = 13, QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 1003, EquipmentTypeId = 29 },
                new HospitalEquipment { Id = 14, QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 1003, EquipmentTypeId = 30 },
                new HospitalEquipment { Id = 15, QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 1003, EquipmentTypeId = 31 },
                new HospitalEquipment { Id = 16, QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 1003, EquipmentTypeId = 32 },
                new HospitalEquipment { Id = 17, QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 1003, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 18, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 1003, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 19, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 1003, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 20, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 1003, EquipmentTypeId = 37 },
                new HospitalEquipment { Id = 21, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1012, EquipmentTypeId = 6 },
                new HospitalEquipment { Id = 22, QuantityInRoom = 4, QuantityInStorage = 16, RoomId = 1012, EquipmentTypeId = 7 },
                new HospitalEquipment { Id = 23, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 1014, EquipmentTypeId = 8 },
                new HospitalEquipment { Id = 24, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 1014, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 25, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 1014, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 26, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1014, EquipmentTypeId = 11 },
                new HospitalEquipment { Id = 27, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1014, EquipmentTypeId = 12 },
                new HospitalEquipment { Id = 28, QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 1014, EquipmentTypeId = 33 },
                new HospitalEquipment { Id = 29, QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 1014, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 30, QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 1014, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 31, QuantityInRoom = 1, QuantityInStorage = 4, RoomId = 1019, EquipmentTypeId = 5 },
                new HospitalEquipment { Id = 32, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1019, EquipmentTypeId = 6 },

                new HospitalEquipment { Id = 33, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1110, EquipmentTypeId = 3 },
                new HospitalEquipment { Id = 34, QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 1113, EquipmentTypeId = 1 },
                new HospitalEquipment { Id = 35, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1114, EquipmentTypeId = 2 },
                new HospitalEquipment { Id = 36, QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 1115, EquipmentTypeId = 1 },
                new HospitalEquipment { Id = 37, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1116, EquipmentTypeId = 3 },
                new HospitalEquipment { Id = 38, QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 1119, EquipmentTypeId = 4 },

                new HospitalEquipment { Id = 39, QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 1210, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 40, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 1210, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 41, QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 1210, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 42, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1217, EquipmentTypeId = 8 },
                new HospitalEquipment { Id = 43, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1217, EquipmentTypeId = 11 },
                new HospitalEquipment { Id = 44, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1217, EquipmentTypeId = 12 },
                new HospitalEquipment { Id = 45, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 1217, EquipmentTypeId = 13 },
                new HospitalEquipment { Id = 46, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1217, EquipmentTypeId = 18 },
                new HospitalEquipment { Id = 47, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1217, EquipmentTypeId = 19 },
                new HospitalEquipment { Id = 48, QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 1217, EquipmentTypeId = 20 },
                new HospitalEquipment { Id = 49, QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 1217, EquipmentTypeId = 21 },
                new HospitalEquipment { Id = 50, QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 1217, EquipmentTypeId = 22 },
                new HospitalEquipment { Id = 51, QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 1217, EquipmentTypeId = 23 },
                new HospitalEquipment { Id = 52, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1217, EquipmentTypeId = 24 },
                new HospitalEquipment { Id = 53, QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 1217, EquipmentTypeId = 25 },
                new HospitalEquipment { Id = 54, QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 1217, EquipmentTypeId = 26 },
                new HospitalEquipment { Id = 55, QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 1217, EquipmentTypeId = 27 },
                new HospitalEquipment { Id = 56, QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 1217, EquipmentTypeId = 28 },
                new HospitalEquipment { Id = 57, QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 1217, EquipmentTypeId = 29 },
                new HospitalEquipment { Id = 58, QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 1217, EquipmentTypeId = 30 },
                new HospitalEquipment { Id = 59, QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 1217, EquipmentTypeId = 31 },
                new HospitalEquipment { Id = 60, QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 1217, EquipmentTypeId = 32 },

                new HospitalEquipment { Id = 61, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 2005, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 62, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 2005, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 63, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2005, EquipmentTypeId = 17 },
                new HospitalEquipment { Id = 64, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 2005, EquipmentTypeId = 18 },
                new HospitalEquipment { Id = 65, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 2005, EquipmentTypeId = 19 },
                new HospitalEquipment { Id = 66, QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 2005, EquipmentTypeId = 22 },
                new HospitalEquipment { Id = 67, QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 2005, EquipmentTypeId = 23 },
                new HospitalEquipment { Id = 68, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 2005, EquipmentTypeId = 24 },
                new HospitalEquipment { Id = 69, QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 2005, EquipmentTypeId = 25 },
                new HospitalEquipment { Id = 70, QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 2005, EquipmentTypeId = 26 },
                new HospitalEquipment { Id = 71, QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 2005, EquipmentTypeId = 27 },
                new HospitalEquipment { Id = 72, QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 2005, EquipmentTypeId = 28 },
                new HospitalEquipment { Id = 73, QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 2005, EquipmentTypeId = 29 },
                new HospitalEquipment { Id = 74, QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 2005, EquipmentTypeId = 30 },
                new HospitalEquipment { Id = 75, QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 2005, EquipmentTypeId = 31 },
                new HospitalEquipment { Id = 76, QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 2005, EquipmentTypeId = 32 },
                new HospitalEquipment { Id = 77, QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 2005, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 78, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 2005, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 79, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2005, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 80, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2005, EquipmentTypeId = 37 },
                new HospitalEquipment { Id = 81, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2009, EquipmentTypeId = 8 },
                new HospitalEquipment { Id = 82, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2009, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 83, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2009, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 84, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 2009, EquipmentTypeId = 11 },
                new HospitalEquipment { Id = 85, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 2009, EquipmentTypeId = 12 },
                new HospitalEquipment { Id = 86, QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 2009, EquipmentTypeId = 33 },
                new HospitalEquipment { Id = 87, QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 2009, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 88, QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 2009, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 89, QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 2009, EquipmentTypeId = 39 },
                new HospitalEquipment { Id = 90, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2010, EquipmentTypeId = 40 },
                new HospitalEquipment { Id = 91, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2013, EquipmentTypeId = 40 },

                new HospitalEquipment { Id = 92, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2105, EquipmentTypeId = 14 },
                new HospitalEquipment { Id = 93, QuantityInRoom = 1, QuantityInStorage = 6, RoomId = 2108, EquipmentTypeId = 15 },
                new HospitalEquipment { Id = 94, QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 2117, EquipmentTypeId = 16 },
                new HospitalEquipment { Id = 95, QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 2118, EquipmentTypeId = 16 },

                new HospitalEquipment { Id = 96, QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 2208, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 97, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 2208, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 98, QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 2208, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 99, QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 2209, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 100, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 2209, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 101, QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 2209, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 102, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2210, EquipmentTypeId = 17 },
                new HospitalEquipment { Id = 103, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 2210, EquipmentTypeId = 24 },
                new HospitalEquipment { Id = 104, QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 2210, EquipmentTypeId = 25 },
                new HospitalEquipment { Id = 105, QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 2210, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 106, QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 2210, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 107, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2210, EquipmentTypeId = 36 },
                new HospitalEquipment { Id = 108, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 2210, EquipmentTypeId = 37 },
                new HospitalEquipment { Id = 109, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2217, EquipmentTypeId = 8 },
                new HospitalEquipment { Id = 110, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2217, EquipmentTypeId = 9 },
                new HospitalEquipment { Id = 111, QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 2217, EquipmentTypeId = 10 },
                new HospitalEquipment { Id = 112, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 2217, EquipmentTypeId = 11 },
                new HospitalEquipment { Id = 113, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 2217, EquipmentTypeId = 12 },
                new HospitalEquipment { Id = 114, QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 2217, EquipmentTypeId = 13 },
                new HospitalEquipment { Id = 115, QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 2217, EquipmentTypeId = 33 },
                new HospitalEquipment { Id = 116, QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 2217, EquipmentTypeId = 34 },
                new HospitalEquipment { Id = 117, QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 2217, EquipmentTypeId = 35 },
                new HospitalEquipment { Id = 118, QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 2217, EquipmentTypeId = 39 }



            );

            modelBuilder.Entity<EquipmentType>().HasData(
                new EquipmentType { Id = 1, Name = "Mamogram" },
                new EquipmentType { Id = 2, Name = "X-ray" },
                new EquipmentType { Id = 3, Name = "CT" },
                new EquipmentType { Id = 4, Name = "MRI" },
                new EquipmentType { Id = 5, Name = "Ultra sound" },
                new EquipmentType { Id = 6, Name = "EKG" },
                new EquipmentType { Id = 7, Name = "Holter" },
                new EquipmentType { Id = 8, Name = "Heart rate monitor" },
                new EquipmentType { Id = 9, Name = "Blood preasure monitor" },
                new EquipmentType { Id = 10, Name = "Blood shugar monitor" },
                new EquipmentType { Id = 11, Name = "Defibrilator" },
                new EquipmentType { Id = 12, Name = "Oxygen" },
                new EquipmentType { Id = 13, Name = "Respirator" },
                new EquipmentType { Id = 14, Name = "Gastroscope" },
                new EquipmentType { Id = 15, Name = "Colonoscope" },
                new EquipmentType { Id = 16, Name = "Blood test machine" },
                new EquipmentType { Id = 17, Name = "Stethoscope" },
                new EquipmentType { Id = 18, Name = "Suringe" },
                new EquipmentType { Id = 19, Name = "Needle" },
                new EquipmentType { Id = 20, Name = "Scalpel" },
                new EquipmentType { Id = 21, Name = "Pean" },
                new EquipmentType { Id = 22, Name = "Scissors" },
                new EquipmentType { Id = 23, Name = "Tweezers" },
                new EquipmentType { Id = 24, Name = "Surgical mask" },
                new EquipmentType { Id = 25, Name = "Surgical gloves" },
                new EquipmentType { Id = 26, Name = "Bandage" },
                new EquipmentType { Id = 27, Name = "Gauze" },
                new EquipmentType { Id = 28, Name = "Cotton pad" },
                new EquipmentType { Id = 29, Name = "Adhesive tape" },
                new EquipmentType { Id = 30, Name = "Alcohol" },
                new EquipmentType { Id = 31, Name = "Iodine" },
                new EquipmentType { Id = 32, Name = "Hydrogen peroxide" },
                new EquipmentType { Id = 33, Name = "Bed" },
                new EquipmentType { Id = 34, Name = "Table" },
                new EquipmentType { Id = 35, Name = "Chair" },
                new EquipmentType { Id = 36, Name = "Computer" },
                new EquipmentType { Id = 37, Name = "Examining table" },
                new EquipmentType { Id = 38, Name = "Weelchair" },
                new EquipmentType { Id = 39, Name = "Thermometer" },
                new EquipmentType { Id = 40, Name = "Dialysis machine" }

            );
        }
    }
}