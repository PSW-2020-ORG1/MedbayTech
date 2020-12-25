using Backend.Pharmacies.Model;
using PharmacyIntegration.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Pharmacies.Repository.MySqlRepository
{
    public class UrgentMedicationProcurementSqlRepository : MySqlrepository<UrgentMedicationProcurement, int>, IUrgentMedicationProcurementRepository
    {
    }
}
