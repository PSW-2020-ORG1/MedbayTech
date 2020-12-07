using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Service;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientService _patientService;
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("updatePatientStatus")]
        public IActionResult UpdatePatientStatus(UpdatePatientBlockedStatusDTO dto)
        {
            bool updatedStatus = _patientService.UpdateStatus(dto.Id);
            return Ok(updatedStatus);
        }
    }
}
