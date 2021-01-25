using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentRenovationService
    {
        List<AppointmentRenovation> GetAllAvailableAppointmentByRoomAndDateTime(int roomId, DateTime chosenStart, DateTime chosenEnd);
        AppointmentRenovation ScheduleAppointmentRenovation(AppointmentRenovation appointmentRenovation);
        List<AppointmentRenovation> GetAppointmentRenovationsByRoomId(int roomId);
        AppointmentRenovation UpdateAppointement(AppointmentRenovation appointmentRenovation);
        List<AppointmentRenovation> GetAvailableAppointmentRenovationsForTwoRoms(int roomOneId, int roomTwoId, DateTime start, DateTime end);
    }
}
