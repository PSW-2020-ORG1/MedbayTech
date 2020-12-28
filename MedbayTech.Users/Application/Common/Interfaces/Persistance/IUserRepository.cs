using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Common.Repository;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public interface IUserRepository : IRepository<RegisteredUser, string>
    {
        List<Doctor> GetAllDoctors();

        Doctor GetDoctorBy(string id);
    }
}
