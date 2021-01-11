
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Repository;
using System.Collections.Generic;
using System.Linq;


namespace MedbayTech.Pharmacies.Infrastructure.Persistance.Medications
{
    public class MedicationSqlRepository : SqlRepository<Medication, int>, IMedicationRepository
    {
        public MedicationSqlRepository(PharmacyDbContext context) : base(context) { }

        public List<Medication> GetAllApproved()
        {
            return GetAll().ToList();
        }

        public List<Medication> GetAllOnValidation()
        {
            return GetAll().ToList();
        }

        public List<Medication> GetAllRejected()
        {
            return GetAll().ToList();
        }

    }
}
