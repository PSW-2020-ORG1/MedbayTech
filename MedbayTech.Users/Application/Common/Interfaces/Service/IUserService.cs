using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Service
{
    public interface IUserService
    {
        List<RegisteredUser> GetAll();
        RegisteredUser GetBy(string id);
    }
}
