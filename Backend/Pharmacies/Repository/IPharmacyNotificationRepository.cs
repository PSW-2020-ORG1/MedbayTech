using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Model;
using Repository;

namespace PharmacyIntegration.Repository
{
    public interface IPharmacyNotificationRepository : IRepository<PharmacyNotification, int>
    {

    }
}
