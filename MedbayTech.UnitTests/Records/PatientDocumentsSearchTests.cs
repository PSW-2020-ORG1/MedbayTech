using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using Backend.Medications.Model;
using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Model.Schedule;
using Model.Rooms;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Backend.Examinations.WebApiService;
using System.Linq;

namespace MedbayTechUnitTests
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
            List<ExaminationSurgery> reports = service.GetSearchedReports("Petar", new DateTime(2020, 11, 26), new DateTime(2020, 11, 30), "Examination").ToList();

            reports.FirstOrDefault().ShouldNotBeNull();

        }

        [Fact]
        public void Dont_find_searched_report()
        {
            ReportSearchService service = new ReportSearchService(CreateReportStubRepository());
            List<ExaminationSurgery> reports = service.GetSearchedReports("Petar", new DateTime(2020, 11, 24), new DateTime(2020, 11, 25), "Examination").ToList();

            reports.FirstOrDefault().ShouldBeNull();
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
            Prescription p1 = new Prescription(new DateTime(2020, 11, 30), true, 6, "", new Medication("Brufen", "Galenika", 
                new MedicationCategory("Kategorija1", new Specialization(1, "specijalizacija1"))));

            Prescription p2 = new Prescription(new DateTime(2020, 11, 30), true, 6, "", new Medication("Metafex", "Galenika",
                new MedicationCategory("Kategorija1", new Specialization(1, "specijalizacija1"))));

            List <Prescription> prescriptions= new List<Prescription>();
            prescriptions.Add(p1);
            prescriptions.Add(p2);

            return prescriptions;
        }

        private static IExaminationSurgeryRepository CreateReportStubRepository()
        {
            var stubRepository = new Mock<IExaminationSurgeryRepository>();
            var reports = CreateReports();

            stubRepository.Setup(m => m.GetAll()).Returns(reports);

            return stubRepository.Object;
        }

        private static List<ExaminationSurgery> CreateReports()
        {
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy("001", "Dunav Osiguranje", new DateTime(2015, 1, 1), new DateTime(2025, 1, 1));
            Department department = new Department(1, "dep1", 2, new Hospital(1, ".", "Bolnica", address));
            Room room = new Room(1, 1, RoomType.ExaminationRoom, department);
            Doctor doctor = new Doctor("Petar", "Petrovic", new DateTime(1980, 1, 1), "001", "pera@gmail.com", "pera", "01234", "sifra", EducationLevel.bachelor, Gender.MALE,
                "lekar", city, address, insurancePolicy, ".", department, "001", room, room, ".");
            Patient patient = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "2406978890046", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");
            MedicalRecord mr = new MedicalRecord(BloodType.AbPlus, patient, PatientCondition.HospitalTreatment);

            ExaminationSurgery rep1 = new ExaminationSurgery(new DateTime(2020, 11, 27), TypeOfAppointment.Examination, doctor, mr);
            ExaminationSurgery rep2 = new ExaminationSurgery(new DateTime(2020, 11, 29), TypeOfAppointment.Surgery, doctor, mr);

            List<ExaminationSurgery> reports = new List<ExaminationSurgery>();
            reports.Add(rep1);
            reports.Add(rep2);

            return reports;
        }
    }
}
