using Backend.Reports.Model;
using Backend.Utils;
using System.Collections.Generic;

namespace Backend.Reports.Service
{
    public interface IMedicationUsageReportService
    {
        public MedicationUsageReport GenerateMedicationUsageReport(Period period);
        public MedicationUsageReport Add(MedicationUsageReport report);
        public bool Remove(MedicationUsageReport report);
        public MedicationUsageReport Update(MedicationUsageReport report);
        public MedicationUsageReport Get(int id);
        public IEnumerable<MedicationUsageReport> GetAll();
    }
}
