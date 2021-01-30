using MedbayTech.Rooms.Domain;
using System.Collections.Generic;


namespace MedbayTech.Rooms.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        List<Patient> GetPatients();
        List<Doctor> GetDoctors();
        Doctor GetDoctorByRoomExaminationRoom(int roomId);





    }
}
