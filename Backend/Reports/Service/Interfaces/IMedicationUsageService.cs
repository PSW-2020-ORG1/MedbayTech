using Backend.Reports.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Service
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
