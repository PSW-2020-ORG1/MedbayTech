using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Medications;


namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications
{
    public interface IUrgentMedicationProcurementRepository : IRepository<UrgentMedicationProcurement, int>
    {
    }
}
