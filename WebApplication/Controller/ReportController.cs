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
using WebApplication.Validators;

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

        [HttpPost("advancedSearch")]
        public IActionResult AdvancedSearchPrescriptions(ReportAdvancedDTO dto)
        {
            try
            {
                ValidateReportSearchInput.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            List<ExaminationSurgery> reports = controller.AdvancedSearchPrescriptions(dto);

            return Ok(reports);
        }
        

        [HttpPost]
        public IActionResult GetSearchedReports(ReportSearchDTO dto)
        {
            try 
            {
                ValidateReportSearch.Validate(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

            List<ExaminationSurgery> reports = controller.GetSearchedReports(dto.Doctor, dto.startDate, dto.endDate, dto.type);
            List<ReportDTO> reportDTOs = ReportAdapter.ListExaminationSurgeryToReport(reports);
            return Ok(reportDTOs);
        }
    }
}
