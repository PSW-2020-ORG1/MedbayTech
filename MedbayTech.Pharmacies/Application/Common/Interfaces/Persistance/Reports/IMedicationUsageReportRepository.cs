using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Reports;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports
{
    public interface IMedicationUsageReportRepository : IRepository<MedicationUsageReport, string>
    {
    }
}
