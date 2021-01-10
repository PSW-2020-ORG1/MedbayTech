using Backend.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Pharmacies.Service.Interfaces
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
