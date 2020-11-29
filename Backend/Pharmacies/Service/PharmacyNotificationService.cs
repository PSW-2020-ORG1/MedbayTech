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
        private MySqlContext _context;

        public PharmacyNotificationService(MySqlContext context)
        {
            this._context = context;
        }

        public PharmacyNotification Add(string recivedNotification)
        {
            string content;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(recivedNotification);
                content = data.content;
            }
            catch(Exception)
            {
                content = "Nije usjelo!";
            }
            PharmacyNotification pharmacyNotification = new PharmacyNotification(content);
            pharmacyNotification.Id = getNextId();
            _context.PharmacyNotifications.Add(pharmacyNotification);
            _context.SaveChanges();
            return pharmacyNotification;
        }

        public PharmacyNotification Get(int Id)
        {
            return _context.PharmacyNotifications.ToList().Find(pn => pn.Id.Equals(Id));
        }

        public IEnumerable<PharmacyNotification> GetAll() => _context.PharmacyNotifications.ToList();

        public bool Remove(PharmacyNotification pharmacy)
        {
            _context.PharmacyNotifications.Remove(pharmacy);
            _context.SaveChanges();
            return true;
        }

        public PharmacyNotification Update(PharmacyNotification pharmacyNotification)
        {
            _context.PharmacyNotifications.Update(pharmacyNotification);
            _context.SaveChanges();
            return pharmacyNotification;
        }

        private int getNextId()
        {
            if(_context.PharmacyNotifications.ToList().Count <= 0)
            {
                return 1;
            }
            int maxInt = 1;
            foreach(PharmacyNotification not in GetAll())
            {
                if(not.Id >= maxInt)
                {
                    maxInt = not.Id;
                }
            }
            return maxInt + 1;
        }
    }
}
