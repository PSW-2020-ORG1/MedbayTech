using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Appointment.Domain.Events;

namespace MedbayTech.Appointment.Application.DTO
{
    public class AppointmnetEventDTO
    {
        public AppointmentEventType AppointmentEventType { get; set; }
        public string EventIdentificator { get; set; }

        public AppointmnetEventDTO() {}
    }
}
