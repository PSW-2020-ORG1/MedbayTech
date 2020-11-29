﻿using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using Backend.Examinations.WebApiService;
using Backend.Medications.Model;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Model.Schedule;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DTO;
using Xunit;
using ZdravoKorporacija.Model.Users;

namespace MedbayTechUnitTests.Examinations
{
    public class ReportTests
    {
        [Fact]
        public void Advanced_report_not_found()
        {
            var stubRepository = CreateStubRepository();
            ReportAdvancedDTO dto = CreateFalseDTO();
            ReportWebService service = new ReportWebService(stubRepository);

            List<ExaminationSurgery> reports = service.AdvancedSearchReports(dto);

            reports.ShouldBeEmpty();
        }

        [Fact]
        public void Advanced_prescription_found()
        {
            var stubRepository = CreateStubRepository();
            ReportAdvancedDTO dto = CreateDTO();
            ReportWebService service = new ReportWebService(stubRepository);

            List<ExaminationSurgery> reports = service.AdvancedSearchReports(dto);

            reports.ShouldNotBeEmpty();


        }

        public static ReportAdvancedDTO CreateDTO()
        {
            ReportAdvancedDTO dto = new ReportAdvancedDTO
            {
                FirstParameterType = "docName",
                FirstParameterValue = "Jovan",
                LogicOperators = new string[2],
                OtherParameterTypes = new string[2],
                OtherParameterValues = new string[2]
            };

            dto.LogicOperators[0] = "and";
            dto.LogicOperators[1] = "or";

            dto.OtherParameterValues[0] = "dobar je";
            dto.OtherParameterValues[1] = "Stevic";

            dto.OtherParameterTypes[0] = "diagnosis";
            dto.OtherParameterTypes[1] = "docSurname";

            return dto;
        }

        public static ReportAdvancedDTO CreateFalseDTO()
        {
            ReportAdvancedDTO dto = new ReportAdvancedDTO
            {
                FirstParameterType = "docName",
                FirstParameterValue = "Milan",
                LogicOperators = new string[2],
                OtherParameterTypes = new string[2],
                OtherParameterValues = new string[2]
            };

            dto.LogicOperators[0] = "and";
            dto.LogicOperators[1] = "or";

            dto.OtherParameterValues[0] = "U teskom stanju";
            dto.OtherParameterValues[1] = "Simic";

            dto.OtherParameterTypes[0] = "diagnosis";
            dto.OtherParameterTypes[1] = "docSurname";

            return dto;
        }

        public static IExaminationSurgeryRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IExaminationSurgeryRepository>();
            var medication = new Medication
            {
                Id = 1,
                Med = "Brufen"

            };

            var doctor = new Doctor
            {
                Id = "2406978890047",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "mika@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Jovan",
                Surname = "Jovic",
                Username = "mika",
                Password = "mika1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 1,
                OperationRoomId = 2,
                Specializations = new List<Specialization>()
            };

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
                Patient = patient
            };

            var examinationSurgery = new ExaminationSurgery
            {
                Id = 3,
                DoctorId = "2406978890047",
                StartTime = new DateTime(2015, 4, 23),
                MedicalRecordId = 1,
                Type = TypeOfAppointment.Examination,
                Diagnoses = new List<Diagnosis>(),
                Treatments = new List<Treatment>(),
                MedicalRecord = medicalRecord,
                Doctor = doctor
                
            };

            var examinationSurgery2 = new ExaminationSurgery
            {
                Id = 4,
                DoctorId = "2406978890047",
                StartTime = new DateTime(2015, 4, 23),
                MedicalRecordId = 1,
                Type = TypeOfAppointment.Examination,
                Diagnoses = new List<Diagnosis>(),
                Treatments = new List<Treatment>(),
                MedicalRecord = medicalRecord,
                Doctor = doctor
            };







            List<ExaminationSurgery> reports = new List<ExaminationSurgery>();
            reports.Add(examinationSurgery);
            reports.Add(examinationSurgery2);

            stubRepository.Setup(r => r.GetReportFor("2406978890046")).Returns(reports);



            return stubRepository.Object;
        }
    }
}
