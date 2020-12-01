using Backend.Records.Model;
using Moq;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Model.Users;
using Backend.Records.Model.Enums;
using Backend.Records.WebApiService;
using System.Linq;
using Backend.Records.WebApiController;

namespace MedbayTechUnitTests
{
    
    public class MedicalRecordTestIntegration
    {
        [Fact]
        public void Find_patients_medical_record_Integration()
        {
            MedicalRecordWebController controller = new MedicalRecordWebController();
            var patient = CreatePatient();

            MedicalRecord medicalRecord = controller.GetMedicalRecordByPatientId(patient.Id);

            medicalRecord.ShouldNotBeNull();
        } 

        [Fact]
        public void Find_patients_medical_record()
        {
            MedicalRecordWebService service = new MedicalRecordWebService(CreateStubRepository());
            MedicalRecord medicalRecord = service.GetMedicalRecordByPatientId("001");

            medicalRecord.ShouldNotBeNull();
        }

        [Fact]
        public void Doesnt_find_patients_record()
        {
            MedicalRecordWebService service = new MedicalRecordWebService(CreateStubRepository());
            MedicalRecord medicalRecord = service.GetMedicalRecordByPatientId("003");

            medicalRecord.ShouldBeNull();
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();
            var patients = CreatePatients();

            MedicalRecord medicalRecord = new MedicalRecord(BloodType.AbPlus, patients[0], PatientCondition.HospitalTreatment);
            MedicalRecord medicalRecord2 = new MedicalRecord(BloodType.AbNeg, patients[1], PatientCondition.HomeTreatment);

            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            medicalRecords.Add(medicalRecord);
            medicalRecords.Add(medicalRecord2);

            stubRepository.Setup(m => m.GetAll()).Returns(medicalRecords);
            stubRepository.Setup(m => m.GetMedicalRecordByPatientId(It.IsAny<string>()))
                .Returns((string id) => medicalRecords.FirstOrDefault(entity => entity.Patient.Id.Equals(id)));

            return stubRepository.Object;
        }

        private static Patient CreatePatient()
        {
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy{Id = "001", Company = "Dunav Osiguranje",  StartTime = new DateTime(2015, 1, 1), EndTime = new DateTime(2025, 1, 1)};

            Patient patient = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "2406978890046", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");

            return patient;
        }

        private static List<Patient> CreatePatients()
        {
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy { Id = "001", Company = "Company1", EndTime = new DateTime(), StartTime = new DateTime() };

            Patient patient = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "001", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");

            Patient patient2 = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "002", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");

            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            patients.Add(patient2);

            return patients;
        }

    }
}
