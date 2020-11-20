using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class PatientSqlRepository : MySqlrepository<Patient, string>,
        IPatientRepository
    {
        public Patient GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(p => p.Username.Equals(username));
        }
    }
}
