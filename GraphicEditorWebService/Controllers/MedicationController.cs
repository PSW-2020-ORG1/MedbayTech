using Backend.Medications.Model;
using Backend.Medications.Service;
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

        [HttpGet("{textBoxSearch?}/{operation?}")]
        public IActionResult Get(string textBoxSearch, int operation)
        {
            if(operation == 0)
            {
                return Ok(_medicationService.GetAllMedicationsByNameOrId(textBoxSearch.ToLower().Trim()));
            }
            else
            {
                return Ok(_medicationService.GetAllMedicationByRoomId(textBoxSearch));
            }
        }

        [HttpPost]
        public IActionResult Post(Medication medication)
        {
            return Ok(_medicationService.UpdateMedication(medication));
        }
    }
}
