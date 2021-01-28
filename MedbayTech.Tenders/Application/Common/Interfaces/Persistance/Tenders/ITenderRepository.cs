
using MedbayTech.Common.Repository;
using MedbayTech.Tenders.Domain.Entities.Tenders;

namespace MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders
{
    public interface ITenderRepository : IRepository<Tender, int>
    {
    }
}
