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

namespace MedbayTechUnitTests
{
    
    public class MedicalRecordTests
    {
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
            MedicalRecord medicalRecord = service.GetMedicalRecordByPatientId("002");

            medicalRecord.ShouldBeNull();
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();
            var patient = CreatePatient();

            MedicalRecord mr = new MedicalRecord(BloodType.AbPlus, patient, PatientCondition.HospitalTreatment);

            stubRepository.Setup(m => m.GetMedicalRecordByPatientId(patient.Id)).Returns(mr);

            return stubRepository.Object;
        }

        private static Patient CreatePatient()
        {
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy("001", "Dunav Osiguranje", new Backend.Utils.Period(new DateTime(2015, 1, 1), new DateTime(2025, 1, 1)));

            Patient patient = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "001", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");
            
            return patient;
        }

    }
}
