using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Service
{
    public interface IAppointmentFilterService
    {

        List<Domain.Entities.Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority);
        List<Domain.Entities.Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters);
        List<Domain.Entities.Appointment> AddRoomToAppointment(List<Domain.Entities.Appointment> appointments);

        List<Domain.Entities.Appointment> FindEmergencyAppointment(PriorityParameters parameters, int equipmentType);
        Tuple<List<Domain.Entities.Appointment>, List<int>> FindAppointmentsForRescheduling(PriorityParameters parameters, int equipmentType);
    }
}
