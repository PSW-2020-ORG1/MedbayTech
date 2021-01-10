using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Infrastructure.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using MedbayTech.Users.Domain.Entites;
using Xunit;
using MedbayTech.Users.Domain.Entites.Enums;

namespace MedbayTech.UnitTesting.Users
{
    public class RegistrationTests
    {
        [Fact]
        public void Exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            RegistrationService service = new RegistrationService(stubRepository);

            bool existsById = service.ExistsById("2406978890044");

            existsById.ShouldBe(true);
        }
        public static IPatientRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            var patients = CreateListOfPatients();
            var patient = CreatePatient();
            stubRepository.Setup(p => p.GetAll()).Returns(patients);
            stubRepository.Setup(m => m.ExistsBy(It.IsAny<string>()))
                .Returns((string id) => patients.Exists(p => p.Id.Equals(id)));
            stubRepository.Setup(p => p.Create(It.IsAny<Patient>())).Returns(It.IsAny<Patient>());

            return stubRepository.Object;
        }
        public static Patient CreatePatient()
        {
            Patient patient = new Patient
            {
                Id = "2406978891024",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = ".",
                ChosenDoctor = null,
                IsGuestAccount = false,
            };

            return patient;
        }
        private static List<Patient> CreateListOfPatients()
        {
            List<Patient> patients = new List<Patient>();

            Patient patient2 = new Patient
            {
                Id = "2406978890044",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = ".",
                ChosenDoctor = null,
                IsGuestAccount = false,
            };

            patients.Add(patient2);

            Patient patient1 = new Patient
            {
                Id = "2406978890048",
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = ".",
                ChosenDoctor = null,
                IsGuestAccount = false,

            };

            patients.Add(patient1);

            return patients;
        }
    }
}
