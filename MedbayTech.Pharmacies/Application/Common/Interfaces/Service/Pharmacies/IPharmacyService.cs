
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies
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
