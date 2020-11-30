using System.Collections.Generic;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyNotificationService
    {

        public PharmacyNotification Add(string recivedNotification);

        public bool Remove(PharmacyNotification pharmacyNotification);

        public PharmacyNotification Update(PharmacyNotification pharmacyNotification);

        public PharmacyNotification Get(int id);

        public IEnumerable<PharmacyNotification> GetAll();

    }
}
