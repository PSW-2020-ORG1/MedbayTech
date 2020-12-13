using Backend.Reports.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Reports.Repository.MySqlRepository
{
    public class MedicationUsageSqlRepository : IMedicationUsageRepository
    {

        private MySqlContext _context;

        public MedicationUsageSqlRepository(MySqlContext context)
        {
            _context = context;
        }

        public MedicationUsage Create(MedicationUsage entity)
        {
            _context.MedicationUsages.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(MedicationUsage entity)
        {
            if(GetObject(entity.Id) == null)
            {
                return false;
            }
            _context.MedicationUsages.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id) => GetObject(id) != null;

        public IEnumerable<MedicationUsage> GetAll() => _context.MedicationUsages.ToList();

        public MedicationUsage GetObject(int id) =>
            _context.MedicationUsages.ToList().Find(mu => mu.Id.Equals(id));

        public MedicationUsage Update(MedicationUsage entity)
        {
            _context.MedicationUsages.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
