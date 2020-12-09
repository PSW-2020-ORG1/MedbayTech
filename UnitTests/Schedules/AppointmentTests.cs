using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Schedules.Service;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Repository.ScheduleRepository;
using Xunit;
using Shouldly;

namespace UnitTests.Schedules
{
    public class AppointmentTests
    {
        [Fact]
        public void Get_available()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository);

            var workDay = appointmentService.GetAvailableBy("2406978890047", new DateTime(2020, 12, 5));
            workDay.Count.ShouldBe(13);
        }

        [Fact]
        public void Schedule_appointment_success()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var appointment = CreateAppointmentSuccess();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository);

            var createdAppointment = appointmentService.ScheduleAppointment(appointment);
            createdAppointment.ShouldNotBe(null);

        }

        [Fact]
        public void Schedule_appointment_fail()
        {
            var doctorWorkDayStubRepository = CreateDoctorWorkDayStubRepository();
            var appointmentStubRepository = CreateAppointmentStubRepository();
            var appointment = CreateAppointmentFail();
            AppointmentService appointmentService = new AppointmentService(doctorWorkDayStubRepository, appointmentStubRepository);

            var createdAppointment = appointmentService.ScheduleAppointment(appointment);

            createdAppointment.ShouldBe(null);

        }
        public IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();
            var appointment = CreateAppointmentSuccess();
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Start.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }
        public static IDoctorWorkDayRepository CreateDoctorWorkDayStubRepository()
        {
            var stubRepository = new Mock<IDoctorWorkDayRepository>();
            var workDays = CreateDoctorWorkDays();
            stubRepository.Setup(x => x.GetByDoctorIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    workDays.Where(wd => wd.DoctorId.Equals(id) && wd.Date.CompareTo(date) == 0).FirstOrDefault());
            return stubRepository.Object;
        }

        public static Appointment CreateAppointmentFail()
        {
            return new Appointment
            {
                Id = 9,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 10, 8, 0, 0, 0),
                End = new DateTime(2020, 12, 9, 8, 30, 0),
                MedicalRecordId = 1,
                RoomId = 1
            };
        }
        public static Appointment CreateAppointmentSuccess()
        {
            return new Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 5, 14, 30, 0),
                End = new DateTime(2020, 12, 5, 15, 0, 0),
                MedicalRecordId = 1,
                RoomId = 1
            };
        }

        public static List<DoctorWorkDay> CreateDoctorWorkDays()
        {
            List<DoctorWorkDay> doctorWorkDays = new List<DoctorWorkDay>();
            DoctorWorkDay dw1 = new DoctorWorkDay
                {Id = 1, Date = new DateTime(2020, 12, 5), StartTime = 8, EndTime = 15, DoctorId = "2406978890047"};
            DoctorWorkDay dw2 = new DoctorWorkDay
                {Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047"};
            DoctorWorkDay dw3 = new DoctorWorkDay
                {Id = 3, Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047"};
            DoctorWorkDay dw4 = new DoctorWorkDay
                {Id = 4, Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047"};
            DoctorWorkDay dw5 = new DoctorWorkDay
                {Id = 5, Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047"};

            doctorWorkDays.Add(dw1);
            doctorWorkDays.Add(dw2);
            doctorWorkDays.Add(dw3);
            doctorWorkDays.Add(dw4);
            doctorWorkDays.Add(dw5);

            return doctorWorkDays;
        }
        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment ap1 = new Appointment
            {
                Id = 1,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            Appointment ap2 = new Appointment
            {
                Id = 2,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            Appointment ap3 = new Appointment
            {
                Id = 3,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment ap4 = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            
            appointments.Add(ap1);
            appointments.Add(ap2);
            appointments.Add(ap3);
            appointments.Add(ap4);

            return appointments;
        }
    }
}
