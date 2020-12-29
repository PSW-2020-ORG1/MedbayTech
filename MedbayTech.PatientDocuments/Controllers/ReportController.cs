using System;
using System.Collections.Generic;
using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Application.DTO.Report;
using MedbayTech.PatientDocuments.Application.Mapper.Report;
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
        
        [HttpPost("advancedSearch")]
        public IActionResult AdvancedSearchPrescriptions(ReportAdvancedDTO dto)
        {
            
            try
            {
                dto.ValidateUserInput();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            List<Report> reports = _reportSearchService.AdvancedSearchReports(dto);

            return Ok(reports);
        }
        

        [HttpPost]
        public IActionResult GetSearchedReports(ReportSearchDTO dto)
        {
            try 
            {
               // ValidateReportSearch.Validate(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

            List<Report> reports = _reportSearchService.GetSearchedReports(dto.Doctor, dto.startDate, dto.endDate, dto.type);
            List<ReportDTO> reportDTOs = ReportMapper.ListExaminationSurgeryToReport(reports);
            return Ok(reportDTOs);
        }
    }
}
