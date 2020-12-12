using Backend.Reports.Model;
using Backend.Reports.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Service
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

        public MedicationUsage Get(int id) => _medicationUsageRepository.GetObject(id);

        public IEnumerable<MedicationUsage> GetAll() => _medicationUsageRepository.GetAll();
    }
}
