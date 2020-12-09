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
        List<Appointment> GetAvailableBy(string doctorId, DateTime date);
        List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date);
        Appointment ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAvailableByDoctorAndDateRange(string doctorId, DateTime start, DateTime end);
        List<Appointment> GetAvailableByDoctorAndTimeInterval(string doctorId, DateTime startTime, DateTime endTime);
        List<Appointment> GetAvailableByPriorityDoctor(string doctorId, DateTime startTime, DateTime endTime);
        List<Appointment> GetAvailableByPriorityTimeInterval(DateTime startTime, DateTime endTime);
        List<Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(string doctorId, int hospitalEquipmentId, DateTime startTime, DateTime endTime, string priority);
        List<Appointment> GetApppointmentsScheduledForSpecificRoom(int roomId);
    }
}
