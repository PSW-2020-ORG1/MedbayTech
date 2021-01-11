
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System.Collections.Generic;
using System.Linq;


namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Medications
{
    public class UrgentMedicationProcurementSqlRepository : SqlRepository<UrgentMedicationProcurement, int>, IUrgentMedicationProcurementRepository 
    {
        
        public UrgentMedicationProcurementSqlRepository(PharmacyDbContext context):base(context)
        {
        }
    }
}
