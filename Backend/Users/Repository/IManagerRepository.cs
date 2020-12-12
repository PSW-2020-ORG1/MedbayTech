using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface IManagerRepository : ICreate<Manager>, IGetAll<Manager>
    {
        public Manager GetByUsername(string username);
    }
}
