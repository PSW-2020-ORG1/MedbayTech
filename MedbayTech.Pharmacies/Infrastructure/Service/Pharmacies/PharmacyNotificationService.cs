
using System;
using System.Collections.Generic;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Domain.Entities;
using Newtonsoft.Json;

namespace PharmacyIntegration.Service
{
    public class PharmacyNotificationService : IPharmacyNotificationService
    {

        private readonly IPharmacyRepository _pharmacyRepository;

        private readonly IPharmacyNotificationRepository _pharmacyNotificationRepository;

        public PharmacyNotificationService(IPharmacyNotificationRepository pharmacyNotificationRepository, IPharmacyRepository pharmacyRepository)
        {
            _pharmacyNotificationRepository = pharmacyNotificationRepository;
            _pharmacyRepository = pharmacyRepository;
        }

        public PharmacyNotification Add(string recivedNotification)
        {
            PharmacyNotification pharmacyNotification = ParseNotification(recivedNotification);
            pharmacyNotification.Id = getNextId();
            if (CheckPermisionToSendNotification(pharmacyNotification.PharmacyId))
                return _pharmacyNotificationRepository.Create(pharmacyNotification);
            return null;
        }

        private int getNextId()
        {
            if (((List<PharmacyNotification>)GetAll()).Count <= 0)
            {
                return 1;
            }
            int maxInt = 1;
            foreach (PharmacyNotification not in GetAll())
            {
                if (not.Id >= maxInt)
                {
                    maxInt = not.Id;
                }
            }
            return maxInt + 1;
        }

        public bool Remove(PharmacyNotification pharmacy) => _pharmacyNotificationRepository.Delete(pharmacy);

        public PharmacyNotification Update(PharmacyNotification pharmacyNotification) =>
            _pharmacyNotificationRepository.Update(pharmacyNotification);

        public PharmacyNotification Get(int id) => _pharmacyNotificationRepository.GetBy(id);
        public List<PharmacyNotification> GetAll() => _pharmacyNotificationRepository.GetAll();

        public bool CheckPermisionToSendNotification(string pharmacyId)
        {
            Pharmacy p = _pharmacyRepository.GetBy(pharmacyId);
            if (p == null ) return false;
            return p.RecieveNotificationFrom;
        }

        private PharmacyNotification ParseNotification(string recivedNotification)
        {
            string content;
            string pharmacyId;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(recivedNotification);
                content = data.content;
                pharmacyId = data.pharmacyId;
            }
            catch (Exception)
            {
                content = "Failed to parse content!";
                pharmacyId = " ";
            }
            PharmacyNotification pharmacyNotification = new PharmacyNotification(content, pharmacyId);
            return pharmacyNotification;
        }
    }
}
