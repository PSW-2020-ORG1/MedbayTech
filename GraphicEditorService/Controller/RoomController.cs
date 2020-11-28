using Backend.Rooms.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphicEditorService.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        public RoomController (IRoomService roomService)
        {
            _roomService = roomService;
        }

        /*[HttpGet("{roomLabel?}")]
        public IActionResult Get(string roomLabel)
        {
            return Ok(_roomService.GetAll());
        }*/
        [HttpGet("{roomId?}")]
        public IActionResult Get(int roomId)
        {
            return Ok(_roomService.GetAll());
        }
    }
}
