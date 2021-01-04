using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Services.AppointmentSearchOrSchedule
{
    public enum AppointmentSearchOrSchedule
    {
        ByRoom,
        ByDoctorAndTimeInterval,
        ByDoctorPriority,
        ScheduleAppointment
    }
}
