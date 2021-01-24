using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Events
{
    public enum AppointmentEventType
    {
        Started,
        Created,
        Quit,
        FromStartedToSelectSpecialization,
        FromSelectSpecializationToStarted,
        FromSelectSpecializationToSelectDoctor,
        FromSelectDoctorToSelectSpecialization,
        FromSelectDoctorToSelectAppointment,
        FromSelectAppointmentToSelectDoctor

    }
}
