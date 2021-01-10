using MedbayTech.Common.Domain.Events;


namespace MedbayTech.Appointment.Domain.Events
{
    public class AppointmentEvent : DomainEvent
    {
        public AppointmentEventType Type { get; set; }
        public virtual Entities.Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }

        public AppointmentEvent() : base()
        {
        }

        public AppointmentEvent(AppointmentEventType type, int appointmentId) : base()
        {
            Type = type;
            AppointmentId = appointmentId;
        }
    }
}
