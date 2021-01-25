using Infrastructure.Database;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class AppointmentRenovationRepository : SqlRepository<AppointmentRenovation, int>, IAppointmentRenovationRepository
    {
        public AppointmentRenovationRepository(AppointmentDbContext context) : base(context) { }

        public List<AppointmentRenovation> GetBy(int roomId, DateTime date)
        {
            return GetAll().ToList().Where(a => a.RoomId == roomId && a.Period.StartTime.Date.CompareTo(date.Date) == 0).ToList();
        }
        
    }
}
