using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Reports.Model;
using Backend.Reports.Service;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationUsageController : Controller
    {

        private IMedicationUsageService _medicationUsageService;

        public MedicationUsageController(IMedicationUsageService medicationUsageService)
        {
            _medicationUsageService = medicationUsageService;
        }

        [HttpPost]
        public IActionResult Post(MedicationUsage medicationUsage)
        {
            bool success = _medicationUsageService.Add(medicationUsage) != null;
            if(!success)
            {
                return BadRequest();
            }
            return Ok("Medication usage added");
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            MedicationUsage usage = _medicationUsageService.Get(id);
            if(usage == null)
            {
                return BadRequest();
            }
            return Ok(usage);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_medicationUsageService.GetAll());
    }
}
