using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports
{
    public interface IMedicationUsageReportService
    {
        MedicationUsageReport GenerateMedicationUsageReport(Period period);
        MedicationUsageReport Add(MedicationUsageReport report);
        MedicationUsageReport Get(string id);
        List<MedicationUsageReport> GetAll();
    }
}
