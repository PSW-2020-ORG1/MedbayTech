
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common
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
        List<Notification> GetNotificationsForUser(string username);

    }
}
