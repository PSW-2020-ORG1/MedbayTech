using MedbayTech.Users.Domain.Entites;
using System.Collections.Generic;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface ISpecializationService
    {
        List<Specialization> GetAll();
    }
}
