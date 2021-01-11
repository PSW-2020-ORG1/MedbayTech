
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Pharmacies.Controllers
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
            if(report == null)
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