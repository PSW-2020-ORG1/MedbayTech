using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports;
using MedbayTech.Medications.Application.Common.Interfaces.Service;
using MedbayTech.Medications.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Infrastructure.Service.Reports
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
