using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Repository;
using Model;

namespace PharmacyIntegration.Service
{
    public class PharmacyNotificationService : IPharmacyNotificationService
    {
        private MySqlContext _context;

        public PharmacyNotificationService(MySqlContext context)
        {
            this._context = context;
        }

        public PharmacyNotification Add(PharmacyNotification pharmacyNotification)
        {
            pharmacyNotification.Id = getNextId();
            _context.PharmacyNotifications.Add(pharmacyNotification);
            return pharmacyNotification;
        }

        public PharmacyNotification Get(int Id)
        {
            return _context.PharmacyNotifications.ToList().Find(pn => pn.Id.Equals(Id));
        }

        public List<PharmacyNotification> GetAll()
        {
            return _context.PharmacyNotifications.ToList();
        }

        public bool Remove(PharmacyNotification pharmacy)
        {
            _context.PharmacyNotifications.Remove(pharmacy);
            return true;
        }

        public PharmacyNotification Update(PharmacyNotification pharmacyNotification)
        {
            _context.PharmacyNotifications.Update(pharmacyNotification);
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
            return maxInt;
        }
    }
}
