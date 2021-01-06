using System.Collections.Generic;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mappers;
using MedbayTech.Users.Domain.Entites;
using Microsoft.AspNetCore.Mvc;


namespace MedbayTech.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public IActionResult GetPatiens()
        {
            return Ok(_patientService.GetAll());
        }


        [HttpGet("maliciousPatients")]
        public IActionResult GetMaliciousPatients()
        {
            List<Patient> patients = _patientService.GetPatientsThatShouldBeBlocked();
            List<MaliciousPatientDTO> maliciousPatients = PatientMapper.ListPatientToListMaliciousPatient(patients);

            return Ok(maliciousPatients);
        }

        [HttpPost("updatePatientStatus")]
        public IActionResult UpdatePatientStatus(UpdatePatientBlockedStatusDTO dto)
        {
            Patient updatedStatus = _patientService.UpdateStatus(dto.Id);
            return Ok("Patient blocked successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientBy(string id)
        {
            return Ok(_patientService.GetPatientBy(id));
        }
    }
}
