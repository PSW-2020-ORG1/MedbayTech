using Backend.Pharmacies.Model;
using Model;
using PharmacyIntegration.Repository;
using System.Collections.Generic;
using System.Linq;


namespace Backend.Pharmacies.Repository.MySqlRepository
{
    public class UrgentMedicationProcurementSqlRepository : IUrgentMedicationProcurementRepository //MySqlrepository<UrgentMedicationProcurement, int>
    {

        private MedbayTechDbContext _context;

        public UrgentMedicationProcurementSqlRepository(MedbayTechDbContext context)
        {
            _context = context;
        }
        public UrgentMedicationProcurement Create(UrgentMedicationProcurement entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.UrgentMedicationProcurements.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(UrgentMedicationProcurement entity)
        {
            _context.UrgentMedicationProcurements.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id) => GetObject(id) != null;

        public List<UrgentMedicationProcurement> GetAll() => _context.UrgentMedicationProcurements.ToList();

        public UrgentMedicationProcurement GetObject(int id) =>
            _context.UrgentMedicationProcurements.ToList().Find(pn => pn.Id.Equals(id));

        public UrgentMedicationProcurement Update(UrgentMedicationProcurement entity)
        {
            _context.UrgentMedicationProcurements.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
