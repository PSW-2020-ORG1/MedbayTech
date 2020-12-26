using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository.Repository;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public interface IUserRepository : IRepository<RegisteredUser, string>
    {

    }
}
