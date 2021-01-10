using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Common.Repository;

namespace MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications
{
    public interface IMedicationCategoryRepository : ICreate<MedicationCategory>, IGetAll<MedicationCategory>
    {
       
    }
}
