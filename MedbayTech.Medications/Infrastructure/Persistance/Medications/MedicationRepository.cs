using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Infrastructure.Database;
using MedbayTech.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Infrastructure.Persistance
{
    public class MedicationRepository : SqlRepository<Domain.Entities.Medications.Medication, int>, IMedicationRepository
    {
        public MedicationRepository(MedicationDbContext context) : base(context) { }
        public List<Domain.Entities.Medications.Medication> GetAllApproved()
        {
            return GetAll().ToList();
        }

        public List<Domain.Entities.Medications.Medication> GetAllOnValidation()
        {
            return GetAll().ToList();
        }

        public List<Domain.Entities.Medications.Medication> GetAllRejected()
        {
            return GetAll().ToList();
        }
    }
}
