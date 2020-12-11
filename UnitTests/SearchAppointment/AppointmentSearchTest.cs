using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Backend.Schedules.Service;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Repository.ScheduleRepository;
using Shouldly;
using Castle.Core.Internal;

namespace MedbayTechUnitTests
{
    public class AppointmentSearchTest
    {
        //dodajem i oduzimam dva dana na start/end
        [Fact]
        public void GetAppointmentsScheduledForDoctorAndTimeFail()
        {
            var doctorWorkDayRepository = CreateStubRepositoryDoctorWork();
            var appointmentsRepository = CreateStubRepositoryAppointment();
            AppointmentService service = new AppointmentService(doctorWorkDayRepository,appointmentsRepository);
            String id = "2406978890047";
            DateTime start_date = new DateTime(1999, 12, 5, 8, 0, 0);
            DateTime end_date = new DateTime(1999, 12, 5, 8, 30, 0);
            var gotAppointment = service.GetAvailableByDoctorAndDateRange(id, start_date, end_date);

            gotAppointment.IsNullOrEmpty();
        }

        public static IAppointmentRepository CreateStubRepositoryAppointment()
        {
            var stubRepository = new Mock <IAppointmentRepository>();
            var appointments = CreateLisfOfAppointments();
            var appointment = CreateAppointment();

            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetBy(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.Start.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }

        public static IDoctorWorkDayRepository CreateStubRepositoryDoctorWork()
        {
            var stubRepository = new Mock <IDoctorWorkDayRepository>();
            var doctorWorkDays = CreateListOfDoctorWorkDays(); 
            stubRepository.Setup(x => x.GetByDoctorIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(
                (string id, DateTime date) =>
                    doctorWorkDays.Where(wd => wd.DoctorId.Equals(id) && wd.Date.CompareTo(date) == 0).FirstOrDefault());
            return stubRepository.Object;
        }


        public static List<Appointment> CreateLisfOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            Appointment app2 = new Appointment
            {
                Id = 6,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2021, 12, 5, 8, 0, 0),
                End = new DateTime(2021, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };

            appointments.Add(app1);
            appointments.Add(app2);
           
            return appointments;
        }
        public static List<DoctorWorkDay> CreateListOfDoctorWorkDays()
        {
            List<DoctorWorkDay> workAndDayList = new List<DoctorWorkDay>();
            DoctorWorkDay workDay1 = new DoctorWorkDay { Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay2 = new DoctorWorkDay { Id = 3, Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay3 = new DoctorWorkDay { Id = 4, Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            DoctorWorkDay workDay4 = new DoctorWorkDay { Id = 5, Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            workAndDayList.Add(workDay1);
            workAndDayList.Add(workDay2);
            workAndDayList.Add(workDay3);
            workAndDayList.Add(workDay4);
            return workAndDayList;
        }
        public static DoctorWorkDay CreateWorkDay()
        {
            DoctorWorkDay doctorWorkDay = new DoctorWorkDay { Id = 2, Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" };
            return doctorWorkDay;
        }
        public static Appointment CreateAppointment()
        {
            Appointment app = new Appointment
            {
                Id = 4,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Start = new DateTime(2020, 12, 5, 8, 0, 0),
                End = new DateTime(2020, 12, 5, 8, 30, 0),
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1003,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1
            };
            return app;
        }
    }
}
