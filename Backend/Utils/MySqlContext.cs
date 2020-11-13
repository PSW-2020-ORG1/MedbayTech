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

namespace Model
{
    public class MySqlContext : DbContext
    {

        private int mySqlConnectionPort = 3306;
        private string mySqlConnectionUid = "root";
        private string mySqlConnectionPassword = "root";
        private string mySqlDatabaseName = "newdb";
        private string mySqlHostAddress = "localhost";

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
        {}
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().HasNoKey();
            // NOTE(Jovan): Only for testing. It is recommended to fill dummy data via
            // repositories
            modelBuilder.Entity<State>().HasData(
                new State { Id=1, Name="Serbia"}
                );
            modelBuilder.Entity<City>().HasData(
                new City { Id=21000, Name="Novi Sad", StateId=1}
                );
        }
    }
}