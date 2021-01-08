using Application.Common.Interfaces.Persistance;
using Application.DTO;
using Castle.Core.Internal;
using Domain.Enums;
using Infrastructure.Services;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Infrastructure.Services;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Rooms.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MedbayTech.UnitTesting.SearchAppointment
{
    public class AppointmentSearchTests
    {

        [Fact]
        public void GetAvailableAppointmentsForDoctorAndTimeFail()
        {
            /*var doctorWorkDayRepository = CreateStubRepositoryDoctorWork();
            var appointmentsRepository = CreateStubRepositoryAppointment();
            AppointmentService service = new AppointmentService(doctorWorkDayRepository, appointmentsRepository);
            String id = "2406978890047";
            DateTime start_date = new DateTime(1999, 12, 5, 8, 0, 0);
            DateTime end_date = new DateTime(1999, 12, 5, 8, 30, 0);
            var gotAppointment = service.GetAvailableByDoctorAndTimeInterval(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointment.IsNullOrEmpty();*/
        }
        [Fact]
        public void GetAvailableAppointmentsForDoctorAndTimeSuccess()
        {
            /*var doctorWorkDayRepository = CreateStubRepositoryDoctorWork();
            var appointmentsRepository = CreateStubRepositoryAppointment();
            AppointmentService service = new AppointmentService(doctorWorkDayRepository, appointmentsRepository);
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 8, 30, 0);
            var gotAppointment = service.GetAvailableByDoctorAndTimeInterval(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointment.ShouldNotBeEmpty();*/
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityTimeIntervalFail()
        {
           /* AppointmentService appointmentsService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService service = new AppointmentFilterService(appointmentsService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            DateTime start_date = new DateTime(2022, 12, 5, 8, 0, 0);
            DateTime end_date = new DateTime(2022, 12, 5, 8, 30, 0);
            var gotAppointments = service.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointments.IsNullOrEmpty();*/
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityTimeIntervalSuccess()
        {
           /* AppointmentService appointmentsService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            AppointmentFilterService service = new AppointmentFilterService(appointmentsService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
            var gotAppointments = service.GetAvailableByPriorityTimeInterval(new PriorityParameters { ChosenStartDate = start_date, ChosenEndDate = end_date });

            gotAppointments.ShouldNotBeEmpty();*/
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityDoctorFail()
        {/*
            AppointmentService service = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 3, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 5, 8, 30, 0);
            var gotAppointments = service.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });
            gotAppointments.IsNullOrEmpty();*/
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityDoctorSuccess()
        {
            // AppointmentService service = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            // String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
           // var gotAppointments = service.GetAvailableByPriorityDoctor(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date });
            // gotAppointments.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityEquipmentSuccess()
        {
            // AppointmentService appService = new AppointmentService(CreateStubRepositoryDoctorWork(), CreateStubRepositoryAppointment());
            // AppointmentFilterService filterService = new AppointmentFilterService(appService, CreateStubRepositoryDoctor(), CreateStupRepositoryEquipment());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 6, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 6, 15, 0, 0);
            // var gotAppointments = filterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date }, 9, "doctor");
             //gotAppointments.ShouldNotBeEmpty();
        }
        [Fact]
        public void GetAvailableAppointmentByPriorityEquipmentFail()
        {
            AppointmentService appService = new AppointmentService(CreateStubRepositoryAppointment(), CreateStubRepositoryDoctor(), CreateRoomGateway(), null);
            AppointmentFilterService filterService = new AppointmentFilterService(appService, CreateStubRepositoryDoctor(), CreateRoomGateway());
            String id = "2406978890047";
            DateTime start_date = new DateTime(2020, 12, 10, 8, 0, 0);
            DateTime end_date = new DateTime(2020, 12, 10, 8, 30, 0);
            var gotAppointments = filterService.GetAvailableByDoctorTimeIntervalAndEquipment(new PriorityParameters { DoctorId = id, ChosenStartDate = start_date, ChosenEndDate = end_date }, 1, "doctor");
            gotAppointments.IsNullOrEmpty();
        }

        public static IAppointmentRepository CreateStubRepositoryAppointment()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateLisfOfAppointments();
            var appointment = CreateAppointment();

            stubRepository.Setup(x => x.Create(It.IsAny<Appointment.Domain.Entities.Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Period.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }


        public static IUserGateway CreateStubRepositoryDoctor()
        {
            var stubRepository = new Mock<IUserGateway>();
            var doctorList = CreateListOfDoctor();
            var doctorWorkDays = CreateListOfDoctorWorkDays();

            stubRepository.Setup(m => m.GetAllDoctors()).Returns(doctorList);
            stubRepository.Setup(x => x.GetWorkDayBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    doctorWorkDays.Where(wd => wd.DoctorId.Equals(id) && wd.Date.CompareTo(date) == 0).FirstOrDefault());

            stubRepository.Setup(m => m.GetDoctorBy(It.IsAny<string>())).Returns((string id) => doctorList.Find(d => d.Id.Equals(id)));
            return stubRepository.Object;
        }


        public IRoomGateway CreateRoomGateway()
        {
            var stubRepository = new Mock<IRoomGateway>();
            var equipment = GetListOfEquipment().ToList();
            stubRepository.Setup(m => m.GetAllHospitalEquipments()).Returns(equipment);
            return stubRepository.Object;
        }

        public static List<Appointment.Domain.Entities.Doctor> CreateListOfDoctor()
        {
            List<Appointment.Domain.Entities.Doctor> doctors = new List<Appointment.Domain.Entities.Doctor>();
            Appointment.Domain.Entities.Doctor doc1 = new Appointment.Domain.Entities.Doctor
            {
                Id = "2406978890047",
                Name = "Milan",
                Surname = "Milanovic",
                LicenseNumber = "001",
                ExaminationRoomId = 1003,
                SpecializationId = 1
            };
            Appointment.Domain.Entities.Doctor doc2 = new Appointment.Domain.Entities.Doctor
            {
                Id = "2406978890048",
                Name = "Zivorad",
                Surname = "Zivoradovic",
                LicenseNumber = "001",
                ExaminationRoomId = 1003,
                SpecializationId = 1
            };
            doctors.Add(doc1);
            doctors.Add(doc2);
            return doctors;
        }

        public static List<Appointment.Domain.Entities.Appointment> CreateLisfOfAppointments()
        {
            List<Appointment.Domain.Entities.Appointment> appointments = new List<Appointment.Domain.Entities.Appointment>();
            Appointment.Domain.Entities.Appointment app1 = new Appointment.Domain.Entities.Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period(new DateTime(2020, 12, 5, 8, 0, 0), new DateTime(2020, 12, 5, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                PatientId = "1",
                DoctorId = "2406978890047",
            };
            Appointment.Domain.Entities.Appointment app2 = new Appointment.Domain.Entities.Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Period(new DateTime(2021, 12, 5, 8, 0, 0), new DateTime(2021, 12, 5, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                PatientId = "1",
                DoctorId = "2406978890047",
            };

            appointments.Add(app1);
            appointments.Add(app2);

            return appointments;
        }
        public static List<WorkDay> CreateListOfDoctorWorkDays()
        {
            List<WorkDay> workAndDayList = new List<WorkDay>();
            WorkDay workDay1 = new WorkDay { Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay workDay2 = new WorkDay { Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay workDay3 = new WorkDay { Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            WorkDay workDay4 = new WorkDay { Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            workAndDayList.Add(workDay1);
            workAndDayList.Add(workDay2);
            workAndDayList.Add(workDay3);
            workAndDayList.Add(workDay4);
            return workAndDayList;
        }
        public static WorkDay CreateWorkDay()
        {
            WorkDay doctorWorkDay = new WorkDay { Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            return doctorWorkDay;
        }
        public static Appointment.Domain.Entities.Appointment CreateAppointment()
        {
            Appointment.Domain.Entities.Appointment app = new Appointment.Domain.Entities.Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Period = new Common.Domain.ValueObjects.Period(new DateTime(2020, 12, 5, 8, 0, 0), new DateTime(2020, 12, 5, 8, 30, 0)),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                PatientId = "1",
                DoctorId = "2406978890047"
            };
            return app;
        }

        private static IEnumerable<Appointment.Domain.Entities.HospitalEquipment> GetListOfEquipment()
        {
            var h1 = new Appointment.Domain.Entities.HospitalEquipment { Id = 1, RoomId = 1003, EquipmentTypeId = 9 };
            var h2 = new Appointment.Domain.Entities.HospitalEquipment { Id = 2, RoomId = 1003, EquipmentTypeId = 10 };
            var h3 = new Appointment.Domain.Entities.HospitalEquipment { Id = 3, RoomId = 1003, EquipmentTypeId = 17 };
            var h4 = new Appointment.Domain.Entities.HospitalEquipment { Id = 4, RoomId = 1003, EquipmentTypeId = 18 };
            var h5 = new Appointment.Domain.Entities.HospitalEquipment { Id = 5, RoomId = 1003, EquipmentTypeId = 19 };
            var h6 = new Appointment.Domain.Entities.HospitalEquipment { Id = 6, RoomId = 1003, EquipmentTypeId = 22 };
            var hospitalEquipment = new List<Appointment.Domain.Entities.HospitalEquipment>();
            hospitalEquipment.Add(h1);
            hospitalEquipment.Add(h2);
            hospitalEquipment.Add(h3);
            hospitalEquipment.Add(h4);
            hospitalEquipment.Add(h5);
            hospitalEquipment.Add(h6);
            return hospitalEquipment;
        }
    }
}
