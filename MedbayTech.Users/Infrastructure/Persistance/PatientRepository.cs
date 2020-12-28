using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Infrastructure.Database;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class PatientRepository : SqlRepository<Patient, string>, IPatientRepository
    {
        public  PatientRepository(UserDbContext context) : base(context) {}
        public Patient GetById(string id)
        {
            if (ExistsById(id))
            {
                return (Patient) GetAll().FirstOrDefault(p => p.Id.Equals(id));
            }
            return null;
        }

        public Patient GetByUsername(string username)
        {
            return (Patient) GetAll().ToList().FirstOrDefault(p => p.Username.Equals(username));
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

        public List<Patient> GetAllPatients()
        {
            return GetAll();
        }

        public Patient Update(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
