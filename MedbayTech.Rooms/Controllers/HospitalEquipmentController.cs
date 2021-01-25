using MedbayTech.Rooms.Application.Common.Service;
using MedbayTech.Rooms.Application.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace MedbayTech.Rooms.Controllers
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

        [HttpPost]
        public IActionResult GetByRoomAndEquipmentType(EquipmentRealocationDTO equipmentRealocationDTO)
        {
            return Ok(_hospitalEquipmentService.GetHospitalEquipmentByEquipmentTypeAndRoom(equipmentRealocationDTO.RoomId, equipmentRealocationDTO.EquipmentTypeId));
        }

        [HttpGet("getAllHospitalEquipments/{id}")]
        public IActionResult GetHospitalEquipmentsByRoom(int id)
        {
            return Ok(_hospitalEquipmentService.GetEquipmentByRoomNumber(id));
        }
    }
}
