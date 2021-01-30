using MedbayTech.Common.Domain.Events;


namespace MedbayTech.Appointment.Domain.Events
{
    public class AppointmentEvent : DomainEvent
    {
        public AppointmentEventType Type { get; set; }
        public string EventIdentificator { get; set; }

        public AppointmentEvent() : base()
        {
        }

        public AppointmentEvent(AppointmentEventType type, string eventIdentificator) : base()
        {
            Type = type;
            EventIdentificator = eventIdentificator;
        }
    }
}
