using MedbayTech.Common.Repository;
using System.Collections.Generic;

namespace MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications
{
    public interface IMedicationRepository : IRepository<Domain.Entities.Medications.Medication, int>
    {
        List<Domain.Entities.Medications.Medication> GetAllOnValidation();
        List<Domain.Entities.Medications.Medication> GetAllRejected();
        List<Domain.Entities.Medications.Medication> GetAllApproved();
    }
}
