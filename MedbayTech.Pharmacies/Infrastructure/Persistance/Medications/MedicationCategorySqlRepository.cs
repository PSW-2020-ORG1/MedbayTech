using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Repository;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Medications
{
    public class MedicationCategorySqlRepository : SqlRepository<MedicationCategory, int>,
        IMedicationCategoryRepository
    {
    }
}
