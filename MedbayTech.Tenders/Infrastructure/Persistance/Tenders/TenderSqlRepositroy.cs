
using MedbayTech.Repository;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Tenders.Infrastructure.Persistance.Tenders
{
    public class TenderSqlRepositroy : SqlRepository<Tender, int>, ITenderRepository
    {
        public TenderSqlRepositroy(TenderDbContext context) : base(context) { }
    }
}
