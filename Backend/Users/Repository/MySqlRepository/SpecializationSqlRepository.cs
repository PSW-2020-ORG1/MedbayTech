using Model.Users;
using Repository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class SpecializationSqlRepository : MySqlrepository<Specialization, int>,
        ISpecializationRepository
    {
        public Specialization GetGeneralSpecialization()
        {
            // NOTE(Jovan): Not sure what "General" means
            return GetAll().ToList().FirstOrDefault(s => s.SpecializationName.Equals("General"));
        }
    }
}
