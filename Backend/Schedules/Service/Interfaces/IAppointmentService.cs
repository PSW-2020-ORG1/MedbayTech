using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Interfaces
{
    public interface IAppointmentService
    {
        List<Appointment> InitializeAppointments(string doctorId, DateTime date);
        List<Appointment> GetAvailableByDoctorAndDate(string doctorId, DateTime date);
        List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date);
        Appointment ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAvailableByDoctorAndDateRange(string doctorId, DateTime start, DateTime end);
    }
}
