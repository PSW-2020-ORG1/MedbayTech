using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports;
using MedbayTech.Medications.Domain.Entities.Reports;
using MedbayTech.Medications.Infrastructure.Database;
using MedbayTech.Repository;

namespace MedbayTech.Medications.Infrastructure.Persistance.Reports
{
    public class MedicationUsageRepository : SqlRepository<MedicationUsage, int>, IMedicationUsageRepository
    {
        public MedicationUsageRepository(MedicationDbContext context) : base(context) { }
    }
}
