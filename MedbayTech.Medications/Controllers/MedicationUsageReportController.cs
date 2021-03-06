﻿
using MedbayTech.Medications.Application.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Medications.Domain.Entities.Reports;

namespace MedbayTech.Medications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationUsageReportController : ControllerBase
    {

        private IMedicationUsageReportService _medicationUsageReportService;

        public MedicationUsageReportController(IMedicationUsageReportService medicationUsageReportService)
        {
            this._medicationUsageReportService = medicationUsageReportService;
        }

        [HttpPost]
        public IActionResult Post(Period period)
        {
            MedicationUsageReport report = _medicationUsageReportService.GenerateMedicationUsageReport(period);
            if (report == null)
            {
                return BadRequest();
            }
            return Ok(report);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_medicationUsageReportService.GetAll());

        [HttpGet("{id?}")]
        public IActionResult Get(string id)
        {
            MedicationUsageReport report = _medicationUsageReportService.Get(id);
            if (report == null)
            {
                return BadRequest();
            }
            return Ok(report);
        }
    }
}
