using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using MedbayTech.PatientDocuments.Domain.ValueObjects;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MedbayTech.UnitTesting.Records
{
    public class PatientDocumentsSearchTests
    {
        [Fact]
        public void Find_searched_prescription()
        {
            PrescriptionSearchService service = new PrescriptionSearchService(CreatePrescriptionStubRepository(), CreateUserGateway());
            List<Prescription> prescriptions = service.GetSearchedPrescription("Metafex", 6, new DateTime(2020, 11, 24), new DateTime(2020, 12, 1)).ToList();

            prescriptions.FirstOrDefault().ShouldNotBeNull();
        }

        [Fact]
        public void Dont_find_searched_prescription()
        {
            PrescriptionSearchService service = new PrescriptionSearchService(CreatePrescriptionStubRepository(), CreateUserGateway());
            List<Prescription> prescriptions = service.GetSearchedPrescription("Brufen", 6, new DateTime(2020, 11, 24), new DateTime(2020, 11, 25)).ToList();

            prescriptions.FirstOrDefault().ShouldBeNull();

        }

        [Fact]
        public void Find_searched_report()
        {
            ReportSearchService service = new ReportSearchService(CreateReportStubRepository(), CreateUserGateway());
            List<Report> reports = service.GetSearchedReports("Petar", new DateTime(2020, 11, 26), new DateTime(2020, 11, 30), "Examination").ToList();

            reports.FirstOrDefault().ShouldNotBeNull();

        }

        [Fact]
        public void Dont_find_searched_report()
        {
            ReportSearchService service = new ReportSearchService(CreateReportStubRepository(), CreateUserGateway());
            List<Report> reports = service.GetSearchedReports("Petar", new DateTime(2020, 11, 24), new DateTime(2020, 11, 25), "Examination").ToList();

            reports.FirstOrDefault().ShouldBeNull();
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


        private static IPrescriptionRepository CreatePrescriptionStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();
            var prescriptions = CreatePrescriptions();

            stubRepository.Setup(m => m.GetAll()).Returns(prescriptions);

            return stubRepository.Object;
        }

        private static List<Prescription> CreatePrescriptions()
        {
            var prescription = new Prescription
            {
                Id = 1,
                Reserved = true,
                HourlyIntake = 3,
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                Date = new DateTime(2020, 11, 30),
                ReportId = 3,
                Medication = "Brufen",
                Report = CreateReport()

            };

            var prescription2 = new Prescription
            {
                Id = 2,
                Reserved = false,
                Date = new DateTime(2020, 11, 30),
                HourlyIntake = 6,
                MedicationId = 1,
                AdditionalNotes = "svasta nesto",
                ReportId = 3,
                Medication = "Metafex",
                Report = CreateReport()
            };

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(prescription);
            prescriptions.Add(prescription2);
            return prescriptions;
        }
        private static Report CreateReport()
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
        private static IReportRepository CreateReportStubRepository()
        {
            var stubRepository = new Mock<IReportRepository>();
            var reports = CreateReports();

            stubRepository.Setup(m => m.GetAll()).Returns(reports);

            return stubRepository.Object;
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

        private static Doctor CreateDoctor()
        {
            var doctor = new Doctor
            {
                Id = "2406978890047",
                Name = "Petar",
                Surname = "Stevic"
            };

            return doctor;
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
        private static List<Report> CreateReports()
        {
            var doctor = CreateDoctor();
            var mr = CreateMedicalRecord();

            Report rep1 = new Report {
                StartTime = new DateTime(2020, 11, 27),
                Type = TypeOfAppointment.Examination,
                DoctorId = doctor.Id,
                Doctor = doctor,
                MedicalRecord = mr,
                MedicalRecordId = mr.Id
            };

            Report rep2 = new Report
            {
                StartTime = new DateTime(2020, 11, 29),
                Type = TypeOfAppointment.Surgery,
                DoctorId = doctor.Id,
                Doctor = doctor,
                MedicalRecord = mr,
                MedicalRecordId = mr.Id
            };

            List<Report> reports = new List<Report>();
            reports.Add(rep1);
            reports.Add(rep2);

            return reports;
        }
    }
}
