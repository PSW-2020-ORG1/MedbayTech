using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class MedicationUsageService : IMedicationUsageService
    {

        private IMedicationUsageRepository _medicationUsageRepository;
        public MedicationUsageService(IMedicationUsageRepository medicationUsageRepository)
        {
            _medicationUsageRepository = medicationUsageRepository;
        }

        public MedicationUsage Add(MedicationUsage medicationUsage) => _medicationUsageRepository.Create(medicationUsage);
        public bool Remove(MedicationUsage medicationUsage) => _medicationUsageRepository.Delete(medicationUsage);

        public MedicationUsage Update(MedicationUsage medicationUsage) => _medicationUsageRepository.Update(medicationUsage);

        public MedicationUsage Get(int id) => _medicationUsageRepository.GetBy(id);

        public List<MedicationUsage> GetAll() => _medicationUsageRepository.GetAll();
    }
}
