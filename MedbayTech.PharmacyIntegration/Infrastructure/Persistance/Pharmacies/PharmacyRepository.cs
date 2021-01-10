
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Pharmacies
{
    public class PharmacyRepository : SqlRepository<Pharmacy, string>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDbContext context) : base(context) { }
    }
}
