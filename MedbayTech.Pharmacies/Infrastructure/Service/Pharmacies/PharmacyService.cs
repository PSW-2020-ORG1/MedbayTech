using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Domain.Entities;
using System.Collections.Generic;

namespace PharmacyIntegration.Service
{
    public class PharmacyService : IPharmacyService
    {

        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public Pharmacy Add(Pharmacy pharmacy) => _pharmacyRepository.Create(pharmacy);

        public bool Remove(Pharmacy pharmacy) => _pharmacyRepository.Delete(pharmacy);

        public Pharmacy Update(Pharmacy pharmacy) => _pharmacyRepository.Update(pharmacy);

        public Pharmacy Get(string id) => _pharmacyRepository.GetBy(id);
        public List<Pharmacy> GetAll() => _pharmacyRepository.GetAll();

    }
}
