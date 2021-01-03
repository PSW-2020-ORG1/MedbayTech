using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByRoomExaminationRoom(int roomId);
        Doctor UpdateDoctorDataBase(Doctor doctor);
    }
}
