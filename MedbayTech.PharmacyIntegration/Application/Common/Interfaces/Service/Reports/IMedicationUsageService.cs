
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports
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
