using Domain.Enums;
using Infrastructure.Database;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
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
            SeedAppointments(context);
            SeedSurveyQuestions(context);
        }

        private static void SeedAppointments(AppointmentDbContext context)
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
                Period = new Period(new DateTime(2021, 01, 21, 13, 30, 0), new DateTime(2021, 01, 21, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = false,
                PatientId = "2406978890046",
            });
            context.Add(new Domain.Entities.Appointment
            {
                Period = new Period(new DateTime(2021, 01, 07, 13, 30, 0), new DateTime(2021, 01, 07, 14, 0, 0)),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                DoctorId = "2406978890047",
                CanceledByPatient = false,
                PatientId = "2406978890046",

            });
            context.SaveChanges();
        }

        public void SeedSurveyQuestions(AppointmentDbContext context)
        {
            context.Add(new SurveyQuestion { Question = "How would you rate the kindness of your doctor?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent has your doctor clearly stated what your examination will look like and instructed you on how to behave?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the clarity and expertise of the doctor in making the diagnosis?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the competence of your doctor during the treatment?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent has your doctor paid attention to you and contributed to your more comfortable stay in the hospital?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the helpfulness and kindness of the information counter employees?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the helpfulness and kindness of nurses and technicians?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent were nurses and technicians professional in treatment?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent have nurses and technicians paid attention to you and your comfortable hospital stay?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent have nurses and technicians instructed you in the procedures they will perform during your treatment?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness of hospital hallways and waiting rooms?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness of the toilet in the hospital?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness and comfort of the patient's room?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent are you satisfied with the equipment of the hospital for the needs of your treatment?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the organization of the hospital when scheduling an examination?", QuestionType = QuestionType.HOSPITAL, Status = true });

            context.SaveChanges();
        }

        public bool IsAlreadyFull(AppointmentDbContext context) => context.Appointments.Count() > 0;
    }
}
