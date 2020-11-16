using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface IPatientRepository : ICreate<Patient>, IGetAll<Patient>
    {
        public Patient GetByUsername(string username);
    }
}
