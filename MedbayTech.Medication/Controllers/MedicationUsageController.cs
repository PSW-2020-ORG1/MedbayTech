
using System.Collections.Generic;
using MedbayTech.Medications.Application.Common.Interfaces.Service;
using MedbayTech.Medications.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Medications.Domain.Entities.Reports;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Medications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationUsageController : Controller
    {
        private List<Domain.Entities.Medications.Medication> _inMemoryRepo;
        private readonly IMedicationService _medicationService;

        private IMedicationUsageService _medicationUsageService;

        public MedicationUsageController(IMedicationUsageService medicationUsageService)
        {
            _medicationUsageService = medicationUsageService;
        }

        [HttpPost]
        public IActionResult Post(MedicationUsage medicationUsage)
        {
            bool success = _medicationUsageService.Add(medicationUsage) != null;
            if (!success)
            {
                return BadRequest();
            }
            return Ok("Medication usage added");
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            MedicationUsage usage = _medicationUsageService.Get(id);
            if (usage == null)
            {
                return BadRequest();
            }
            return Ok(usage);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_medicationUsageService.GetAll());
    }
}
