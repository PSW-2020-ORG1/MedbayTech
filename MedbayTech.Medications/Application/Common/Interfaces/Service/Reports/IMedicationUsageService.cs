using MedbayTech.Medications.Domain.Entities.Reports;
using System.Collections.Generic;


namespace MedbayTech.Medications.Application.Common.Interfaces.Service
{
    public interface IMedicationUsageService
    {
        public MedicationUsage Add(MedicationUsage medicationUsage);
        public bool Remove(MedicationUsage medicationUsage);
        public MedicationUsage Update(MedicationUsage medicationUsage);
        public MedicationUsage Get(int id);
        public List<MedicationUsage> GetAll();
    }
}
