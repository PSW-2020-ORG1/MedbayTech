using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Interfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointmentsByPatientId(string id);
        List<Appointment> GetSurveyableAppointments(string id);
        List<Appointment> GetAllOtherAppointments(string id);
        List<Appointment> GetCancelableAppointments(string id);
        bool UpdateCanceled(int appointmentId);
        Appointment CreateAppointment(Appointment appointment);
    }
}
