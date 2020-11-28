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

        [HttpGet("{textBoxSearch?}")]
        public IActionResult Get(string textBoxSearch)
        {
            return Ok(_medicationService.GetAllMedicationsByNameOrId(textBoxSearch.ToLower().Trim()));
        }
    }
}
