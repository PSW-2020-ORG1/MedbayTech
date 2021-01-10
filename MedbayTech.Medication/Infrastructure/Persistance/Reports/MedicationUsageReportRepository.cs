using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports;
using MedbayTech.Medications.Domain.Entities.Reports;
using MedbayTech.Medications.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Infrastructure.Persistance.Reports
{
    public class MedicationUsageReportRepository : SqlRepository<MedicationUsageReport, string>, IMedicationUsageReportRepository
    {
        public MedicationUsageReportRepository(MedicationDbContext context) : base(context) { }
    }
}
