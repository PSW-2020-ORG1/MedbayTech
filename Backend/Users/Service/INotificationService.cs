using Backend.Examinations.Model;
using Backend.Medications.Model;
using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Medications.Service
{
    public interface INotificationService
    {
        Notification NewVacationRequest(Employee employee);
        Notification QuestionReplyNotification(Question question);
        Notification QuestionNotification(Question question);
        Notification AppointmentNotifyForPatients(Appointment appointement);
        Notification AppointmentNotifyForDoctors(Appointment appointement);
        Notification RenovationNotification();
        Notification MedForValidationNotification(Medication medication);
        Notification MedicationValidatedNotification(Doctor doctor);
        Notification NewEmergencyRequest(EmergencyRequest emergencyRequest);
        Notification NewHospitalTreatment(HospitalTreatment hospitalTreatment);
        Notification DeletedAppointment(Appointment appointment);
        IEnumerable<Notification> GetNotificationsForUser(string username);

    }
}
