using Model.Users;
using System.Collections.Generic;

namespace Backend.Rooms.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByRoomExaminationRoom(int roomId);
        Doctor UpdateDoctorDataBase(Doctor doctor);
        List<Doctor> GetAll();
        List<Doctor> GetDoctorsBy(int specializationId);
        Doctor GetDoctorBy(string id);

    }
}
