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

        public Patient GetById(string id);
        public bool ExistsById(string id);
        public Patient Update(Patient patient);

    }
}
