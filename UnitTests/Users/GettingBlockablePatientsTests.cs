using Backend.Users.Repository;
using Backend.Users.Service;
using Model.Schedule;
using Model.Users;
using Moq;
using Repository.ScheduleRepository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Users
{
    public class GettingBlockablePatientsTests
    {
        [Fact]
        public void Get_all_blockable_patients()
        {
            var patientStubRepository = CreatePatientListStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepositoryForGettingBlockablePatients();
            PatientService service = new PatientService(patientStubRepository, appointmentStubRepository);

            List<Patient> patients = service.GetPatientsThatShouldBeBlocked();

            patients.ShouldNotBeEmpty();
        }

        [Fact]
        public void Dont_get_all_blockable_patients()
        {
            var patientStubRepository = CreatePatientListStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepositoryForNotGettingBlockablePatients();
            PatientService service = new PatientService(patientStubRepository, appointmentStubRepository);

            List<Patient> patients = service.GetPatientsThatShouldBeBlocked();

            patients.ShouldBeEmpty();
        }

        public static IPatientRepository CreatePatientListStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            List<Patient> patients = CreatePatientList();

            stubRepository.Setup(p => p.GetAll()).Returns(patients);

            return stubRepository.Object;
        }

        public static IAppointmentRepository CreateAppointmentStubRepositoryForNotGettingBlockablePatients()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = CreateAppointments();

            stubRepository.Setup(p => p.GetCanceledAppointments()).Returns(appointments);

            return stubRepository.Object;
        }

        public static IAppointmentRepository CreateAppointmentStubRepositoryForGettingBlockablePatients()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            List<Appointment> badAppointments = CreateAppointmentsForBlockablePatients();

            stubRepository.Setup(p => p.GetCanceledAppointments()).Returns(badAppointments);

            return stubRepository.Object;
        }

        private static List<Appointment> CreateAppointments()
        {
            var appointment = new Appointment
            {
                Id = 1,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 5),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment2 = new Appointment
            {
                Id = 2,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 3, 5),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment3 = new Appointment
            {
                Id = 3,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 8, 5),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment4 = new Appointment
            {
                Id = 4,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 8, 4),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            List<Appointment> appointments = new List<Appointment>();

            appointments.Add(appointment);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);

            return appointments;
        }

        private static List<Appointment> CreateAppointmentsForBlockablePatients()
        {
            var appointment = new Appointment
            {
                Id = 1,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 5),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment2 = new Appointment
            {
                Id = 2,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment3 = new Appointment
            {
                Id = 3,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            var appointment4 = new Appointment
            {
                Id = 4,
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 7, 1),
                Patient = CreatePatient(),
                PatientId = "2406978890046"
            };

            List<Appointment> appointments = new List<Appointment>();

            appointments.Add(appointment);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);

            return appointments;
        }

        private static Patient CreatePatient()
        {
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
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            };

            return patient;
        }

        private static List<Patient> CreatePatientList()
        {
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
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            };

            List<Patient> patients = new List<Patient>();
            patients.Add(patient);

            return patients;
        }
    }
}
