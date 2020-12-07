using Backend.Users.Repository;
using Backend.Users.Service;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Users
{
    public class PatientBlockingTests
    {

        [Fact]
        public void Block_patient_by_id()
        {
            var stubRepository = CreateStubRepository();
            PatientService service = new PatientService(stubRepository);

            bool patient = service.UpdateStatus("2406978890046");

            patient.ShouldBeTrue();
        }

        [Fact]
        public void Dont_block_patient_by_id()
        {
            var stubRepository = CreateStubRepository();
            PatientService service = new PatientService(stubRepository);

            bool patient = service.UpdateStatus("2406978890047");

            patient.ShouldBeFalse();
        }

        public static IPatientRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            bool patient = CreatePatient().Blocked;

            stubRepository.Setup(p => p.UpdateStatus("2406978890046")).Returns(patient);

            return stubRepository.Object;
        }

        private static Patient CreatePatient()
        {
            var patient = new Patient
            {
                Id = "2406978890046",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Petar",
                Surname = "Petrovic",
                Username = "pera",
                Password = "pera1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = ".",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = true
            };

            return patient;
        }
    }
}
