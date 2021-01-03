using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Infrastructure.Database;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class DoctorRepository : SqlRepository<Doctor, string>, IDoctorRepository
    {
        public DoctorRepository(UserDbContext context) : base(context) { }

        public List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            return GetAll().ToList().Where(d => d.Specialization.SpecializationName.ToLower().Equals(specialization.SpecializationName.ToLower())).ToList();
        }

    }
}
