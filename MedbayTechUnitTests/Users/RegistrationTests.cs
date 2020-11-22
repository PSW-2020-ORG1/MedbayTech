using Backend.Users.Repository;
using Backend.Users.WebApiController;
using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZdravoKorporacija.Model.Users;

namespace MedbayTechUnitTests.Users
{
    public class RegistrationTests
    {

        [Fact]
        public void Register_patient()
        {
            WebRegistrationController controller = new WebRegistrationController();
            var patient = CreatePatient();
            Patient registeredPatient = controller.Register(patient);
            registeredPatient.ShouldNotBeNull();
        }

        public static Patient CreatePatient()
        {
            Patient patient = new Patient
            {
                Id = "2406978890099",
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
                Id = "2406978890049",
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
                ProfileImage = ".",
                ChosenDoctor = null,
                IsGuestAccount = false,
            };

            patients.Add(patient2);

            Patient patient1 =  new Patient
            {
                Id = "2406978890048",
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
                ProfileImage = ".",
                ChosenDoctor = null,
                IsGuestAccount = false,

            };

            patients.Add(patient1);

            return patients;
        }
    }
}
