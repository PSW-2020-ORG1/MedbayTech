using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;

namespace PharmacyIntegration.Service
{
    // TODO(Jovan): Hardcoded to work!
    public class PharmacyService : IPharmacyService
    {

        private MySqlContext _context;

        public PharmacyService(MySqlContext context)
        {
            this._context = context;
        }

        public Pharmacy Add(Pharmacy pharmacy)
        {
            if(Get(pharmacy.Id) == null)
            {
                return null;
            }
            _context.Pharmacies.Add(pharmacy);
            _context.SaveChanges();
            return pharmacy;
        }

        public bool Remove(Pharmacy pharmacy)
        {
            _context.Pharmacies.Remove(pharmacy);
            _context.SaveChanges();
            return true;
        }

        public Pharmacy Update(Pharmacy pharmacy)
        {
            _context.Pharmacies.Update(pharmacy);
            _context.SaveChanges();
            return pharmacy;
        }

        public Pharmacy Get(string id) => _context.Pharmacies.ToList().Find(p => p.Id.Equals(id));
        public IEnumerable<Pharmacy> GetAll() => _context.Pharmacies.ToList();

    }
}
