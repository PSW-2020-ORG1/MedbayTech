using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        List<Patient> GetPatients();
        List<Doctor> GetDoctors();
        Doctor GetDoctorByRoomExaminationRoom(int roomId);





    }
}
