using System.Collections.Generic;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IDoctorService
    {
        Doctor GetDoctorByExaminationRoom(int roomId);
        Doctor Update(Doctor doctor);
        List<Doctor> GetAll();
        List<Doctor> GetDoctorBySpecialization(int specializationId);
        Doctor GetDoctorBy(string id);
    }
}
