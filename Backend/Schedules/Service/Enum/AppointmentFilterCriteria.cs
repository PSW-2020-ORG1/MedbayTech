using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Enum
{
    public enum AppointmentFilterCriteria
    {
        ByTimeIntervalPriority,
        BySpecialistNoPriority,
        BySpecialistDoctorPriority,
        BySpecialistTimePriority,
        AddRoomToAppointment
    }
}
