
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using Shouldly;
using MedbayTech.Users.Infrastructure.Service;
using MedbayTech.Users.Infrastructure.Persistance;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.ValueObjects;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Common.Domain.ValueObjects;

namespace MedbayTech.UnitTesting.Users
{
    public class LoginTests
    {
        [Fact]
        public void Patient_login_success()
        {
            var patientStubRepository = CreatePatientStubRepository();
            AuthenticationService service = new AuthenticationService(patientStubRepository);

            AuthenticatedUserDTO user = service.Authenticate("pera", "pera1978");

            user.ShouldNotBeNull();
        }

        [Fact]
        public void Patient_login_fail()
        {
            var patientStubRepository = CreatePatientStubRepository();
            AuthenticationService service = new AuthenticationService(patientStubRepository);

            AuthenticatedUserDTO user = service.Authenticate("markic", "marko1978");

            user.ShouldBeNull();
        }

        [Fact]
        public void Admin_login_success()
        {
            var adminStubRepository = CreateAdminStubRepository();
            AuthenticationService service = new AuthenticationService(adminStubRepository);

            AuthenticatedUserDTO user = service.Authenticate("markic", "marko1978");

            user.ShouldNotBeNull();
        }

        [Fact]
        public void Admin_login_fail()
        {
            var adminStubRepository = CreateAdminStubRepository();
            AuthenticationService service = new AuthenticationService(adminStubRepository);

            AuthenticatedUserDTO user = service.Authenticate("pera", "pera1978");

            user.ShouldBeNull();
        }

        public static IUserRepository CreatePatientStubRepository()
        {
            var stubRepository = new Mock<IUserRepository>();
            Patient patient = CreatePatient();

            stubRepository.Setup(p => p.GetBy("pera", "pera1978")).Returns(patient);

            return stubRepository.Object;
        }

        public static IUserRepository CreateAdminStubRepository()
        {
            var stubRepository = new Mock<IUserRepository>();
            RegisteredUser patient = CreateAdmin();

            stubRepository.Setup(p => p.GetBy("markic", "marko1978")).Returns(patient);

            return stubRepository.Object;
        }

        private static Patient CreatePatient()
        {
            var patient = new Patient
            {
                Id = "2406978890046",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Username = "pera",
                Password = "pera1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = ".",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true,
                Role = Role.Patient
            };

            return patient;
        }

        private static RegisteredUser CreateAdmin()
        {
            var admin = new RegisteredUser
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
            };

            return admin;

        }
    }
}
