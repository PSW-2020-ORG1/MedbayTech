using Backend.Reports.Model;
using Backend.Utils;
using System.Collections.Generic;

namespace Backend.Reports.Service
{
    public interface IMedicationUsageReportService
    {
        MedicationUsageReport GenerateMedicationUsageReport(Period period);
        MedicationUsageReport Add(MedicationUsageReport report);
        bool Remove(MedicationUsageReport report);
        MedicationUsageReport Update(MedicationUsageReport report);
        MedicationUsageReport Get(string id);
        IEnumerable<MedicationUsageReport> GetAll();
    }
}
