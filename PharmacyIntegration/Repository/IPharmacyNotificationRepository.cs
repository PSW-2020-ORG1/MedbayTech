using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Repository
{
    public interface IPharmacyNotificationRepository
    {
        bool Add(PharmacyNotification pharmacyNotification);

        public bool Remove(int Id);

        public bool Update(PharmacyNotification pharmacyNotification);

        public PharmacyNotification Get(int Id);

        public List<PharmacyNotification> GetAll();

    }
}
