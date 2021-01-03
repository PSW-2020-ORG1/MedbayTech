using Repository;
using System.Collections.Generic;
using MedbayTech.Common.Repository;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;

namespace MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments
{
    public interface IPrescriptionRepository : IRepository<Prescription, int>
    {
        List<Prescription> GetPrescriptionsFor(string idPatient);
        List<Prescription> GetPrescriptions();

    }
}
