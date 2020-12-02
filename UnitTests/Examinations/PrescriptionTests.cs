using Backend.Examinations.Model;
using Backend.Examinations.WebApiController;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using Backend.Users.Repository;
using Model.Users;
using Backend.Examinations.Repository;
using Moq;
using Backend.Examinations.Model.Enums;
using Backend.Medications.Model;
using Backend.Examinations.WebApiService;
using WebApplication.DTO;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Model.Schedule;

namespace MedbayTechUnitTests.Examinations
{
    public class PrescriptionTests
    {
        [Fact]
        public void Advanced_presciption_not_found()
        {
            var stubRepository = CreateStubRepository();
            PrescriptionAdvancedDTO dto = CreateFalseDTO();
            PrescriptionSearchWebService service = new PrescriptionSearchWebService(stubRepository);

            List<Prescription> prescriptions = service.AdvancedSearchPrescriptions(dto);

            prescriptions.ShouldBeEmpty();
        }

        [Fact]
        public void Advanced_prescription_found()
        {
            var stubRepository = CreateStubRepository();
            PrescriptionAdvancedDTO dto = CreateDTO();
            PrescriptionSearchWebService service = new PrescriptionSearchWebService(stubRepository);

            List<Prescription> prescriptions = service.AdvancedSearchPrescriptions(dto);

            prescriptions.ShouldNotBeEmpty(); 
        }

        public static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();
            List<Prescription> prescriptions = CreatePrescriptionList();

            stubRepository.Setup(p => p.GetPrescriptionsFor("2406978890046")).Returns(prescriptions);

            return stubRepository.Object;
        }

        public static PrescriptionAdvancedDTO CreateDTO()
        {
            PrescriptionAdvancedDTO dto = new PrescriptionAdvancedDTO
            {
                FirstParameterType = "hourlyIntake",
                FirstParameterValue = "5",
                LogicOperators = new string[2],
                OtherParameterTypes = new string[2],
                OtherParameterValues = new string[2]
            };

            dto.LogicOperators[0] = "and";
            dto.LogicOperators[1] = "or";

            dto.OtherParameterValues[0] = "Brufen";
            dto.OtherParameterValues[1] = "6";

            dto.OtherParameterTypes[0] = "medication";
            dto.OtherParameterTypes[1] = "hourlyIntake";

            return dto;
        }

        public static PrescriptionAdvancedDTO CreateFalseDTO()
        {
            PrescriptionAdvancedDTO dto = new PrescriptionAdvancedDTO
            {
                FirstParameterType = "houlyIntake",
                FirstParameterValue = "5",
                LogicOperators = new string[2],
                OtherParameterTypes = new string[2],
                OtherParameterValues = new string[2]
            };

            dto.LogicOperators[0] = "and";
            dto.LogicOperators[1] = "or";

            dto.OtherParameterValues[0] = "Brufen";
            dto.OtherParameterValues[1] = "2";

            dto.OtherParameterTypes[0] = "medication";
            dto.OtherParameterTypes[1] = "hourlyIntake";

            return dto;
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
                ChosenDoctorId = "2406978890047"
            };

            return patient;
        }

        private static Medication CreateMedication()
        {
            var medication = new Medication
            {
                Id = 1,
                Med = "Brufen"

            };

            return medication;
        }

        private static MedicalRecord CreateMedicalRecord()
        {
            var medicalRecord = new MedicalRecord
            {
                Id = 1,
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergies = new List<Allergens>(),
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>(),
                Patient = CreatePatient()
            };

            return medicalRecord;
        }

        private static ExaminationSurgery CreateExaminationSurgery()
        {
            var examinationSurgery = new ExaminationSurgery
            {
                Id = 3,
                DoctorId = "2406978890047",
                StartTime = new DateTime(2015, 4, 23),
                MedicalRecordId = 1,
                Type = TypeOfAppointment.Examination,
                Diagnoses = new List<Diagnosis>(),
                Treatments = new List<Treatment>(),
                MedicalRecord = CreateMedicalRecord()
            };

            return examinationSurgery;
        }

        private static List<Prescription> CreatePrescriptionList()
        {
            var prescription = new Prescription
            {
                Id = 1,
                Reserved = true,
                HourlyIntake = 3,
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(),
                ExaminationSurgeryId = 3,
                Type = TreatmentType.Prescription,
                Medication = CreateMedication(),
                ExaminationSurgery = CreateExaminationSurgery()

            };

            var prescription2 = new Prescription
            {
                Id = 2,
                Reserved = false,
                HourlyIntake = 6,
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(),
                ExaminationSurgeryId = 3,
                Type = TreatmentType.Prescription,
                Medication = CreateMedication()
            };

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(prescription);
            prescriptions.Add(prescription2);

            return prescriptions;
        }
    }
}
