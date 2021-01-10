using Infrastructure.Database;
using MedbayTech.Appointment.Domain.Events;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class AppointmentEventRepository
    {
        private readonly AppointmentDbContext _context;

        public AppointmentEventRepository(AppointmentDbContext context)
        {
            _context = context;
        }

        public void Create(AppointmentEvent appointmentEvent)
        {
            _context.AppointmentEvents.Add(appointmentEvent);
            _context.SaveChanges();
        }
    }
}
