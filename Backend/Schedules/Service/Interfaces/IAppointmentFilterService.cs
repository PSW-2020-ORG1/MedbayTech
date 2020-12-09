using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Interfaces
{
    public interface IAppointmentFilterService
    {
        List<Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(string doctorId, int hospitalEquipmentId, DateTime startTime, DateTime endTime, string priority);
        List<Appointment> GetAvailableByPriorityTimeInterval(DateTime startTime, DateTime endTime);
    }
}
