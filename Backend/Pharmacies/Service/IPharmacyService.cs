using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyService
    {
        public Pharmacy Add(Pharmacy pharmacy);
        public bool Remove(Pharmacy pharmacy);
        public Pharmacy Update(Pharmacy pharmacy);
        public Pharmacy Get(string id);
        public List<Pharmacy> GetAll();
    }
}
