using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Model;
using Backend.Examinations.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReportSearchWebController controller;

        public ReportController()
        {
            this.controller = new ReportSearchWebController();
        }

        [HttpPost]
        public IActionResult GetSearchedReports(ReportSearchDTO dto)
        {
            List<ExaminationSurgery> reports = controller.GetSearchedReports(dto.Doctor, dto.startDate, dto.endDate, dto.type);
            List<ReportDTO> reportDTOs = ReportAdapter.ListExaminationSurgeryToReport(reports);
            return Ok(reportDTOs);
        }
    }
}
