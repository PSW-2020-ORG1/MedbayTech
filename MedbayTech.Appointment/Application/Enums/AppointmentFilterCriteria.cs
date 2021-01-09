using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Enums
{
    public enum AppointmentFilterCriteria
    {
        ByTimeIntervalPriority,
        BySpecialistNoPriority,
        BySpecialistDoctorPriority,
        BySpecialistTimePriority,
        AddRoomToAppointment,
        EmergencyAppointment,
        ReschedulingAppointment
    }
}
