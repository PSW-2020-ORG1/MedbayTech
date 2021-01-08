using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Backend.Examinations.Model.Enums;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.PatientDocuments.Application.DTO.Prescription;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;
using MedbayTech.Common.Domain.Entities.Generalities;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations.Enums;

namespace MedbayTechUnitTests.Examinations
{
    public class PrescriptionTests
    {
        [Fact]
        public void Advanced_presciption_not_found()
        {
            var stubRepository = CreateStubRepository();
            PrescriptionAdvancedDTO dto = CreateFalseDTO();
            PrescriptionSearchService service = new PrescriptionSearchService(stubRepository);

            List<Prescription> prescriptions = service.AdvancedSearchPrescriptions(dto);

            prescriptions.ShouldBeEmpty();
        }

        [Fact]
        public void Advanced_prescription_found()
        {
            var stubRepository = CreateStubRepository();
            PrescriptionAdvancedDTO dto = CreateDTO();
            PrescriptionSearchService service = new PrescriptionSearchService(stubRepository);

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
                DateOfBirth = new DateTime(1978, 6, 24),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Phone = "065/123-4554",
                ProfileImage = ".",
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
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>(),
                Patient = CreatePatient()
            };

            return medicalRecord;
        }

        private static Report CreateExaminationSurgery()
        {
            var examinationSurgery = new Report
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
                ReportId = 3,
                Type = TreatmentType.Prescription,
                Medication = "Brufen",
                Report = CreateExaminationSurgery()

            };

            var prescription2 = new Prescription
            {
                Id = 2,
                Reserved = false,
                HourlyIntake = 6,
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(),
                ReportId = 3,
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
