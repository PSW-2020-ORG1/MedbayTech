using Backend.Users.Service.Interfaces;
using Model.Users;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service
{
    public class SpecializationService : ISpecializationService
    {
        private ISpecializationRepository _specializationRepository;

        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public List<Specialization> GetAll()
        {
            return _specializationRepository.GetAll();
        }
    }
}
