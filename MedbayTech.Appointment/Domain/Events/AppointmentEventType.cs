using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Events
{
    public enum AppointmentEventType
    {
        CREATED,
        CANCELED,
        DONE
    }
}
