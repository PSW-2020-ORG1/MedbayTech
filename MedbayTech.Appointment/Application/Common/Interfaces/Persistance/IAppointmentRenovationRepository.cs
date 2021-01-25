using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Persistance
{
    public interface IAppointmentRenovationRepository : IRepository<AppointmentRenovation, int>
    {
        List<AppointmentRenovation> GetBy(int roomId, DateTime date);
    }
}
