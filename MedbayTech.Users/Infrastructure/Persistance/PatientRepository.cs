using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository.Repository.SqlRepository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Infrastructure.Database;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class PatientRepository : SqlRepository<Patient, string>, IPatientRepository
    {
        public PatientRepository(PatientDbContext context) : base(context) {}
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
