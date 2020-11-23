using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Repository;

namespace PharmacyIntegration.Service
{
    public class PharmacyNotificationsService : IPharmacyNotificationService
    {
        private IPharmacyNotificationRepository _repository;

        public PharmacyNotificationsService(IPharmacyNotificationRepository repository)
        {
            this._repository = repository;
        }

        public bool Add(PharmacyNotification pharmacyNotification)
        {
            return _repository.Add(pharmacyNotification);
        }

        public PharmacyNotification Get(int Id)
        {
            return _repository.Get(Id);
        }

        public List<PharmacyNotification> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Remove(int Id)
        {
            return _repository.Remove(Id);
        }

        public bool Update(PharmacyNotification pharmacyNotification)
        {
            return _repository.Update(pharmacyNotification);
        }
    }
}
