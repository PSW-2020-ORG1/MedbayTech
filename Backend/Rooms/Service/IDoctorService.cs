using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IDoctorService
    {
        public Doctor GetDoctorByRoomExaminationRoom(int roomId);
        public Doctor UpdateDoctorDataBase(Doctor doctor);
    }
}
