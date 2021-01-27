using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentForRoomManipulationService
    {
        List<AppointmentForRoomManipulation> GetAllForRoom(int roomId);
        AppointmentForRoomManipulation Update(AppointmentForRoomManipulation appointmentForRoomManipulation);
    }
}
