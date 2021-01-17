using MedbayTech.Appointment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Appointment.Application.DTO;

namespace MedbayTech.Appointment.Application.Mappers
{
    public class AppointmentEventMapper
    {
        public static AppointmentEvent AppointmnetEventToAppointmnentEventDTO(AppointmnetEventDTO appointmentEvent)
        {
            return new AppointmentEvent
            {
                EventIdentificator = appointmentEvent.EventIdentificator,
                Type = appointmentEvent.AppointmentEventType
            };

        }

    }
}
