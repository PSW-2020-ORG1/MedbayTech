using Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;

using System.Linq;

namespace Infrastructure.Database
{
    public class AppointmentRealocationRepository : SqlRepository<AppointmentRealocation, int>, IAppointmentRealocationRepository
    {
        public AppointmentRealocationRepository(AppointmentDbContext context) : base(context) { }

        public List<AppointmentRealocation> GetBy(int roomId, DateTime date)
        {
            return GetAll().ToList().Where(a => a.RoomId == roomId && a.Start.Date.CompareTo(date.Date) == 0).ToList();
        }
    }
}
