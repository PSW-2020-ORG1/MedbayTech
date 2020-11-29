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
using ZdravoKorporacija.Model.Users;
using Backend.Utils;
using Model.Rooms;
using System.Linq;
using Backend.Medications.Model;
using PharmacyIntegration.Model;
using Backend.Reports.Model;

namespace Model
{
    public class MySqlContext : DbContext
    {

        private int mySqlConnectionPort = 3306;
        private string mySqlConnectionUid = "root";
        private string mySqlConnectionPassword = "root";
        private string mySqlDatabaseName = "newdb";
        private string mySqlHostAddress = "localhost";

        public DbSet<MedicationUsage> MedicationUsages { get; set; }
        public DbSet<MedicationUsageReport> MedicationUsageReports { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<Survey> Surveys{ get; set; }
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
                optionsBuilder.UseMySql($"Server={mySqlHostAddress};port={mySqlConnectionPort};Database={mySqlDatabaseName};user={mySqlConnectionUid};password={mySqlConnectionPassword}").UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().HasNoKey();
            modelBuilder.Entity<Occupation>().HasNoKey();
            modelBuilder.Entity<Shift>().HasNoKey();
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Name = "Serbia" }
                );
            modelBuilder.Entity<City>().HasData(
                new City { Id = 21000, Name = "Novi Sad", StateId = 1 }
                );

            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA", APIEndpoint = "jankovic.rs" },
                new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA", APIEndpoint = "liman.li" }
            );

            modelBuilder.Entity<PharmacyNotification>().HasData(
                new PharmacyNotification { Id = 1, Content = "Aspirin nam je jeftin. Bas jako.", Approved = true },
                new PharmacyNotification { Id = 2, Content = "Brufen nam je jeftin. Bas jako.", Approved = true }
            );

            modelBuilder.Entity<Specialization>().HasData(
                    new Specialization { Id = 1, SpecializationName = "DrugSpec"}
                );

            modelBuilder.Entity<MedicationCategory>().HasData(
                    new MedicationCategory { Id = 1, CategoryName = "Drug", SpecializationId = 1 }
                );

            modelBuilder.Entity<Medication>().HasData(
                    new Medication { Id = 1, Med = "Aspirin 325mg", Company = "Bayer", MedicationCategoryId = 1 },
                    new Medication { Id = 2, Med = "Cyclopentanoperhydrophenanthrene 5mg", Company = "StrongDrugs Inc.", MedicationCategoryId = 1 }
                );

            modelBuilder.Entity<MedicationUsage>().HasData(
                    new MedicationUsage { Id = 1, Usage = 4, MedicationId = 1 },
                    new MedicationUsage { Id = 2, Usage = 10, MedicationId = 2 }
                );

        }
    }
}