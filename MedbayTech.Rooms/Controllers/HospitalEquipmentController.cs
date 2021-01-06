
using MedbayTech.Rooms.Application.Common.Service;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("getAllHospitalEquipments")]
        public IActionResult GetHospitalEquipments()
        {
            return Ok(_hospitalEquipmentService.GetAllEquipment());
        }
    }
}
