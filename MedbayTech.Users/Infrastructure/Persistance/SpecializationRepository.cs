using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Infrastructure.Database;


namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class SpecializationRepository : SqlRepository<Specialization, int>, ISpecializationRepository
    {
        public SpecializationRepository(UserDbContext context) : base(context) { }
    }
}
