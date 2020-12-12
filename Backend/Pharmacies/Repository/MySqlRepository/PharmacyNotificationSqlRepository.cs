using Model;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Pharmacies.Repository.MySqlRepository
{
    public class PharmacyNotificationSqlRepository : IPharmacyNotificationRepository
    {

        private MySqlContext _context;

        public PharmacyNotificationSqlRepository(MySqlContext context)
        {
            _context = context;
        }

        public PharmacyNotification Create(PharmacyNotification entity)
        {
            _context.PharmacyNotifications.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(PharmacyNotification entity)
        {
            if(GetObject(entity.Id) == null)
            {
                return false;
            }
            _context.PharmacyNotifications.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id) => GetObject(id) != null;

        public IEnumerable<PharmacyNotification> GetAll() => _context.PharmacyNotifications.ToList();

        public PharmacyNotification GetObject(int id) =>
            _context.PharmacyNotifications.ToList().Find(pn => pn.Id.Equals(id));

        public PharmacyNotification Update(PharmacyNotification entity)
        {
            _context.PharmacyNotifications.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
