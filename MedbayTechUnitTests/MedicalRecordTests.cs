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
using Service.MedicalRecordService;

namespace MedbayTechUnitTests
{
    
    public class MedicalRecordTests
    {
        [Fact]
        public void Get_medical_record_by_patient()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();

            Patient patient = CreatePatient();
            MedicalRecord mr = new MedicalRecord(BloodType.AbNeg, patient, PatientCondition.HospitalTreatment);

            stubRepository.Setup(m => m.GetRecordBy(patient)).Returns(mr);

            MedicalRecordService medicalRecordService = new MedicalRecordService(stubRepository.Object);

            MedicalRecord medicalRecord = medicalRecordService.GetRecordBy(patient);

            medicalRecord.ShouldNotBeNull();
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
