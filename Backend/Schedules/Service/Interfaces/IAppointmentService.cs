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
        Appointment CreateAppointment(Appointment appointment);
    }
}
