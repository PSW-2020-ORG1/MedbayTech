using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Mapper.Report
{
    public class ReportMapper
    {
        public static List<ReportDTO> ListExaminationSurgeryToReport(List<Domain.Entities.Examinations.Report> examinationSurgeries)
        {
            List<ReportDTO> reports = new List<ReportDTO>();

            foreach (Domain.Entities.Examinations.Report es in examinationSurgeries)
            {
                String name = es.Doctor.Name + " " + es.Doctor.Surname;
                DateTime date = es.StartTime;
                String type = es.Type.ToString();

                reports.Add(new ReportDTO(name, date, type));
            }

            return reports;
        }
    }
}
