using Backend.Records.Model;
using Backend.Users.Repository.MySqlRepository;
using Model.Schedule;
using Model.Users;
using Moq;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.Schedules
{
    public class AppointmentTest
    {
        [Fact]
        public void Find_patients_Appointments() 
        {
            AppointmentService service = new AppointmentService(CreateAppointmentStubRepository(), CreateSurveyStubRepository());
            List<Appointment> appointments = service.GetAppointmentsByPatientId("2505998800045");
            appointments.Count.ShouldNotBe(0);
        }

        [Fact]
        public void Doesnt_find_patinents_Appointments()
        {
            AppointmentService service = new AppointmentService(CreateAppointmentStubRepository(), CreateSurveyStubRepository());
            List<Appointment> appointments = service.GetAppointmentsByPatientId("2541998800045");
            appointments.Count.ShouldBe(0);
        }

        [Fact]
        public void Find_surveyable_Appointments()
        {
            AppointmentService service = new AppointmentService(CreateAppointmentStubRepository(), CreateSurveyStubRepository());
            List<Appointment> appointments = service.GetSurveyableAppointments("2505998800045");
            appointments.Count.ShouldNotBe(0);
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();
            var appointment = CreateAppointment();
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.GetAppointmentsByPatientId(It.IsAny<string>())).Returns(
                (string id) =>
                appointments.Where(a => a.MedicalRecord.PatientId.Equals(id)).ToList());

            return stubRepository.Object;
        }
        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = CreateSurveys();
            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            return stubRepository.Object;
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

        public static MedicalRecord CreateMedicalRecord()
        {
            return new MedicalRecord
            {
                Id = 1,
                PatientId = "2505998800045"
            };
        }
        public static Appointment CreateAppointment()
        {
            return new Appointment
            {
                Id = 8,
                DoctorId = "2406978890047",
                Start = new DateTime(2020, 12, 5, 14, 30, 0),
                End = new DateTime(2020, 12, 5, 15, 0, 0),
                MedicalRecordId = 1,
                MedicalRecord = CreateMedicalRecord(),
                RoomId = 1
            };
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
                MedicalRecord = CreateMedicalRecord(),
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
                MedicalRecord = CreateMedicalRecord(),
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
                MedicalRecord = CreateMedicalRecord(),
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
                MedicalRecord = CreateMedicalRecord(),
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
