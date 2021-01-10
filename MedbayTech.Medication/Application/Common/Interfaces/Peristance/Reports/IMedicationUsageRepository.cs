using MedbayTech.Common.Repository;
using MedbayTech.Medications.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports
{
    public interface IMedicationUsageRepository : IRepository<MedicationUsage, int>
    {
    }
}
