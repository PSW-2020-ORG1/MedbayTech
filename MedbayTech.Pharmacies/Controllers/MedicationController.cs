using System.Collections.Generic;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using PharmacyIntegration.gRPC;

namespace MedbayTech.Pharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : Controller
    {
        private readonly IMedicationService _medicationService;
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

        [HttpPost("newMed")]
        public IActionResult AddNewMedicion(NewMedicationDTO newMedication)
        {
            Medication medication = new Medication(newMedication.MedicationName, newMedication.MedicationDosage);
            Medication isSuccess = _medicationService.Add(medication);
            if (isSuccess == null)
                return BadRequest();
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_medicationService.GetAll());
        }

        [HttpGet("{textBoxSearch?}/{medicationSearch?}")]
        public IActionResult Get(string textBoxSearch, MedicationSearch medicationSearch)
        {
            if (medicationSearch == MedicationSearch.ByNameOrId)
            {
                return Ok(_medicationService.GetAllMedicationsByNameOrId(textBoxSearch.ToLower().Trim()));
            }
            else if (medicationSearch == MedicationSearch.ByRoomId)
            {
                return Ok(_medicationService.GetAllMedicationByRoomId(textBoxSearch));
            }
            else return Ok();
        }

        [HttpPost]
        public IActionResult Post(Medication medication)
        {
            return Ok(_medicationService.UpdateMedication(medication));
        }
    }
}
