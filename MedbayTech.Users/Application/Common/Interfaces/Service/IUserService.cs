using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;


namespace MedbayTech.Users.Infrastructure.Service
{
    public interface IUserService
    {
        List<RegisteredUser> GetAll();
        RegisteredUser GetBy(string id);

        Doctor GetDoctorBy(string id);

        List<Doctor> GetAllDoctors();

    }
}
