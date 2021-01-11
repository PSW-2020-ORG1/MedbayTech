

using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Domain.Entities;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MedbayTech.Pharmacies.Infrastructure.Persistance
{
    public class PharmacyNotificationRepository : SqlRepository<PharmacyNotification, int>, IPharmacyNotificationRepository
    {
        public PharmacyNotificationRepository(PharmacyDbContext context) : base(context) { }
    }
}
