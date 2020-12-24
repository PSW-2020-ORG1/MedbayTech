using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.Service;
using Backend.Users.Service.Interfaces;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("updatePatientStatus")]
        public IActionResult UpdatePatientStatus(UpdatePatientBlockedStatusDTO dto)
        {
            Patient updatedStatus = _patientService.UpdateStatus(dto.Id);
            return Ok("Patient blocked successfully");
        }

        [HttpGet("maliciousPatients")]       
        public IActionResult GetMaliciousPatients()
        {
            List<Patient> patients = _patientService.GetPatientsThatShouldBeBlocked();
            List<MaliciousPatientDTO> maliciousPatients= PatientAdapter.ListPatientToListMaliciousPatient(patients);

            return Ok(maliciousPatients);
        }
    }
}
