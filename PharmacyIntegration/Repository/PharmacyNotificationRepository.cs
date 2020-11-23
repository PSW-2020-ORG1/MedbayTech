using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Repository
{
    public class PharmacyNotificationRepository : IPharmacyNotificationRepository
    {

        private MySqlContext Context;

        public PharmacyNotificationRepository(MySqlContext Context)
        {
            this.Context = Context;
        }
        public PharmacyNotificationRepository()
        {

        }

        public bool Add(PharmacyNotification pharmacyNotification)
        {
            if (Context.PharmacyNotifications.FirstOrDefault(p => p.Id == pharmacyNotification.Id) != null)
            {
                return false;
            }

            Context.PharmacyNotifications.Add(pharmacyNotification);
            Context.SaveChanges();
            return true;
        }

        public PharmacyNotification Get(int Id)
        {
            return this.GetAll().FirstOrDefault(p => p.Id == Id);
        }

        public List<PharmacyNotification> GetAll()
        {
            return Context.PharmacyNotifications.ToList<PharmacyNotification>();
        }

        public bool Remove(int Id)
        {
            PharmacyNotification p = Context.PharmacyNotifications.FirstOrDefault(p => p.Id == Id);
            if (p == null)
            {
                return false;
            }
            Context.PharmacyNotifications.Remove(p);
            Context.SaveChanges();
            return true;
        }

        public bool Update(PharmacyNotification pharmacyNotification)
        {
            PharmacyNotification p = Context.PharmacyNotifications.FirstOrDefault(p => p.Id == pharmacyNotification.Id);
            if (p == null)
            {
                return false;
            }
            Context.PharmacyNotifications.Update(pharmacyNotification);
            Context.SaveChanges();
            return true;
        }
    }
}
