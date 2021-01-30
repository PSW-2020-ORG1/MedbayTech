using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Infrastructure.Persistance;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<RegisteredUser> GetAll()
        {
           return _userRepository.GetAll().ToList();
        }

        public List<Doctor> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors();
        }

        public RegisteredUser GetBy(string id)
        {
            return _userRepository.GetBy(id);
        }

        public Doctor GetDoctorBy(string id)
        {
            return _userRepository.GetDoctorBy(id);
        }

    }
}
