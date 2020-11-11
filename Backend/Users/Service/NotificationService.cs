// File:    NotificationService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 12:13:58 AM
// Purpose: Definition of Class NotificationService

using Backend.Examinations.Model;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Repository.GeneralRepository;
using Repository.MedicalRecordRepository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.GeneralService
{
   public class NotificationService
   {
        public NotificationService(INotificationRepository notificationRepository, IUserRepository userRepository, IMedicalRecordRepository medicalRecordRepository)
        {
            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public Notification NewVacationRequest(Employee employee)
        {
            Notification notification = new Notification();
            notification.ContentOfNotification = "Novi zahtev za odsustvo!";
            notification.NotificationCategory = NotificationCategory.VACATION_REQUEST;
            notification.NotificationFrom = employee;
            notification.NotificationTo = (List<RegisteredUser>)userRepository.GetAllManagers();
            return notificationRepository.Create(notification);
        }
      
        public Notification QuestionReplyNotification(Question question)
        {
            Notification notification = new Notification();
            List<RegisteredUser> notificationTo = new List<RegisteredUser>();
            notificationTo.Add(question.Author);
            notification.NotificationTo = notificationTo;
            notification.NotificationFrom = question.QuestionReply.Author;
            notification.ContentOfNotification = "Odgovor na Vaše pitanje je postavljeno od strane " + question.QuestionReply.Author.Name + " " + question.QuestionReply.Author.Surname; 
            notification.NotificationCategory = NotificationCategory.BLOG;
            return notificationRepository.Create(notification);
        }
      
        public Notification QuestionNotification(Question question)
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.BLOG;
            notification.ContentOfNotification = "Novo pitanje je postavljeno na blogu!";
            notification.NotificationFrom = question.Author;
            notification.NotificationTo = MakeListOfDoctors(userRepository.GetAllDoctors()).ToList();
            return notificationRepository.Create(notification);
        }
      
        public Notification AppointmentNotifyForPatients(Appointment appointement)
        {
            Notification notification = new Notification();
            notification.NotificationFrom = appointement.Doctor;
            List<RegisteredUser> notificationTo = new List<RegisteredUser>();
            notificationTo.Add((medicalRecordRepository.GetObject(appointement.MedicalRecord.Id).Patient));
            notification.NotificationTo = notificationTo;
            notification.ContentOfNotification = "Imate novi zakazan pregled kod " + appointement.Doctor.Name + " " + appointement.Doctor.Surname;
            notification.NotificationCategory = NotificationCategory.SCHEDULE;
            return notificationRepository.Create(notification);
        }
      
        public Notification AppointmentNotifyForDoctors(Appointment appointement)
        {
            Notification notification = new Notification();
            Patient patient = medicalRecordRepository.GetObject(appointement.MedicalRecord.Id).Patient;
            notification.NotificationFrom = patient;
            List<RegisteredUser> notificationTo = new List<RegisteredUser>();
            notificationTo.Add(appointement.Doctor);
            notification.NotificationTo = notificationTo;
            notification.ContentOfNotification = "Imate novi zakazan pregled od strane " + patient.Name + " " + patient.Surname;
            notification.NotificationCategory = NotificationCategory.SCHEDULE;
            return notificationRepository.Create(notification);
        }
      
        public Notification RenovationNotification()
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.RENOVATION;
            notification.NotificationTo = MakeListOfSecretaries(userRepository.GetAllSecrateries()).ToList();
            notification.NotificationFrom = null;
            notification.ContentOfNotification = "Novo renoviranje je zakazano!";
            return notificationRepository.Create(notification);

        }
      
        public Notification MedForValidationNotification(Specialization specialization)
        {
            Notification notification = new Notification();
            notification.NotificationTo = MakeListOfDoctors(userRepository.GetAllDoctorsBySpecialization(specialization)).ToList();
            notification.NotificationFrom = null;
            notification.ContentOfNotification = "Novi lek je dodat za validaciju!";
            notification.NotificationCategory = NotificationCategory.MEDICATION;
            return notificationRepository.Create(notification);
        }
      
        public Notification MedicationValidatedNotification(Doctor doctor)
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.MEDICATION;
            notification.NotificationFrom = doctor;
            notification.NotificationTo = MakeListOfManagers(userRepository.GetAllManagers()).ToList();
            notification.ContentOfNotification = "Validiran lek od strane " + doctor.Name + " " + doctor.Surname;
            return notificationRepository.Create(notification);
        }

        public Notification NewEmergencyRequest(EmergencyRequest emergencyRequest)
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.EMERGENCY_REQUEST;
            notification.NotificationFrom = null;
            notification.NotificationTo = MakeListOfSecretaries(userRepository.GetAllSecrateries()).ToList();
            notification.ContentOfNotification = "Novi zahtev za zakazivanje hitnog pregleda za pacijenta " + 
                emergencyRequest.MedicalRecord.Patient.Name + " " + emergencyRequest.MedicalRecord.Patient.Surname;
            return notificationRepository.Create(notification);
        }

        public Notification NewHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.HOSPITAL_TREATMENT;
            notification.NotificationFrom = null;
            notification.NotificationTo = MakeListOfSecretaries(userRepository.GetAllSecrateries()).ToList();
            notification.ContentOfNotification = "Novi zahtev za bolnièko leèenje je dodat!";
            return notificationRepository.Create(notification);
        }
        public Notification DeletedAppointment(Appointment appointment)
        {
            Notification notification = new Notification();
            notification.NotificationCategory = NotificationCategory.SCHEDULE;
            notification.NotificationFrom = null;
            List<RegisteredUser> notificationTo = new List<RegisteredUser>();
            notificationTo.Add(appointment.MedicalRecord.Patient);
            notification.NotificationTo = notificationTo;
            notification.ContentOfNotification = "Vaš pregled je obrisan! Za više informacija pozovite sekretara.";
            return notificationRepository.Create(notification);
        }

        private IEnumerable<RegisteredUser> MakeListOfSecretaries(IEnumerable<Secretary> entities)
        {
            List<RegisteredUser> users = new List<RegisteredUser>();
            foreach (Secretary secretary in entities)
            {
                users.Add((RegisteredUser)secretary);
            }
            return users;
        }
        private IEnumerable<RegisteredUser> MakeListOfDoctors(IEnumerable<Doctor> entities)
        {
            List<RegisteredUser> users = new List<RegisteredUser>();
            foreach (Doctor doctor in entities)
            {
                users.Add((RegisteredUser)doctor);
            }
            return users;
        }
        private IEnumerable<RegisteredUser> MakeListOfManagers(IEnumerable<Manager> entities)
        {
            List<RegisteredUser> users = new List<RegisteredUser>();
            foreach (Manager manager in entities)
            {
                users.Add((RegisteredUser)manager);
            }
            return users;
        }
        public IEnumerable<Notification> GetNotificationsForUser(string username)
        {
            var allNotification = notificationRepository.GetAll().ToList();
            List<Notification> notificationForUser = new List<Notification>();
            foreach (Notification notification in allNotification)
            {
                if (notification.NotificationTo.Any(notification1 => notification1.Username.Equals(username)))
                {
                    notificationForUser.Add(notification);
                }
            }
            return notificationForUser;
        }


        public IMedicalRecordRepository medicalRecordRepository;
        public IUserRepository userRepository;
        public INotificationRepository notificationRepository;
   
   }
}