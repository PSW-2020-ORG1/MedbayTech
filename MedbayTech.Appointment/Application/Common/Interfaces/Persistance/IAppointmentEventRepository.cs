using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Appointment.Domain.Events;
using MedbayTech.Common.Repository;
using MedbayTech.Repository;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Persistance
{
    public interface IAppointmentEventRepository : IRepository<AppointmentEvent, int>
    {
        List<AppointmentEvent> GetByEventIdentificator(string eventIdentificator);
        List<AppointmentEvent> GetAllBy(AppointmentEventType type);
        AppointmentEvent GetBy(AppointmentEventType type, string eventIdentificator);
        int GetCountOfBackStep();
        int GetAllStepsBy(string eventIdentificator);
    }
}
