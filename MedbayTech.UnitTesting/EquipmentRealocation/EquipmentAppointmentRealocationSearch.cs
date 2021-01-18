using Application.Common.Interfaces.Persistance;
using Castle.Core.Internal;
using Domain.Enums;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Appointment.Infrastructure.Services;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MedbayTech.UnitTesting.EquipmentRealocation
{
    public class EquipmentAppointmentRealocationSearch
    {
        [Fact]
        public void GetAlternativeAvailableAppointmentsFail()
        {
            AppointmentRealocationService appointmentRealocationService = new AppointmentRealocationService(CreateStubRepositoryAppointmentRealocation(), CreateStubRepositoryAppointment());
            var gotAppointments = appointmentRealocationService.GetAlternativeAvailableAppointments(1003, 1119, new DateTime(1999, 10, 3, 0, 0, 0), 1);
            gotAppointments.IsNullOrEmpty();
        }

        [Fact]
        public void GetAlternativeAvailableAppointmentsSuccess()
        {
            AppointmentRealocationService appointmentRealocationService = new AppointmentRealocationService(CreateStubRepositoryAppointmentRealocation(), CreateStubRepositoryAppointment());
            var gotAppointments = appointmentRealocationService.GetAlternativeAvailableAppointments(1003, 1119, DateTime.Now, 1);
            gotAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void GetAvailableAppointmentRealocationsForTwoRomsFail()
        {
            AppointmentRealocationService appointmentRealocationService = new AppointmentRealocationService(CreateStubRepositoryAppointmentRealocation(), CreateStubRepositoryAppointment());
            var gotAppointments = appointmentRealocationService.GetAvailableAppointmentRealocationsForTwoRoms(1003, 1119, new DateTime(1999, 10, 3, 0, 0, 0), new DateTime(1999,10,4,0,0,0));
            gotAppointments.IsNullOrEmpty();
        }

        [Fact]
        public void GetAvailableAppointmentRealocationsForTwoRomsSuccess()
        {
            AppointmentRealocationService appointmentRealocationService = new AppointmentRealocationService(CreateStubRepositoryAppointmentRealocation(), CreateStubRepositoryAppointment());
            var gotAppointments = appointmentRealocationService.GetAvailableAppointmentRealocationsForTwoRoms(1003, 1119, DateTime.Now, DateTime.Now.AddHours(5));
            gotAppointments.ShouldNotBeEmpty();
        }

        public static IAppointmentRealocationRepository CreateStubRepositoryAppointmentRealocation()
        {
            var stubRepository = new Mock<IAppointmentRealocationRepository>();
            var appointments = CreateLisfOfAppointmentRealocations();
            var appointment = CreateAppointmentRealocation();

            stubRepository.Setup(x => x.GetAll()).Returns(appointments);
            stubRepository.Setup(x => x.Create(It.IsAny<AppointmentRealocation>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.Id == id && a.Start.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }

        public static Application.Common.Interfaces.Persistance.IAppointmentRepository CreateStubRepositoryAppointment()
        {
            var stubRepository = new Mock<Application.Common.Interfaces.Persistance.IAppointmentRepository>();
            var appointments = CreateLisfOfAppointments();
            var appointment = CreateAppointment();

            stubRepository.Setup(x => x.GetAll()).Returns(appointments);
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment.Domain.Entities.Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Period.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }

        public IHospitalEquipmentRepository CreateStupRepositoryEquipment()
        {
            var stubRepository = new Mock<IRoomGateway>();
            var equipment = GetListOfEquipment().ToList();
            stubRepository.Setup(m => m.GetAllHospitalEquipments()).Returns(equipment);
            return (IHospitalEquipmentRepository)stubRepository.Object;
        }

        public static List<Appointment.Domain.Entities.Appointment> CreateLisfOfAppointments()
        {
            List<Appointment.Domain.Entities.Appointment> appointments = new List<Appointment.Domain.Entities.Appointment>();
            Appointment.Domain.Entities.Appointment app1 = new Appointment.Domain.Entities.Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period() { StartTime = new DateTime(2020, 12, 5, 8, 0, 0), EndTime = new DateTime(2020, 12, 5, 8, 30, 0) },
                Urgent = false,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                DoctorId = "2406978890047",
            };
            Appointment.Domain.Entities.Appointment app2 = new Appointment.Domain.Entities.Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period() { StartTime = new DateTime(2021, 12, 5, 8, 0, 0), EndTime = new DateTime(2021, 12, 5, 8, 30, 0) },
                Urgent = false,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                DoctorId = "2406978890047",
            };
            appointments.Add(app1);
            appointments.Add(app2);
            return appointments;
        }

        public static Appointment.Domain.Entities.Appointment CreateAppointment()
        {
            Appointment.Domain.Entities.Appointment app = new Appointment.Domain.Entities.Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period() { StartTime = new DateTime(2020, 12, 5, 8, 0, 0), EndTime = new DateTime(2020, 12, 5, 8, 30, 0) },
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                DoctorId = "2406978890047",
            };
            return app;
        }

        public static List<AppointmentRealocation> CreateLisfOfAppointmentRealocations()
        {
            List<AppointmentRealocation> appointments = new List<AppointmentRealocation>();
            AppointmentRealocation app1 = new AppointmentRealocation
            {
                Id = 4,
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                HospitalEquipmentId = 1
            };
            AppointmentRealocation app2 = new AppointmentRealocation
            {
                Id = 6,
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                HospitalEquipmentId = 1
            };

            appointments.Add(app1);
            appointments.Add(app2);

            return appointments;
        }

        public static AppointmentRealocation CreateAppointmentRealocation()
        {
            AppointmentRealocation app = new AppointmentRealocation
            {
                Id = 4,
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                HospitalEquipmentId = 1
            };
            return app;
        }

        private static IEnumerable<HospitalEquipment> GetListOfEquipment()
        {
            var h1 = new HospitalEquipment { Id = 1, RoomId = 1003, EquipmentTypeId = 9 };
            var h2 = new HospitalEquipment { Id = 2, RoomId = 1003, EquipmentTypeId = 10 };
            var h3 = new HospitalEquipment { Id = 3, RoomId = 1003, EquipmentTypeId = 17 };
            var h4 = new HospitalEquipment { Id = 4, RoomId = 1003, EquipmentTypeId = 18 };
            var h5 = new HospitalEquipment { Id = 5, RoomId = 1003, EquipmentTypeId = 19 };
            var h6 = new HospitalEquipment { Id = 6, RoomId = 1003, EquipmentTypeId = 22 };
            var hospitalEquipment = new List<HospitalEquipment>();
            hospitalEquipment.Add(h1);
            hospitalEquipment.Add(h2);
            hospitalEquipment.Add(h3);
            hospitalEquipment.Add(h4);
            hospitalEquipment.Add(h5);
            hospitalEquipment.Add(h6);
            return hospitalEquipment;
        }

        private static IEnumerable<Room> GetListOfRooms()
        {
            Room h1 = new Room
            {
                Id = 1003,
                RoomLabel = "",
                RoomType = RoomType.ExaminationRoom
            };
            Room h2 = new Room
            {
                Id = 1119,
                RoomLabel = "",
                RoomType = RoomType.ExaminationRoom
            };
            var rooms = new List<Room>();
            rooms.Add(h1);
            rooms.Add(h2);
            return rooms;
        }

        private static Room CreateRoom()
        {
            Room room = new Room
            {
                Id = 1003,
                RoomLabel = "",
                RoomType = RoomType.ExaminationRoom
            };
            return room;
        }
    }
}
