
using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Medications.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MedbayTech.Medications.Controllers
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
            Domain.Entities.Medications.Medication medication = _medicationService.GetAll().Find(m => m.Id.Equals(id));
            if (medication == null)
            {
                return BadRequest();
            }
            return Ok(medication);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_medicationService.GetAll());


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
            else return Ok(); // TODO(Jovan): Should return OK?
        }

        [HttpPost]
        public IActionResult Post(Domain.Entities.Medications.Medication medication)
        {
            // TODO(Jovan): Handle bad requests
            if(_medicationService.GetMedication(medication.Id) == null)
            {
                return Ok(_medicationService.Add(medication));
            }
            return Ok(_medicationService.UpdateMedication(medication));
        }
    }
}
