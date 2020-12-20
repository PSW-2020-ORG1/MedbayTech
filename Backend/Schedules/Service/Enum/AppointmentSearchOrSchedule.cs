using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Schedules.Service.Enum
{
    public enum AppointmentSearchOrSchedule
    {
        ByRoom,
        ByDoctorAndTimeInterval,
        ByDoctorPriority,
        ScheduleAppointment
    }
}
