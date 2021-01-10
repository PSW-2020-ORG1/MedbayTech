using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.Users.Infrastructure.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using Moq;

namespace MedbayTech.UnitTesting.Users
{
    public class GettingBlockablePatientsTests
    {
        [Fact]
        public void Get_all_blockable_patients()
        {
            var patientStubRepository = CreatePatientListStubRepository();
            PatientService service = new PatientService(patientStubRepository, CreateAppointmentStubRepositoryForGettingBlockablePatients());

            List<Patient> patients = service.GetPatientsThatShouldBeBlocked();

            patients.ShouldNotBeEmpty();
        }

        [Fact]
        public void Dont_get_all_blockable_patients()
        {
            var patientStubRepository = CreatePatientListStubRepository();
            PatientService service = new PatientService(patientStubRepository, CreateAppointmentStubRepositoryForNotGettingBlockablePatients());

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

        public static IAppointmentGateway CreateAppointmentStubRepositoryForNotGettingBlockablePatients()
        {
            var stubRepository = new Mock<IAppointmentGateway>();
            List<MedbayTech.Users.Domain.Entites.Appointment> appointments = CreateAppointments();
            Patient patient = CreatePatient();

            stubRepository.Setup(p => p.GetAll()).Returns(appointments);

            return stubRepository.Object;
        }

        public static IAppointmentGateway CreateAppointmentStubRepositoryForGettingBlockablePatients()
        {
            var stubRepository = new Mock<IAppointmentGateway>();
            List<MedbayTech.Users.Domain.Entites.Appointment> badAppointments = CreateAppointmentsForBlockablePatients();
            Patient patient = CreatePatient();

            stubRepository.Setup(p => p.GetAll()).Returns(badAppointments);

            return stubRepository.Object;
        }

        private static List<MedbayTech.Users.Domain.Entites.Appointment> CreateAppointments()
        {
            var appointment = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 5),
                PatientId = "2406978890046"
            };

            var appointment2 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 3, 5),
                PatientId = "2406978890046"
            };

            var appointment3 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 8, 5),
                PatientId = "2406978890046"
            };

            var appointment4 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 8, 4),
                PatientId = "2406978890046"
            };

            List<MedbayTech.Users.Domain.Entites.Appointment> appointments = new List<MedbayTech.Users.Domain.Entites.Appointment>();

            appointments.Add(appointment);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);

            return appointments;
        }

        private static List<MedbayTech.Users.Domain.Entites.Appointment> CreateAppointmentsForBlockablePatients()
        {
            var appointment = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 19),
                PatientId = "2406978890046"
            };

            var appointment2 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 20),
                PatientId = "2406978890046"
            };

            var appointment3 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 21),
                PatientId = "2406978890046"
            };

            var appointment4 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 22),
                PatientId = "2406978890046"
            };

            List<MedbayTech.Users.Domain.Entites.Appointment> appointments = new List<MedbayTech.Users.Domain.Entites.Appointment>();

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
                DateOfBirth = new DateTime(1978, 6, 24),
                Name = "Petar",
                Surname = "Petrovic",
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
                Name = "Petar",
                Surname = "Petrovic",
                Blocked = false,
                ShouldBeBlocked = true
            };

            List<Patient> patients = new List<Patient>();
            patients.Add(patient);

            return patients;
        }
    }
}
