using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Medications.Model;
using Backend.Medications.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using PharmacyIntegration.gRPC;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : Controller
    {
        private IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Medication medication = _medicationService.GetMedication(id);
            if (medication == null)
            {
                return BadRequest();
            }
            return Ok(medication);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_medicationService.GetAll());


        [HttpGet("check/{search?}")]
        public IActionResult Get(string search)
        {
            GrpcClient grpc = new GrpcClient();

            string response = grpc.CheckForMedication(search).Result;
            return Ok(response);
        }
    }
}
