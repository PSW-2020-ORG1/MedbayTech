using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class ReportAdapter
    {
        public static List<ReportDTO> ListExaminationSurgeryToReport(List<ExaminationSurgery> examinationSurgeries)
        {
            List<ReportDTO> reports = new List<ReportDTO>();

            foreach(ExaminationSurgery es in examinationSurgeries)
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
