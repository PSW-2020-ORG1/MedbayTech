using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Application.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;

namespace MedbayTech.Users.Controllers
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

        [HttpGet("maliciousPatients")]
        public IActionResult GetMaliciousPatients()
        {
            List<Patient> patients = _patientService.GetPatientsThatShouldBeBlocked();
            List<MaliciousPatientDTO> maliciousPatients = PatientMapper.ListPatientToListMaliciousPatient(patients);

            return Ok(maliciousPatients);
        }
    }
}
