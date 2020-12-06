using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Interfaces
{
    interface IAppointmentService
    {
        List<Appointment> GetAppointmentsByPatientId(string id);
        Appointment CreateAppointment(Appointment appointment);
    }
}
