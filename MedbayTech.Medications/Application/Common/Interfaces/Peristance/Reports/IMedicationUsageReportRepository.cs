using MedbayTech.Common.Repository;
using MedbayTech.Medications.Domain.Entities.Reports;


namespace MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports
{
    public interface IMedicationUsageReportRepository : IRepository<MedicationUsageReport, string>
    {
    }
}
