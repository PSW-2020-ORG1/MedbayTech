using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Repository;

namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Medications
{
    class MedicationIngredientSqlRepository : SqlRepository<MedicationIngredient, int>,
        IMedicationIngredientRepository
    {
    }
}
