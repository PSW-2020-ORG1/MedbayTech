﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.ExaminationSurgery;
using Model.Medications;
using Model.Users;
using ZdravoKorporacija.Model.Users;

namespace Model
{
    public class MySqlContext : DbContext
    {
        public DbSet<LabTesting> LabTestings { get; set; }
        public DbSet<LabTestType> LabTestTypes { get; set; }
        private DbSet<Treatment> Treatments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<MedicationIngredient> Ingredients { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                );
            modelBuilder.Entity<City>().HasData(
                
                new City {Id = 21000, Name = "Novi Sad", StateId = 1},
                new City {Id = 11000, Name = "Beograd", StateId = 1}
                );

            modelBuilder.Entity<State>().HasData(
                new State {Id = 1, Name = "Serbia"}
            );

            modelBuilder.Entity<Address>().HasData(
                new Address {Id = 1, Street = "Radnicka", Number = 4, CityId = 21000},
                new Address {Id = 2, Street = "Gospodara Vucica", Number = 5, CityId = 11000}
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy {Company = "Dunav osiguranje d.o.o", Id = "policy1", PolicyStartDate = new DateTime(2020, 11, 1), PolicyEndDate = new DateTime(2022, 11, 1)}
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
                new Feedback {Id = 1, AdditionalNotes = "Sve je super!", Approved = true, Date = new DateTime(), RegisteredUserId = "2406978890045"}
            );


        }
    }
}
