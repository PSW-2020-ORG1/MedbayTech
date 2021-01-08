using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Application.Gateways
{
    public interface IRoomGateway
    {
        Room GetRoomBy(int roomId);
        List<HospitalEquipment> GetAllHospitalEquipments();
        string GetRoomsDomain();
    }
}
