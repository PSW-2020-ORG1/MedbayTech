using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class ManagerSqlRepository : MySqlrepository<Manager, string>,
        IManagerRepository
    {
        public Manager GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(m => m.Username.Equals(username));
        }
    }
}
