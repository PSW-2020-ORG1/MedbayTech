using System;
using System.Collections.Generic;
using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportSearchService _reportSearchService;

        public ReportController(IReportSearchService reportSearchService)
        {
            _reportSearchService = reportSearchService;
        }
        /*
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

            List<ExaminationSurgery> reports = _reportSearchService.AdvancedSearchReports(dto);

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
            

            List<ExaminationSurgery> reports = _reportSearchService.GetSearchedReports(dto.Doctor, dto.startDate, dto.endDate, dto.type);
            List<ReportDTO> reportDTOs = ReportAdapter.ListExaminationSurgeryToReport(reports);
            return Ok(reportDTOs);
        }*/
    }
}
