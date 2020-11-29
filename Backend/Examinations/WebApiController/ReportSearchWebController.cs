using Backend.Examinations.Model;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.WebApiService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.DTO;

namespace Backend.Examinations.WebApiController
{
    public class ReportSearchWebController
    {
        private ExaminationSurgerySqlRepository repository = new ExaminationSurgerySqlRepository(new MySqlContext());
        private ReportSearchWebService service;

        public ReportSearchWebController()
        {
            this.service = new ReportSearchWebService(repository);
        }

        public List<ExaminationSurgery> GetSearchedReports(string name, DateTime startDate, DateTime endDate, string type)
        {
            return service.GetSearchedReports(name, startDate, endDate, type).ToList();
        }

        public List<ExaminationSurgery> AdvancedSearchPrescriptions(ReportAdvancedDTO dto)
        {
            return service.AdvancedSearchReports(dto);
        }
    }
}
