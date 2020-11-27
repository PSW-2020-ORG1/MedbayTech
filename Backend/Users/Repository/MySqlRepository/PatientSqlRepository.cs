using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Backend.Users.Repository.MySqlRepository
{
    class PatientSqlRepository : MySqlrepository<Patient, string>,
        IPatientRepository
    {

        public PatientSqlRepository(MySqlContext context) : base(context) { }

        public Patient GetById(string id)
        {
            if (ExistsById(id))
            {
                return GetAll().FirstOrDefault(p => p.Id.Equals(id));
            }
            return null;
        }

        public Patient GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(p => p.Username.Equals(username));
        }

        bool ExistsById(string id)
        {
            if (GetAll().FirstOrDefault(p => p.Id.Equals(id)) != null) return true;
            return false;
        }

        bool IPatientRepository.ExistsById(string id)
        {
            if (GetAll().FirstOrDefault(p => p.Id.Equals(id)) != null) return true;
            return false;
        }
    }
}
