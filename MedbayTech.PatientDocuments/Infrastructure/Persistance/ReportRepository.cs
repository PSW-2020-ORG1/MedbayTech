using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.PatientDocuments.Infrastructure.Database;
using MedbayTech.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.PatientDocuments.Infrastructure.Persistance
{
    public class ReportRepository : SqlRepository<Report, int>, IReportRepository
    {
        public ReportRepository(PatientDocumentsDbContext context) : base(context) { }
        public List<Report> GetReportFor(string idPatient)
        {
            return GetAll().Where(report => report.IsPatient(idPatient)).ToList();
        }

    }
}
