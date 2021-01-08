using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Common.Interfaces.Persistance;
using Application.DTO;
using Domain.Enums;
using Infrastructure.Services;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Rooms.Domain;
using Moq;
using Shouldly;
using Xunit;
using Doctor = MedbayTech.Appointment.Domain.Entities.Doctor;
using Patient = MedbayTech.Appointment.Domain.Entities.Patient;
using Room = MedbayTech.Appointment.Domain.Entities.Room;
using RoomType = MedbayTech.Appointment.Domain.Enums.RoomType;

namespace MedbayTech.UnitTesting.Schedules
{
    public class AppointmentTests
    {
        [Fact]
        public void Recommend_by_date_priority_success()
        {
            var surveyRepository = CreateSurveyStubRepository();
            var userGateway = CreateUserGateway();
            var roomGateway = CreateRoomGateway();
            var appointmentRepository = CreateAppointmentStubRepository();
            var priorityParameters = CreatePriorityParametersForDatePrioritySuccess();
            AppointmentService appointmentService = new AppointmentService(appointmentRepository, userGateway, roomGateway, surveyRepository);

            List<Appointment.Domain.Entities.Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priorityParameters);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        public static IUserGateway CreateUserGateway()
        {
            var userGateway = new Mock<IUserGateway>();
            var doctors = CreateDoctors();
            var patients = CreatePatients();
            var workDays = CreateWorkDays();

            userGateway.Setup(u => u.GetDoctorBy(It.IsAny<String>()))
                .Returns((string id) => doctors.FirstOrDefault(x => x.Id.Equals(id)));

            userGateway.Setup(u => u.GetPatientBy(It.IsAny<string>()))
                .Returns((string id) => patients.FirstOrDefault(x => x.Id.Equals(id)));

            userGateway.Setup(u => u.GetWorkDayBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    workDays.FirstOrDefault(x => x.DoctorId.Equals(id) && DateTime.Compare(x.Date, date) == 0));

            return userGateway.Object;
        }

        public static IRoomGateway CreateRoomGateway()
        {
            var roomGateway = new Mock<IRoomGateway>();
            var rooms = CreateRooms();
            roomGateway.Setup(x => x.GetRoomBy(It.IsAny<int>()))
                .Returns((int id) => rooms.FirstOrDefault(x => x.Id == id));

            return roomGateway.Object;
        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateAppointments();
            var appointment = CreateAppointmentSuccess();
            var appointmentCancel = CreateAppointment();
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment.Domain.Entities.Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Period.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            stubRepository.Setup(x => x.GetAppointmentsByPatientId(It.IsAny<string>())).Returns(
                (string id) =>
                    appointments.Where(a => a.PatientId.Equals(id)).ToList());

            stubRepository.Setup(x => x.GetBy(It.IsAny<int>())).Returns(
                (int id) =>
                    appointments.Where(a => a.Id == id).FirstOrDefault());

            stubRepository.Setup(x => x.Update(appointmentCancel)).Returns(appointmentCancel);

            return stubRepository.Object;
        }

        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = CreateSurveys();
            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            return stubRepository.Object;
        }

