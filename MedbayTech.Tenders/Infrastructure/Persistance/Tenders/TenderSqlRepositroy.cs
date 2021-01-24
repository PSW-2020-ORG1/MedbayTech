
using MedbayTech.Repository;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders.Infrastructure.Database;

namespace MedbayTech.Tenders.Infrastructure.Persistance.Tenders
{
    public class TenderSqlRepositroy : SqlRepository<Tender, int>, ITenderRepository
    {
        public TenderSqlRepositroy(TenderDbContext context) : base(context) { }
    }
}
