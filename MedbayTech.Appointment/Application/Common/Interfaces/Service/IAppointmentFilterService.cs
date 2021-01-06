using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentFilterService
    {
        List<MedbayTech.Appointment.Domain.Entities.Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority);
        List<MedbayTech.Appointment.Domain.Entities.Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters);
        List<MedbayTech.Appointment.Domain.Entities.Appointment> AddRoomToAppointment(List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments);
    }
}
