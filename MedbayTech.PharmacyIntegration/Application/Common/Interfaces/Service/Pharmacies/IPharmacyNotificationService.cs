using MedbayTech.Pharmacies.Domain.Entities;
using System.Collections.Generic;

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
