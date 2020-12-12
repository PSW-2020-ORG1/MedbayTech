using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface ISecretaryRepository : ICreate<Secretary>, IGetAll<Secretary>
    {
        public Secretary GetByUsername(string username);
    }
}
