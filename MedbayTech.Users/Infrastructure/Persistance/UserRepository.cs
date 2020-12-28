using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository;
using MedbayTech.Repository.Infrastructure.Persistance;
using MedbayTech.Users.Infrastructure.Database;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class UserRepository : SqlRepository<RegisteredUser, string>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context) {}

        public Doctor GetDoctorBy(string id)
        {
            return (Doctor) GetBy(id);
        }

        List<Doctor> IUserRepository.GetAllDoctors()
        {
            List<RegisteredUser> registeredUsers = GetAll();
            List<Doctor> doctors = new List<Doctor>();

            foreach (RegisteredUser registeredUserIt in registeredUsers)
            {
                doctors.Add((Doctor) registeredUserIt);
            }
            return doctors;
        }
    }
}
