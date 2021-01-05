using Backend.Pharmacies.Model;
using Model;
using PharmacyIntegration.Repository;
using Repository;
using System.Collections.Generic;
using System.Linq;


namespace Backend.Pharmacies.Repository.MySqlRepository
{
    public class UrgentMedicationProcurementSqlRepository : MySqlrepository<UrgentMedicationProcurement, int>, IUrgentMedicationProcurementRepository 
    {
        
        public UrgentMedicationProcurementSqlRepository(MedbayTechDbContext context):base(context)
        {
        }
    }
}
