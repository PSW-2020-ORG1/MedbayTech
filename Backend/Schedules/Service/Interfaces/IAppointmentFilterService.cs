using Model.Schedule;
using Service.ScheduleService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Interfaces
{
    public interface IAppointmentFilterService
    {
        List<Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority);
        List<Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters);
        List<Appointment> AddRoomToAppointment(List<Appointment> appointments);
    }
}
