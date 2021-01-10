using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Domain.Entites;
using System.Collections.Generic;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;
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
