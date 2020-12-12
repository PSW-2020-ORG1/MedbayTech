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

        //private MySqlContext _context;

        /*public PharmacyService(MySqlContext context)
        {
            this._context = context;
        }*/

        private IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public Pharmacy Add(Pharmacy pharmacy) => _pharmacyRepository.Create(pharmacy);

        public bool Remove(Pharmacy pharmacy) => _pharmacyRepository.Delete(pharmacy);

        public Pharmacy Update(Pharmacy pharmacy) => _pharmacyRepository.Update(pharmacy);

        public Pharmacy Get(string id) => _pharmacyRepository.GetObject(id);
        public IEnumerable<Pharmacy> GetAll() => _pharmacyRepository.GetAll();

    }
}
