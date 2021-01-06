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
    public class PharmacySqlRepository : MySqlrepository<Pharmacy, string>, IPharmacyRepository
    {

        // private MedbayTechDbContext _context;
        public PharmacySqlRepository(MedbayTechDbContext context): base(context)
        {
        }
        /*
        public Pharmacy Create(Pharmacy entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.Pharmacies.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Pharmacy entity)
        {
            _context.Pharmacies.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(string id) => GetObject(id) != null;

        public List<Pharmacy> GetAll() => _context.Pharmacies.ToList();

        public Pharmacy GetObject(string id) => _context.Pharmacies.ToList().Find(p => p.Id.Equals(id));

        public Pharmacy Update(Pharmacy entity)
        {
            _context.Pharmacies.Update(entity);
            _context.SaveChanges();
            return entity;
        }*/
    }
}
