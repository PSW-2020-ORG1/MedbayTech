using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using MedbayTech.Repository;
using System.Collections.Generic;

namespace MedbayTech.PatientDocuments.Infrastructure.Persistance
{
    public class ReportRepository : SqlRepository<Report, int>, IReportRepository
    {
        public List<Report> GetAllBy(string doctorId)
        {
            throw new System.NotImplementedException();
        }

        public List<Report> GetAllBy(MedicalRecord record)
        {
            throw new System.NotImplementedException();
        }

        public List<Report> GetReportFor(string idPatient)
        {
            throw new System.NotImplementedException();
        }

        public Report UpdateTreatment(Report examinationSurgery, Treatment treatment)
        {
            throw new System.NotImplementedException();
        }
    }
}
