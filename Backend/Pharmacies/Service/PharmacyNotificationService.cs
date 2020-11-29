using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Repository;
using Model;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace PharmacyIntegration.Service
{
    public class PharmacyNotificationService : IPharmacyNotificationService
    {
        /*private MySqlContext _context;

        public PharmacyNotificationService(MySqlContext context)
        {
            this._context = context;
        }*/

        private IPharmacyNotificationRepository _pharmacyNotificationRepository;

        public PharmacyNotificationService(IPharmacyNotificationRepository pharmacyNotificationRepository)
        {
            _pharmacyNotificationRepository = pharmacyNotificationRepository;
        }

        public PharmacyNotification Add(string recivedNotification)
        {
            string content;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(recivedNotification);
                content = data.content;
            }
            catch (Exception)
            {
                content = "Failed to create content!";
            }
            PharmacyNotification pharmacyNotification = new PharmacyNotification(content);
            pharmacyNotification.Id = getNextId();
            return _pharmacyNotificationRepository.Create(pharmacyNotification);
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

        public PharmacyNotification Get(int id) => _pharmacyNotificationRepository.GetObject(id);
        public IEnumerable<PharmacyNotification> GetAll() => _pharmacyNotificationRepository.GetAll();
    }
}
