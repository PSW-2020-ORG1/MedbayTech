using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Appointment.Application.Enums
{
    public enum AppointmentSearchOrSchedule
    {
        ByRoom,
        ByDoctorAndTimeInterval,
        ByDoctorPriority,
        ScheduleAppointment,
        UpdateAppointment
    }
}
