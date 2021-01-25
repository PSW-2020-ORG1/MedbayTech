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
    public class AppointmentForRoomManipulationRepository : SqlRepository<AppointmentForRoomManipulation, int>, IAppointmentForRoomManipulationRepository
    {
        public AppointmentForRoomManipulationRepository(AppointmentDbContext context) : base(context) { }
    }
}
