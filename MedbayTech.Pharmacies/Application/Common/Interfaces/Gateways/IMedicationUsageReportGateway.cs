using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IMedicationUsageReportGateway
    {
        MedicationUsageReport Generate(Period period);
        MedicationUsageReport Add(MedicationUsageReport report);
        MedicationUsageReport GetBy(string id);
        List<MedicationUsageReport> GetAll();
    }
}
