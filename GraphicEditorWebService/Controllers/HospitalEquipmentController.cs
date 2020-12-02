using Backend.Rooms.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HospitalEquipmentController : ControllerBase
    {
        private IHospitalEquipmentService _hospitalEquipmentService;

        public HospitalEquipmentController(IHospitalEquipmentService hospitalEquipmentService)
        {
            _hospitalEquipmentService = hospitalEquipmentService;
        }

        [HttpGet("{textBoxSearch?}")]
        public IActionResult Get(string textBoxSearch)
        {
            return Ok(_hospitalEquipmentService.GetHospitalEquipmentsByNameOrId(textBoxSearch.ToLower().Trim()));
        }
    }
}
