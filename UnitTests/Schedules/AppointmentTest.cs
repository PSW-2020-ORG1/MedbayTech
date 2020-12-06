using Backend.Records.Model;
using Model.Schedule;
using Moq;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Schedules
{
    public class AppointmentTest
    {
        [Fact]
        public void Find_patients_Appointments() 
        {
            AppointmentService service = new AppointmentService(CreateStubRepository());
            List<Appointment> appointments = service.GetAppointmentsByPatientId("2505998800045");
            appointments.ShouldNotBeNull();
        }

        [Fact]
        public void Doesnt_find_patinents_Appointments()
        {
        }

        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();
            var appointment = CreateAppointment();
            stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
          

            return stubRepository.Object;
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
