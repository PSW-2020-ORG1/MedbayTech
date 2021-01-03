﻿using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace GraphicEditorWebService.Controllers
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
        public IActionResult Get(string textBoxSearch)
        {
            return Ok(_equipmentTypeService.GetAllEquipment());
        }
    }
}
