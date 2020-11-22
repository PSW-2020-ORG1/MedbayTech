using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyService
    {
        public bool Add(Pharmacy pharmacy);
        public bool Remove(string id);
        public bool Update(Pharmacy pharmacy);
        public Pharmacy Get(string id);
        public List<Pharmacy> GetAll();
    }
}
