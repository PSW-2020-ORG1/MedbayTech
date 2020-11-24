using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyNotificationService
    {

        public PharmacyNotification Add(PharmacyNotification pharmacyNotification);

        public bool Remove(PharmacyNotification pharmacyNotification);

        public PharmacyNotification Update(PharmacyNotification pharmacyNotification);

        public PharmacyNotification Get(int Id);

        public List<PharmacyNotification> GetAll();
    }
}
