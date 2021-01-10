using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Reports
{
    public class MedicationUsageReportSqlRepository : SqlRepository<MedicationUsageReport, string>, IMedicationUsageReportRepository
    {

        public MedicationUsageReportSqlRepository(PharmacyDbContext context) : base(context) { }

    }
}
