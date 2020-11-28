using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Examinations.WebApiService
{
    public class ReportSearchWebService
    {
        private IExaminationSurgeryRepository repository;

        public ReportSearchWebService(IExaminationSurgeryRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ExaminationSurgery> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type)
        {
            List<ExaminationSurgery> reports = repository.GetAll().ToList();
            List<ExaminationSurgery> iterationList = new List<ExaminationSurgery>(reports);

            foreach (ExaminationSurgery report in iterationList)
            {
                if (!report.Doctor.Name.ToLower().Equals(name.ToLower()) && !name.Equals(""))
                {
                    reports.Remove(report);
                }

                if (!report.Type.ToString().ToLower().Equals(type.ToLower()) && !type.Equals(""))
                {
                    reports.Remove(report);
                }

                if (report.StartTime == startDate && report.StartTime == endDate)
                {
                    continue;
                }

                if (report.StartTime < startDate || report.StartTime > endDate) 
                {
                    reports.Remove(report);
                }  
                
            } 

            return reports;
        }
    }
}
