using Backend.Examinations.Model;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.WebApiService;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DTO;

namespace Backend.Examinations.WebApiController
{
    public class ReportWebController
    {
        private ExaminationSurgerySqlRepository reportSqlRepository = new ExaminationSurgerySqlRepository(new MySqlContext());
        private ReportWebService reportWebService;

        public ReportWebController()
        {
            this.reportWebService = new ReportWebService(reportSqlRepository);
        }

        public List<ExaminationSurgery> AdvancedSearchPrescriptions(ReportAdvancedDTO dto)
        {
            return reportWebService.AdvancedSearchReports(dto);
        }
    }
}
