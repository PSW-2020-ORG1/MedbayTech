using Backend.Medications.Model;
using Backend.Medications.Service;
using Backend.Medications.Service.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MedicationController : ControllerBase
    {
        private IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
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
