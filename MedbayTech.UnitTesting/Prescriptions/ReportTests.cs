using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MedbayTech.UnitTesting.Prescriptions
{
    public class ReportTests
    {
        [Fact]
        public void Advanced_report_not_found()
        {
            var stubRepository = CreateStubRepository();
            ReportAdvancedDTO dto = CreateFalseDTO();

            ReportSearchService service = new ReportSearchService(stubRepository, CreateUserGateway());

            List<Report> reports = service.AdvancedSearchReports(dto);

            reports.ShouldBeEmpty();
        }

        [Fact]
        public void Advanced_report_found()
        {
            var stubRepository = CreateStubRepository();
            ReportAdvancedDTO dto = CreateDTO();
            ReportSearchService service = new ReportSearchService(stubRepository, CreateUserGateway());

            List<Report> reports = service.AdvancedSearchReports(dto);

            reports.ShouldNotBeEmpty();
        }
        [Fact]
        public void Get_report_for_appointment()
        {
            var stubRepository = CreateStubRepository();
            var userGateway = CreateUserGateway();
            ReportSearchService service = new ReportSearchService(stubRepository, userGateway);
            Report report = service.GetReportForAppointment(new DateTime(2020, 12, 3), "2406978890047", "2406978890046");

            report.ShouldNotBeNull();
        }
        [Fact]
        public void Doesnt_get_report_for_appointment()
        {
            var stubRepository = CreateStubRepository();
            var userGateway = CreateUserGateway();
            ReportSearchService service = new ReportSearchService(stubRepository, userGateway);
            Report report = service.GetReportForAppointment(new DateTime(2020, 12, 3), "2406978890547", "2406978890046");

            report.ShouldBeNull();
        }

        public static IUserGateway CreateUserGateway()
        {
            var userGateway = new Mock<IUserGateway>();
            List<Doctor> doctors = CreateDoctorsList();
            userGateway.Setup(u => u.GetDoctorBy(It.IsAny<string>())).Returns((string id) => doctors.FirstOrDefault(x => x.Id.Equals(id)));
            List<Patient> patients = CreatePatientList();
            userGateway.Setup(u => u.GetPatientBy(It.IsAny<string>())).Returns((string id) => patients.FirstOrDefault(x => x.Id.Equals(id)));
            return userGateway.Object;
        }

        private static List<Doctor> CreateDoctorsList()
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(CreateDoctor());
            return doctors;
        }

        private static List<Patient> CreatePatientList()
        {
            List<Patient> patients = new List<Patient>();
            patients.Add(CreatePatient());
            return patients;
        }

        public static IReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IReportRepository>();
            List<Report> reports = CreateExaminationSurgeryList();

            stubRepository.Setup(r => r.GetReportFor("2406978890046")).Returns(reports);
            stubRepository.Setup(r => r.GetReportForAppointment(It.IsAny<DateTime>(), It.IsAny<String>(), It.IsAny<String>())).Returns(
                (DateTime start, string doctorId, string patientId) =>
                    reports.FirstOrDefault(x => x.StartTime.Equals(start) && x.DoctorId.Equals(doctorId) && x.MedicalRecord.PatientId.Equals(patientId)));
            return stubRepository.Object;
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

            dto.OtherParameterValues[0] = "12/3/2020";
            dto.OtherParameterValues[1] = "Stevic";

            dto.OtherParameterTypes[0] = "date";
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

            dto.OtherParameterValues[0] = "12/3/2020";
            dto.OtherParameterValues[1] = "Simic";

            dto.OtherParameterTypes[0] = "date";
            dto.OtherParameterTypes[1] = "docSurname";

            return dto;
        }

        private static Doctor CreateDoctor()
        {
            var doctor = new Doctor
            {
                Id = "2406978890047",
                Name = "Jovan",
                Surname = "Stevic"
            };

            return doctor;
        }

        private static Patient CreatePatient()
        {
            var patient = new Patient
            {
                Id = "2406978890046",
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Phone = "065/123-4554",
                ProfileImage = "."
            };

            return patient;
        }

        private static MedicalRecord CreateMedicalRecord()
        {
            var medicalRecord = new MedicalRecord
            {
                Id = 1,
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>(),
                Patient = CreatePatient()
            };

            return medicalRecord;
        }

        private static List<Report> CreateExaminationSurgeryList()
        {
            var examinationSurgery = new Report
            {
                Id = 3,
                DoctorId = "2406978890047",
                StartTime = new DateTime(2020, 12, 3),
                MedicalRecordId = 1,
                Diagnoses = new List<Diagnosis>(),
                Treatments = new List<Treatment>(),
                MedicalRecord = CreateMedicalRecord(),
                Doctor = CreateDoctor()

            };

            var examinationSurgery2 = new Report
            {
                Id = 4,
                DoctorId = "2406978890047",
                StartTime = new DateTime(2015, 4, 23),
                MedicalRecordId = 1,
                Diagnoses = new List<Diagnosis>(),
                Treatments = new List<Treatment>(),
                MedicalRecord = CreateMedicalRecord(),
                Doctor = CreateDoctor()
            };

            List<Report> reports = new List<Report>();
            reports.Add(examinationSurgery);
            reports.Add(examinationSurgery2);

            return reports;
        }
    }
}
