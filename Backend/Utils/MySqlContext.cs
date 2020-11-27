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
                new Address { Id = 2, Street = "Gospodara Vucica", Number = 5, CityId = 11000 }
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy { Company = "Dunav osiguranje d.o.o", Id = "policy1", StartTime = new DateTime(2020, 11, 1), EndTime =  new DateTime(2020, 11, 1) }
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


        }
    }
}