        public static Appointment.Domain.Entities.Appointment CreateAppointmentSuccess()
        {
            return new Appointment.Domain.Entities.Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Period = new Period(new DateTime(2020, 12, 5, 14, 30, 0), new DateTime(2020, 12, 5, 15, 0, 0)),
                PatientId = "2406978890046",
                Patient = CreatePatient(),
                RoomId = 1
            };
        }

        public static Appointment.Domain.Entities.Appointment CreateAppointment()
        {
            return new Appointment.Domain.Entities.Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Period = new Period(new DateTime(2020, 12, 5, 14, 30, 0), new DateTime(2020, 12, 5, 15, 0, 0)),
                CanceledByPatient = true,
                RoomId = 1,
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };
        }
        public static List<Appointment.Domain.Entities.Appointment> CreateAppointments()
        {
            List<Appointment.Domain.Entities.Appointment> appointments = new List<Appointment.Domain.Entities.Appointment>();
            Appointment.Domain.Entities.Appointment ap1 = new Appointment.Domain.Entities.Appointment
            {
                Id = 1,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };

            Appointment.Domain.Entities.Appointment ap2 = new Appointment.Domain.Entities.Appointment
            {
                Id = 2,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };

            Appointment.Domain.Entities.Appointment ap3 = new Appointment.Domain.Entities.Appointment
            {
                Id = 3,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };
            Appointment.Domain.Entities.Appointment ap4 = new Appointment.Domain.Entities.Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period(new DateTime(2020, 12, 5, 8, 0, 0), new DateTime(2020, 12, 5, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };
            Appointment.Domain.Entities.Appointment ap5 = new Appointment.Domain.Entities.Appointment
            {
                Id = 5,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period(new DateTime(2020, 12, 8, 8, 0, 0), new DateTime(2020, 12, 8, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };
            Appointment.Domain.Entities.Appointment ap6 = new Appointment.Domain.Entities.Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period(new DateTime(2021, 12, 15, 8, 0, 0), new DateTime(2021, 12, 15, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                Patient = CreatePatient()
            };

            appointments.Add(ap1);
            appointments.Add(ap2);
            appointments.Add(ap3);
            appointments.Add(ap4);
            appointments.Add(ap5);
            appointments.Add(ap6);

            return appointments;
        }
        public static List<Survey> CreateSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            Survey s1 = new Survey
            {
                AppointmentId = 1,
            };

            Survey s2 = new Survey
            {
                AppointmentId = 2,
            };

            surveys.Add(s1);
            surveys.Add(s2);

            return surveys;
        }

        public static List<Room> CreateRooms()
        {
            List<Room> rooms = new List<Room>();
            Room room1 = new Room
            {
                Id = 1,
                Department = new Department(),
                RoomLabel = "",
                RoomType = RoomType.ExaminationRoom
            };

            rooms.Add(room1);

            return rooms;

        }

        public static Patient CreatePatient()
        {
            return new Patient
            {
                Id = "2406978890046",
                DateOfBirth = new DateTime(1978, 6, 24),
                Name = "Petar",
                Surname = "Petrovic",
            };
        }
        public static List<WorkDay> CreateWorkDays()
        {
            List<WorkDay> doctorWorkDays = new List<WorkDay>();

            WorkDay dw1 = new WorkDay
                { Date = new DateTime(2020, 12, 5), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay dw2 = new WorkDay
                { Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay dw3 = new WorkDay
                { Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay dw4 = new WorkDay
                { Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay dw5 = new WorkDay
                { Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };

            WorkDay dw6 = new WorkDay
                { Date = new DateTime(2020, 12, 20), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" };

            doctorWorkDays.Add(dw6);
            doctorWorkDays.Add(dw1);
            doctorWorkDays.Add(dw2);
            doctorWorkDays.Add(dw3);
            doctorWorkDays.Add(dw4);
            doctorWorkDays.Add(dw5);

            return doctorWorkDays;
        }
        public static List<Patient> CreatePatients()
        {
            List<Patient> patients = new List<Patient>();
            Patient patient1 = new Patient
            {
                Id = "2406978890046",
                DateOfBirth = new DateTime(1978, 6, 24),
                Name = "Petar",
                Surname = "Petrovic",
            };
            patients.Add(patient1);

            return patients;
        }
        public static List<Doctor> CreateDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            Doctor doctor1 = new Doctor
            {
                Id = "2406978890047",
                Name = "Milan",
                Surname = "Milanovic",
                LicenseNumber = "001",
                ExaminationRoomId = 49,
                SpecializationId = 1,

            };
            Doctor doctor2 = new Doctor
            {
                Id = "2407978890045",
                Name = "Ivan",
                Surname = "Ivanovic",
                LicenseNumber = "001",
                ExaminationRoomId = 8,
                SpecializationId = 1,

            };
            Doctor doctor3 = new Doctor
            {
                Id = "2407978890043",
                Name = "Mirjana",
                Surname = "Lakic",
                LicenseNumber = "001",
                ExaminationRoomId = 122,
                SpecializationId = 1,
            };
            Doctor doctor4 = new Doctor
            {
                Id = "2407978890041",
                Name = "Petar",
                Surname = "Petrovic",
                LicenseNumber = "001",
                ExaminationRoomId = 4,
                SpecializationId = 2,
            };
            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);
            doctors.Add(doctor4);

            return doctors;
        }

        public PriorityParameters CreatePriorityParametersForDatePrioritySuccess()
        {
            return new PriorityParameters
            {
                DoctorId = "2406978890047",
                ChosenStartDate = new DateTime(2020, 12, 20),
                ChosenEndDate = new DateTime(2020, 12, 24),
                SpecializationId = 1,
                Priority = PriorityType.date
            };
        }
    }
}
