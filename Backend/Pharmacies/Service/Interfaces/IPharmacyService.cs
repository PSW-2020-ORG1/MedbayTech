using PharmacyIntegration.Model;
using System.Collections.Generic;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyService
    {
        public Pharmacy Add(Pharmacy pharmacy);
        public bool Remove(Pharmacy pharmacy);
        public Pharmacy Update(Pharmacy pharmacy);
        public Pharmacy Get(string id);
        public IEnumerable<Pharmacy> GetAll();
    }
}
