using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace RabbitMQService.Repository
{
    class RabbitMQRepository : IRabbitMQRepository
    {
        private MySqlContext Context;
        
        public RabbitMQRepository(MySqlContext context)
        {
            this.Context = context;
        }

        public RabbitMQRepository()
        {
        }

        public bool AddNotification(PharmacyNotification pharmacyNotification)
        {
            PharmacyNotification p = Context.PharmacyNotifications.FirstOrDefault(p => p.Id == pharmacyNotification.Id);
            if(p == null)
            {
                return false;
            }
            Context.PharmacyNotifications.Update(pharmacyNotification);
            Context.SaveChanges();
            return true;
        }

        public int GetNotificationLastId()
        {
            return Context.PharmacyNotifications.ToList<PharmacyNotification>().Count();
        }

        public Pharmacy GetPharmacy(string Id)
        {
            return Context.Pharmacies.ToList<Pharmacy>().FirstOrDefault(p => p.Id.Equals(Id));
        }
    }
}
