using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByExaminationRoom(int roomId);
        Doctor Update(Doctor doctor);
        List<Doctor> GetAll();
        List<Doctor> GetDoctorsBy(string specializationName);
        Doctor GetDoctorBy(string id);
    }
}
