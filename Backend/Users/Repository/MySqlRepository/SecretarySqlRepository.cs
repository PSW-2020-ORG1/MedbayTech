using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class SecretarySqlRepository : MySqlrepository<Secretary, string>,
        ISecretaryRepository
    {
        public Secretary GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(s => s.Username.Equals(username));
        }
    }
}
