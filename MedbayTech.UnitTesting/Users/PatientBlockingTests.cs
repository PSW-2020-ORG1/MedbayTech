using MedbayTech.Users.Infrastructure.Service;
using MedbayTech.Users.Domain.Entites;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using Moq;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;

namespace MedbayTech.UnitTesting.Users
{
    public class PatientBlockingTests
    {
        [Fact]
        public void Block_patient_by_id()
        {
            var patientStubRepository = CreatePatientStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepositoryForGettingBlockablePatients();
            PatientService service = new PatientService(patientStubRepository, appointmentStubRepository);

            Patient patient = service.UpdateStatus("2406978890046");

            patient.ShouldNotBeNull();
        }

        [Fact]
        public void Dont_block_patient_by_id()
        {
            var patientStubRepository = CreatePatientStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepositoryForGettingBlockablePatients();
            PatientService service = new PatientService(patientStubRepository, appointmentStubRepository);

            Patient patient = service.UpdateStatus("2406978890047");

            patient.ShouldBeNull();
        }

        public static IPatientRepository CreatePatientStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            Patient patient = CreatePatient();

            stubRepository.Setup(p => p.GetBy("2406978890046")).Returns(patient);

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

        private static List<MedbayTech.Users.Domain.Entites.Appointment> CreateAppointmentsForBlockablePatients()
        {
            var appointment = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 5),
                PatientId = "2406978890046"
            };

            var appointment2 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                PatientId = "2406978890046"
            };

            var appointment3 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                PatientId = "2406978890046"
            };

            var appointment4 = new MedbayTech.Users.Domain.Entites.Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 7, 1),
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
                DateOfCreation = new DateTime(),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Username = "pera",
                Password = "pera1978",
                Phone = "065/123-4554",
                Profession = "vodoinstalater",
                ProfileImage = ".",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            };

            return patient;
        }
    }
}
