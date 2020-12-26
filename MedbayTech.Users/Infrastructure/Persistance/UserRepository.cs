using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository.Infrastructure.Persistance;
using MedbayTech.Repository.Repository.SqlRepository;
using MedbayTech.Users.Infrastructure.Database;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class UserRepository : SqlRepository<RegisteredUser, string>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context) {}
    }
}
