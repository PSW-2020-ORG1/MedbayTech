using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Medications.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Application.Common.Interfaces.Service
{
    public interface IMedicationUsageReportService
    {
        MedicationUsageReport GenerateMedicationUsageReport(Period period);
        MedicationUsageReport Add(MedicationUsageReport report);
        bool Remove(MedicationUsageReport report);
        MedicationUsageReport Update(MedicationUsageReport report);
        MedicationUsageReport Get(string id);
        List<MedicationUsageReport> GetAll();
    }
}
