using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
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

        public IEnumerable<ExaminationSurgery> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string treatment)
        {
            return repository.GetSearchedReports(name, startDate, endDate, treatment);
        }
    }
}
