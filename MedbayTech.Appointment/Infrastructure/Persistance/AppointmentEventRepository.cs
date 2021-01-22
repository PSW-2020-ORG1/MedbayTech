using Infrastructure.Database;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Events;
using MedbayTech.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class AppointmentEventRepository : SqlRepository<AppointmentEvent, int>, IAppointmentEventRepository
    {
        public AppointmentEventRepository(AppointmentDbContext context) : base(context) { }

        public List<AppointmentEvent> GetByEventIdentificator(string eventIdentificator)
        {
            return GetAll().Where(e => e.EventIdentificator.Equals(eventIdentificator)).ToList();
        }

        public List<AppointmentEvent> GetAllBy(AppointmentEventType type)
        {
            return GetAll().Where(ae => ae.Type == type).ToList();
        }

        public AppointmentEvent GetBy(AppointmentEventType type, string eventIdentificator)
        {
            return GetAll().FirstOrDefault(ae => ae.EventIdentificator.Equals(eventIdentificator) && ae.Type == type);
        }

        public int GetCountOfBackStep()
        {
            return GetAll().Count(ae =>
                ae.Type == AppointmentEventType.FromSelectAppointmentToSelectDoctor ||
                ae.Type == AppointmentEventType.FromSelectDoctorToSelectSpecialization ||
                ae.Type == AppointmentEventType.FromSelectSpecializationToStarted);
        }

        public int GetCountOfStepsForSuccessful()
        {
            return GetAllBy(AppointmentEventType.Created).Count(ae =>
            ae.Type == AppointmentEventType.FromStartedToSelectSpecialization ||
            ae.Type == AppointmentEventType.FromSelectSpecializationToStarted ||
            ae.Type == AppointmentEventType.FromSelectSpecializationToSelectDoctor ||
            ae.Type == AppointmentEventType.FromSelectDoctorToSelectSpecialization ||
            ae.Type == AppointmentEventType.FromSelectDoctorToSelectAppointment ||
            ae.Type == AppointmentEventType.FromSelectAppointmentToSelectDoctor);
        }
    }
}
