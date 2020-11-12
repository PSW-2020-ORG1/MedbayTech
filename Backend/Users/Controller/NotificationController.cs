// File:    NotificationController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:58:59 AM
// Purpose: Definition of Class NotificationController

using Backend.Medications.Model;
using Model.Schedule;
using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class NotificationController
   {
        public NotificationController(NotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public Notification NewVacationRequest(Employee employee) => notificationService.NewVacationRequest(employee);
        public Notification QuestionReplyNotification(Question question) => notificationService.QuestionReplyNotification(question);
        public Notification QuestionNotification(Question question) => notificationService.QuestionNotification(question);
        public Notification AppointmentNotifyForPatients(Appointment appointment) => notificationService.AppointmentNotifyForPatients(appointment);
        public Notification AppointmentNotifyForDoctors(Appointment appointment) => notificationService.AppointmentNotifyForDoctors(appointment);
        public Notification RenovationNotification() => notificationService.RenovationNotification();
        public Notification MedForValidationNotification(Medication medication) => notificationService.MedForValidationNotification(medication);
        public Notification MedicationValidatedNotification(Doctor doctor) => notificationService.MedicationValidatedNotification(doctor);
        public Notification DeletedAppointment(Appointment appointment) => notificationService.DeletedAppointment(appointment);
        public IEnumerable<Notification> GetNotificationsForUser(string username) => notificationService.GetNotificationsForUser(username);
        
        public NotificationService notificationService;
   
   }
}