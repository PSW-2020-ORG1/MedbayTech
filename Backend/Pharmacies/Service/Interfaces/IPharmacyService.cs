using PharmacyIntegration.Model;
using System.Collections.Generic;

namespace PharmacyIntegration.Service
{
    public interface IPharmacyService
    {
        Pharmacy Add(Pharmacy pharmacy);
        bool Remove(Pharmacy pharmacy);
        Pharmacy Update(Pharmacy pharmacy);
        Pharmacy Get(string id);
        List<Pharmacy> GetAll();
    }
}
