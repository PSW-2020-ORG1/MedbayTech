using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using Moq;
using Repository.MedicalRecordRepository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MedbayTech.UnitTesting.Records
{
    public class MedicalRecordTests
    {
        [Fact]
        public void Find_patients_medical_record()
        {
            MedicalRecordService service = new MedicalRecordService(CreateStubRepository(), CreateUserGateway());
            MedicalRecord medicalRecord = service.GetMedicalRecordByPatient("001");

            medicalRecord.ShouldNotBeNull();
        }

        [Fact]
        public void Doesnt_find_patients_record()
        {
            MedicalRecordService service = new MedicalRecordService(CreateStubRepository(), CreateUserGateway());
            MedicalRecord medicalRecord = service.GetMedicalRecordByPatient("003");

            medicalRecord.ShouldBeNull();
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();
            var patients = CreatePatients();

            var medicalRecord = new MedicalRecord
            {
                Id = 1,
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>(),
                Patient = patients[0]
            };
            var medicalRecord2 = new MedicalRecord
            {
                Id = 1,
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>(),
                Patient = patients[1]
            };

            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            medicalRecords.Add(medicalRecord);
            medicalRecords.Add(medicalRecord2);

            stubRepository.Setup(m => m.GetAll()).Returns(medicalRecords);
            stubRepository.Setup(m => m.GetRecordBy(It.IsAny<string>()))
                .Returns((string id) => medicalRecords.FirstOrDefault(entity => entity.Patient.Id.Equals(id)));

            return stubRepository.Object;
        }
        private static IUserGateway CreateUserGateway()
        {
            var userGateway = new Mock<IUserGateway>();
            List<Doctor> doctors = CreateDoctors();
            userGateway.Setup(u => u.GetDoctorBy(It.IsAny<string>())).Returns((string id) => doctors.FirstOrDefault(x => x.Id.Equals(id)));
            List<Patient> patients = CreatePatients();
            userGateway.Setup(u => u.GetPatientBy(It.IsAny<string>())).Returns((string id) => patients.FirstOrDefault(x => x.Id.Equals(id)));
            return userGateway.Object;

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

        private static List<Doctor> CreateDoctors()
        {
            var doctor = new Doctor
            {
                Id = "2406978890047",
                Name = "Petar",
                Surname = "Stevic"
            };
            List<Doctor> doctors = new List<Doctor>();
            return doctors;
        }
        private static List<Patient> CreatePatients()
        {
            var patient = new Patient
            {
                Id = "001",
                DateOfBirth = new DateTime(1978, 6, 24),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Phone = "065/123-4554",
                ProfileImage = ".",
            };
            var patient2 = new Patient
            {
                Id = "002",
                DateOfBirth = new DateTime(1978, 6, 24),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Phone = "065/123-4554",
                ProfileImage = ".",
            };

            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            patients.Add(patient2);

            return patients;
        }

    }
}
