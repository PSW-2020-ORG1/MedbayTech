using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;


namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Reports
{
    public class MedicationUsageSqlRepository : SqlRepository<MedicationUsage, int>, IMedicationUsageRepository
    {
        public MedicationUsageSqlRepository(PharmacyDbContext context) : base(context) { }
    }
}
