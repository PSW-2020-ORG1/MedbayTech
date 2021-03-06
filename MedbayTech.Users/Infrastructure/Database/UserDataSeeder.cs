﻿using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Domain.ValueObjects;

namespace MedbayTech.Users.Infrastructure.Database
{
    public class UserDataSeeder
    {
        public UserDataSeeder()
        {
        }

        public void SeedAllEntities(UserDbContext context)
        {
            SeedSpecializations(context);
            SeedUsers(context);
            SeedDoctors(context);
            SeedDoctorsWorkDay(context);
            SeedPatients(context);

            context.SaveChanges();
        }

        private void SeedSpecializations(UserDbContext context)
        {
            context.Add(new Specialization { SpecializationName = "Interna medicina" });
            context.Add(new Specialization { SpecializationName = "Hirurgija" });
            context.SaveChanges();
        }

        private void SeedPatients(UserDbContext context)
        {
            context.Add(new Patient
            {
                Id = "2208978890016",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                EducationLevel = EducationLevel.bachelor,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                Name = "Ognjen",
                Surname = "Ognjenovic",
                Username = "ogisa",
                Password = "ogisa1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8081/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",

                Role = Role.Patient,
                Confirmed = true

            });
            context.Add(new Patient
            {
                Id = "1101978890089",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                EducationLevel = EducationLevel.bachelor,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                Name = "Filip",
                Surname = "Filipovic",
                Username = "fiki",
                Password = "fiki1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8081/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",

                Role = Role.Patient,
                Confirmed = true

            });
            context.Add(new Patient
            {
                Id = "2406978890046",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                EducationLevel = EducationLevel.bachelor,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                Name = "Petar",
                Surname = "Petrovic",
                Username = "pera",
                Password = "pera1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8081/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",

                Role = Role.Patient,
                Confirmed = true

            });
            context.Add(new Patient
            {
                Id = "2406978890026",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                EducationLevel = EducationLevel.bachelor,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Email = "daca@gmail.com",
                Gender = Gender.MALE,
                Name = "Dejvid",
                Surname = "Dejvidovic",
                Username = "dejvid",
                Password = "dejvid1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8081/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ShouldBeBlocked = true,
                ChosenDoctorId = "2406978890047",

                Role = Role.Patient,
                Confirmed = true

            }) ;
            context.SaveChanges();
        }

        private void SeedUsers(UserDbContext context)
        {
            context.Add(new RegisteredUser
            {
                Id = "2406978890045",
                CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                Profession = "vodoinstalater",
                ProfileImage = ".",
                Role = Role.Admin

            });
            context.SaveChanges();
        }


        private void SeedDoctors(UserDbContext context)
        {
                context.Add(new Doctor
                {
                    Id = "2406978890047",
                    CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "mika@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                    Name = "Milan",
                    Surname = "Milanovic",
                    Username = "mika",
                    Password = "mika1978",
                    Phone = "065/123-4554",
                    PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                    Profession = "vodoinstalater",
                    ProfileImage = ".",
                    LicenseNumber = "001",
                    OnCall = true,
                    PatientReview = 4.5,
                    DepartmentId = 1,
                    ExaminationRoomId = 49,
                    OperationRoomId = 116,
                    SpecializationId = 1,
                    Role = Role.Doctor
                });

                context.Add(new Doctor
                {
                    Id = "2407978890045",
                    CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "ivan@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                    Name = "Ivan",
                    Surname = "Ivanovic",
                    Username = "ivan",
                    Password = "ivan123",
                    Phone = "065/123-4554",
                    PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                    Profession = "doctor",
                    ProfileImage = ".",
                    LicenseNumber = "001",
                    OnCall = true,
                    PatientReview = 4.5,
                    DepartmentId = 1,
                    ExaminationRoomId = 8,
                    OperationRoomId = 64,
                    SpecializationId = 1,
                    Role = Role.Doctor
                });
                context.Add(new Doctor
                {
                    Id = "2407978890043",
                    CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "ivan@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                    Name = "Mirjana",
                    Surname = "Lakic",
                    Username = "mima",
                    Password = "mima123",
                    Phone = "065/123-4554",
                    PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                    Profession = "doctor",
                    ProfileImage = ".",
                    LicenseNumber = "001",
                    OnCall = true,
                    PatientReview = 4.5,
                    DepartmentId = 1,
                    ExaminationRoomId = 122,
                    OperationRoomId = 15,
                    SpecializationId = 1,
                    Role = Role.Doctor
                });
                context.Add(new Doctor
                {
                    Id = "2407978890041",
                    CurrResidence = new Address("Jablanicka", 2, 2, 1, new City("Novi Sad", new State("Srbija"))),
                    DateOfBirth = new DateTime(1978, 6, 24),
                    DateOfCreation = new DateTime(),
                    EducationLevel = EducationLevel.bachelor,
                    Email = "ivan@gmail.com",
                    Gender = Gender.MALE,
                    InsurancePolicy = new InsurancePolicy("12345678", "Markovic", new Period(new DateTime(2020, 6, 29), new DateTime(2021, 2, 2))),
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "peca",
                    Password = "mima123",
                    Phone = "065/123-4554",
                    PlaceOfBirth = new City("Novi Sad", new State("Srbija")),
                    Profession = "doctor",
                    ProfileImage = ".",
                    LicenseNumber = "001",
                    OnCall = true,
                    PatientReview = 4.5,
                    DepartmentId = 1,
                    ExaminationRoomId = 4,
                    OperationRoomId = 18,
                    SpecializationId = 2,
                    Role = Role.Doctor
                });
               context.SaveChanges();
        }

        private void SeedDoctorsWorkDay(UserDbContext context)
        {
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 29), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 30), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 31), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 01), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 02), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });

            context.Add(new WorkDay { Date = new DateTime(2021, 02, 03), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 04), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 05), StartTime = 16, EndTime = 23, DoctorId = "2406978890047" });

            context.Add(new WorkDay { Date = new DateTime(2021, 01, 29), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 30), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 31), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 01), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 02), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 03), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 04), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });

            context.Add(new WorkDay { Date = new DateTime(2021, 02, 05), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 06), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 07), StartTime = 16, EndTime = 23, DoctorId = "2407978890045" });

            context.Add(new WorkDay { Date = new DateTime(2021, 01, 29), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 30), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 31), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 01), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 02), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });

            context.Add(new WorkDay { Date = new DateTime(2021, 02, 03), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 04), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 05), StartTime = 16, EndTime = 23, DoctorId = "2407978890043" });

            context.Add(new WorkDay { Date = new DateTime(2021, 01, 29), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 30), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 01, 31), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 01), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 02), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });

            context.Add(new WorkDay { Date = new DateTime(2021, 02, 03), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 04), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 05), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });
            context.Add(new WorkDay { Date = new DateTime(2021, 02, 06), StartTime = 16, EndTime = 23, DoctorId = "2407978890041" });

            context.SaveChanges();
        }


        public bool IsAlreadyFull(UserDbContext context)
        {
            return context.Specializations.Count() > 0;
        }
    }
}
