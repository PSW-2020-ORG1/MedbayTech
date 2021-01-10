using Backend.Pharmacies.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyIntegration.Repository
{
    public interface IUrgentMedicationProcurementRepository : IRepository<UrgentMedicationProcurement, int>
    {
    }
}
