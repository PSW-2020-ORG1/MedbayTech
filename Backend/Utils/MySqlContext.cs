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

                new City(21000, "Novi Sad", new State(1, "Serbia")),
                new City(11000, "Beograd", new State(1, "Serbia"))
                );

            modelBuilder.Entity<State>().HasData(
                 new State(1, "Serbia")
            );

            modelBuilder.Entity<Address>().HasData(
                new Address(1, "Radnicka", 4, 28, 7, new City(21000, "Novi Sad", new State(1, "Serbia"))),
                new Address(2, "1100 Kaplara", 3, 23, 7, new City(21000, "Novi Sad", new State(1, "Serbia")))
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy("policy1", "Dunav Osiguranje D.O.O", new Period(new DateTime(2020, 11, 1), new DateTime(2022, 11, 1)))
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
                new RegisteredUser("Marko", "Markic", new DateTime(1978, 6, 24), "2406978890045", "marko@gmail.com", "markic",
                "065/123-4554", "marko1978", EducationLevel.bachelor, Gender.MALE, "Vodoinstalater", new City(21000, "Novi Sad", new State(1, "Serbia")),
                new Address(1, "Radnicka", 4, 28, 7, new City(21000, "Novi Sad", new State(1, "Serbia"))),
                new InsurancePolicy("policy1", "Dunav Osiguranje D.O.O", new Period(new DateTime(2020, 11, 1), new DateTime(2022, 11, 1))),
                "")
                );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback(2, DateTime.Now, "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!",
                Grade.veryPoor, true, true, new RegisteredUser("Marko", "Markic", new DateTime(1978, 6, 24), "2406978890045", "marko@gmail.com", "markic",
                "065/123-4554", "marko1978", EducationLevel.bachelor, Gender.MALE, "Vodoinstalater", new City(21000, "Novi Sad", new State(1, "Serbia")),
                new Address(1, "Radnicka", 4, 28, 7, new City(21000, "Novi Sad", new State(1, "Serbia"))),
                new InsurancePolicy("policy1", "Dunav Osiguranje D.O.O", new Period(new DateTime(2020, 11, 1), new DateTime(2022, 11, 1))),
                ""))
            );
        }
    }
}