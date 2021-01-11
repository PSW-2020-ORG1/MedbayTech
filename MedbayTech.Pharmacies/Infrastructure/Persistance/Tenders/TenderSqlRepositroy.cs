
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Tenders
{
    public class TenderSqlRepositroy : SqlRepository<Tender, int>, ITenderRepository
    {
        public TenderSqlRepositroy(PharmacyDbContext context) : base(context) { }
    }
}
