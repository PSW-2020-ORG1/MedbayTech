using System.Collections.Generic;
using PharmacyIntegration.Model;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyNotificationService
    {

        PharmacyNotification Add(string recivedNotification);

        bool Remove(PharmacyNotification pharmacyNotification);

        PharmacyNotification Update(PharmacyNotification pharmacyNotification);

        PharmacyNotification Get(int id);

        List<PharmacyNotification> GetAll();


    }
}
