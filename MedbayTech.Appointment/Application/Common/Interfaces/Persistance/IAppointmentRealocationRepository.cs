
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;

namespace Application.Common.Interfaces.Persistance
{
    public interface IAppointmentRealocationRepository : IRepository<AppointmentRealocation,int>,ICreate<AppointmentRealocation>, IGetBy<AppointmentRealocation, int>, IDelete<AppointmentRealocation>, IGetAll<AppointmentRealocation>, IUpdate<AppointmentRealocation>
    {
        List<AppointmentRealocation> GetBy(int roomId, DateTime date);
    }
}
