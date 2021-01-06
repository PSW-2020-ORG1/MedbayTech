using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Infrastructure.Database;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class PatientRepository : SqlRepository<Patient, string>, IPatientRepository
    {
        public  PatientRepository(UserDbContext context) : base(context) {}
       
        public Patient GetByUsername(string username)
        {
            return (Patient) GetAll().ToList().FirstOrDefault(p => p.Username.Equals(username));
        }
       
    }
}
