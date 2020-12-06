using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByRoomExaminationRoom(int roomId);
        Doctor UpdateDoctorDataBase(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetDoctors(int specializationId);

    }
}
