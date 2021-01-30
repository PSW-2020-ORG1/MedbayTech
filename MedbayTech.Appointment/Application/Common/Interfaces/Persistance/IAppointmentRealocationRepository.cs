
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;

namespace Application.Common.Interfaces.Persistance
{

    public interface IAppointmentRealocationRepository : IRepository<AppointmentRealocation,int>
    {
        List<AppointmentRealocation> GetBy(int roomId, DateTime date);
    }
}
