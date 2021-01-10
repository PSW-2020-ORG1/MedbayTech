using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications
{
    public interface IUrgentMedicationProcurementService
    {
        UrgentMedicationProcurement Add(UrgentMedicationProcurement procurement);
        bool Remove(UrgentMedicationProcurement procurement);
        UrgentMedicationProcurement Update(UrgentMedicationProcurement procurement);
        UrgentMedicationProcurement Get(int id);
        List<UrgentMedicationProcurement> GetAll();
    }
}
