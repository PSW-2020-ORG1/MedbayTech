// File:    NotificationService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 12:13:58 AM
// Purpose: Definition of Class NotificationService

using MedbayTech.Rooms.Application.Common;
using MedbayTech.Rooms.Application.Common.Interfaces;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public Notification AppointmentNotifyForDoctors(Appointment appointement)
        {
            throw new System.NotImplementedException();
        }

        public Notification AppointmentNotifyForPatients(Appointment appointement)
        {
            throw new System.NotImplementedException();
        }

        public Notification DeletedAppointment(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }

        public List<Notification> GetNotificationsForUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Notification MedForValidationNotification(Medication medication)
        {
            throw new System.NotImplementedException();
        }

        public Notification MedicationValidatedNotification(Doctor doctor)
        {
            throw new System.NotImplementedException();
        }

        public Notification NewEmergencyRequest(EmergencyRequest emergencyRequest)
        {
            throw new System.NotImplementedException();
        }

        public Notification NewHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            throw new System.NotImplementedException();
        }

        public Notification NewVacationRequest(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Notification QuestionNotification(Question question)
        {
            throw new System.NotImplementedException();
        }

        public Notification QuestionReplyNotification(Question question)
        {
            throw new System.NotImplementedException();
        }

        public Notification RenovationNotification()
        {
            throw new System.NotImplementedException();
        }
    }
}