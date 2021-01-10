using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.PatientDocuments.Infrastructure.Database;
using MedbayTech.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.PatientDocuments.Infrastructure.Persistance
{
    public class PrescriptionRepository : SqlRepository<Prescription, int>, IPrescriptionRepository
    {
        public PrescriptionRepository(PatientDocumentsDbContext context) : base(context) { }
        public List<Prescription> GetPrescriptions()
        {
            return GetAll().Where(prescription => prescription.IsPrescription()).ToList();
        }

        public List<Prescription> GetPrescriptionsFor(string idPatient)
        {
            return GetAll().Where(prescription => prescription.IsPatient(idPatient)).ToList();
        }
    }
}
