using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IMedicationUsageReportGateway
    {
        List<MedicationUsageReport> GetAll();
    }
}
