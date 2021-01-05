using Domain.Enums;
using Infrastructure.Database;
using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Linq;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class AppointmentDataSeeder
    {
        public AppointmentDataSeeder() { }

        public void SeedAllEntities(AppointmentDbContext context)
        {
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 5, 14, 00, 0), new DateTime(2020, 12, 5, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 4, 14, 00, 0), new DateTime(2020, 12, 4, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 3, 14, 00, 0), new DateTime(2020, 12, 3, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2407978890045",
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 1, 14, 00, 0), new DateTime(2020, 12, 1, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2407978890045",
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 5, 14, 00, 0), new DateTime(2020, 12, 5, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 5),
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 5, 14, 00, 0), new DateTime(2020, 12, 5, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 11, 25),
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 5, 14, 00, 0), new DateTime(2020, 12, 5, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 14),
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 5, 14, 00, 0), new DateTime(2020, 12, 5, 14, 30, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 15),
                PatientId = "2406978890046"
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 14, 13, 30, 0), new DateTime(2020, 12, 14, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 21),
                PatientId = "2406978890046",
                
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 14, 13, 30, 0), new DateTime(2020, 12, 14, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 24),
                PatientId = "2406978890046",

            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 14, 13, 30, 0), new DateTime(2020, 12, 14, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 25),
                PatientId = "2406978890046",
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2020, 12, 14, 13, 30, 0), new DateTime(2020, 12, 14, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 12, 26),
                PatientId = "2406978890046",

            });
            context.SaveChanges();
        }

        public bool IsAlreadyFull(AppointmentDbContext context) => context.Appointments.Count() > 0;
    }
}
