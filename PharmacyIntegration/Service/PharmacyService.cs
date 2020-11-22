using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;

namespace PharmacyIntegration.Service
{
    public class PharmacyService : IPharmacyService
    {

        private IPharmacyRepository _repository;

        public PharmacyService(IPharmacyRepository repository)
        {
            this._repository = repository;
        }

        public Pharmacy Get(string id)
        {
            return _repository.Get(id);
        }

        public bool Add(Pharmacy pharmacy)
        {
            return _repository.Add(pharmacy);
        }

        public List<Pharmacy> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Remove(string id)
        {
            return _repository.Remove(id);
        }

        public bool Update(Pharmacy pharmacy)
        {
            return _repository.Update(pharmacy);
        }
    }
}
