using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Model;
using Backend.Examinations.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DTO;
using WebApplication.Validators;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReportWebController reportWebController;

        public ReportController()
        {
            this.reportWebController = new ReportWebController();
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

            List<ExaminationSurgery> reports = reportWebController.AdvancedSearchPrescriptions(dto);

            return Ok(reports);
        }
    }
}
