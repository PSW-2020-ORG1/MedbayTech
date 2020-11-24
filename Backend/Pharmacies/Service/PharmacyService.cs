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

        public Pharmacy Get(string id)
        {
            return _context.Pharmacies.ToList().Find(p => p.Id.Equals(id));
        }

        public Pharmacy Add(Pharmacy pharmacy)
        {
            _context.Pharmacies.Add(pharmacy);
            return pharmacy;
        }

        public List<Pharmacy> GetAll()
        {
            return _context.Pharmacies.ToList();
        }

        public bool Remove(Pharmacy pharmacy)
        {
            _context.Pharmacies.Remove(pharmacy);
            return true;
        }

        public Pharmacy Update(Pharmacy pharmacy)
        {
            _context.Pharmacies.Update(pharmacy);
            return pharmacy;
        }
    }
}
