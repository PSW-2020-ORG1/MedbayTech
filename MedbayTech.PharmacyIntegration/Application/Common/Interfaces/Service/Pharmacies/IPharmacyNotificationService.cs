using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies
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
