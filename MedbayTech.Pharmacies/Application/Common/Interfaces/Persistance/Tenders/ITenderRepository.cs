
using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;


namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders
{
    public interface ITenderRepository : IRepository<Tender, int>
    {
    }
}
