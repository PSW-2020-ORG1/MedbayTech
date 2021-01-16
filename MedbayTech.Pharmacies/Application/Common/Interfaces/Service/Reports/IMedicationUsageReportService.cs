using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports
{
    public interface IMedicationUsageReportService
    {
        List<MedicationUsageReport> GetAll();
    }
}
