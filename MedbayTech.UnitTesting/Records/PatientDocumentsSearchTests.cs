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
            PrescriptionSearchService service = new PrescriptionSearchService(CreatePrescriptionStubRepository());
            List<Prescription> prescriptions = service.GetSearchedPrescription("Metafex", 6, new DateTime(2020, 11, 24), new DateTime(2020, 12, 1)).ToList();

            prescriptions.FirstOrDefault().ShouldNotBeNull();
        }

        [Fact]
        public void Dont_find_searched_prescription()
        {
            PrescriptionSearchService service = new PrescriptionSearchService(CreatePrescriptionStubRepository());
            List<Prescription> prescriptions = service.GetSearchedPrescription("Brufen", 6, new DateTime(2020, 11, 24), new DateTime(2020, 11, 25)).ToList();

            prescriptions.FirstOrDefault().ShouldBeNull();

        }

        [Fact]
        public void Find_searched_report()
        {
            ReportSearchService service = new ReportSearchService(CreateReportStubRepository());
            List<Report> reports = service.GetSearchedReports("Petar", new DateTime(2020, 11, 26), new DateTime(2020, 11, 30), "Examination").ToList();

            reports.FirstOrDefault().ShouldNotBeNull();

        }

        [Fact]
        public void Dont_find_searched_report()
        {
            ReportSearchService service = new ReportSearchService(CreateReportStubRepository());
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
            Prescription p1 = new Prescription(new DateTime(2020, 11, 30), true, "Brufen", 6, "");

            Prescription p2 = new Prescription(new DateTime(2020, 11, 30), true, "Metafex", 6, "");

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(p1);
            prescriptions.Add(p2);

            return prescriptions;
        }

        private static IReportRepository CreateReportStubRepository()
        {
            var stubRepository = new Mock<IReportRepository>();
            var reports = CreateReports();

            stubRepository.Setup(m => m.GetAll()).Returns(reports);

            return stubRepository.Object;
        }
        Patient(string id, string name, string surname, InsurancePolicy insurancePolicy,
           string gender, string email, DateTime dateOfBirth, string phoneNumber,
           string bloodType, Address currResidence, string profileImage, string phone)
        private static List<Report> CreateReports()
        {
            City city = new City("Novi Sad", new State("Srbija"));
            Address address = new Address("Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy("001", "Dunav Osiguranje", new Period(new DateTime(2015, 1, 1), new DateTime(2025, 1, 1)));

            Doctor doctor = new Doctor("12345678", "Petar", "Petrovic");
            Patient patient = new Patient("2406978890046", "Marko", "Markovic", insurancePolicy, "Male", "marko@gmail.com", new DateTime(1975, 6, 9), "0123456", "ANeg", address, ".", "");
            MedicalRecord mr = new MedicalRecord(BloodType.AbPlus, patient, PatientCondition.HospitalTreatment);

            Report rep1 = new Report(new DateTime(2020, 11, 27), TypeOfAppointment.Examination, doctor.Id, mr.Id);
            Report rep2 = new Report(new DateTime(2020, 11, 29), TypeOfAppointment.Surgery, doctor.Id, mr.Id);

            List<Report> reports = new List<Report>();
            reports.Add(rep1);
            reports.Add(rep2);

            return reports;
        }
    }
}
