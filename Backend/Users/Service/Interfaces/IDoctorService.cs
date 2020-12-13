using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Rooms.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByRoomExaminationRoom(int roomId);
        Doctor UpdateDoctorDataBase(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetDoctorsBy(int specializationId);
        Doctor GetDoctorBy(string id);

    }
}
