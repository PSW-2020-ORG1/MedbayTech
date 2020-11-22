using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;

namespace PharmacyIntegration.Repository
{
    public interface IPharmacyRepository
    {
        bool Add(Pharmacy pharmacy);

        public bool Remove(string Id);

        public bool Update(Pharmacy pharmacy);

        public Pharmacy Get(string Id);

        public List<Pharmacy> GetAll();
    }
}
