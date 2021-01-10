using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Rooms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EquipmentTypeController : Controller
    {
        private IEquipmentTypeService _equipmentTypeService;

        public EquipmentTypeController(IEquipmentTypeService equipmentTypeService)
        {
            _equipmentTypeService = equipmentTypeService;
        }

        [HttpGet("{textBoxSearch?}")]
        public IActionResult GetAllEquipment(string textBoxSearch)
        {
            return Ok(_equipmentTypeService.GetAllEquipment());
        }
    }
}
