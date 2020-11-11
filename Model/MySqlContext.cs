using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Examinations;
using Model.MedicalRecord;
using Model.Medications;
using Model.Reports;
using Model.Schedule;
using Model.Users;
using MySql.Data.MySqlClient;
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

   /*   public DbSet<WeeklyAppointmentReport> WeeklyAppointmentReports { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<LabTesting> LabTestings { get; set; }
        public DbSet<LabTestType> LabTestTypes { get; set; }
        private DbSet<Treatment> Treatments { get; set; } 
   */
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

            //Refactored previous solution, note tested for multiple projects
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString("MySqlConnectionString")).UseLazyLoadingProxies();
        }
        /*
        public DbSet<Symptoms> Symptoms { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<FamilyIllnessHistory> FamilyIllnessHistories { get; set; }
        public DbSet<LabResults> LabResults { get; set; }
        public DbSet<ListOfResults> ListOfResults { get; set; }
        public DbSet<Model.MedicalRecord.MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<MedicationIngredient> Ingredients { get; set; }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        /*    modelBuilder.Entity<WeeklyAppointmentReport>().HasData(
                new WeeklyAppointmentReport
                {
                    StartWeekDay = DateTime.Now,
                    Appointments = new List<Appointment>(),
                    Content = "Some content",
                    Date = DateTime.Now,
                    Id = 1
                }
                ) ;

            modelBuilder.Entity<Specialization>().HasData(
                    new Specialization { Id = 1, SpecializationName = "Specijalista hirurgije" }
                );
            modelBuilder.Entity<MedicationIngredient>().HasData(
                new MedicationIngredient { Name = "Amoksicilin", Id = 1 },
                new MedicationIngredient { Name = "Kikiriki", Id = 2}
                );
            modelBuilder.Entity<Allergens>().HasData(
                new Allergens { Allergen = "Amoksicilin", Id = 1 }
                );

            modelBuilder.Entity<LabTesting>().HasData(
                new LabTesting{Id=1, LabTestTypes = new List<LabTestType>()}
                );
            modelBuilder.Entity<LabTestType>().HasData(
                new LabTestType {Id=1,TestName = "LDL", LabTestingId = 1}
                ); */
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
                new InsurancePolicy { Company = "Dunav osiguranje d.o.o", Id = "policy1", PolicyStartDate = new DateTime(2020, 11, 1), PolicyEndDate = new DateTime(2022, 11, 1) }
            );

          /*  modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { Id = 1, Name = "Dunav osiguranje d.o.o" }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { Id = 2, Name = "Dunav  d.o.o"}
            );

           

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { Id = 1, Name = "Dunav osiguranje d.o.o", Symptoms = new List<Symptoms>()}
            ); */

          

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
                new Feedback { Id = 1, AdditionalNotes = "Sve je super!", Approved = true, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = true},
                new Feedback { Id = 2, AdditionalNotes = "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = true },
                new Feedback { Id = 3, AdditionalNotes = "Predivno, ali i ruzno! Sramite se! Cestitke... <3", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = false },
                new Feedback { Id = 4, AdditionalNotes = "Odlicno!", Approved = false, Date = new DateTime(), RegisteredUserId = "2406978890045", Anonymous = false, AllowedForPublishing = false }
            );
        }
    }
}