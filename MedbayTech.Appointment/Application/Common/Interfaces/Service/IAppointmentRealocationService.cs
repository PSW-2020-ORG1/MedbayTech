
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentRealocationService
    {
        List<AppointmentRealocation> GetAllAvailableAppointmentByRoomAndDateTime(int roomId, DateTime chosenStart, DateTime chosenEnd);
        bool CheckIsRoomAvailableInSelectedTime(int roomId, DateTime chosenDateTime);
        AppointmentRealocation ScheduleAppointmentRealocation(AppointmentRealocation appointmentRealocation);
        List<AppointmentRealocation> GetAlternativeAvailableAppointments(int fromRoomId, int toRoomId, DateTime dateTime, int hospitalEquipmentId);
        List<AppointmentRealocation> GetAppointmentRealocationsByRoomId(int roomId);
        AppointmentRealocation UpdateAppointement(AppointmentRealocation appointmentRealocation);
        List<AppointmentRealocation> GetAvailableAppointmentRealocationsForTwoRoms(int roomOneId, int roomTwoId, DateTime start, DateTime end);
    }
}
