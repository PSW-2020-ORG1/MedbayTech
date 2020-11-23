using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQService.Repository
{
    public interface IRabbitMQRepository
    {
        public Pharmacy GetPharmacy(string Id);
        public int GetNotificationLastId();
        public bool AddNotification(PharmacyNotification pharmacyNotification);
    }
}
