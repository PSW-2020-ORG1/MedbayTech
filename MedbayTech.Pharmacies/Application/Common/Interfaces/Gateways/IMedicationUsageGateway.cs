using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IMedicationUsageGateway
    {
        MedicationUsage Add(MedicationUsage usage);
        MedicationUsage GetBy(int id);
        List<MedicationUsage> GetAll();
    }
}
