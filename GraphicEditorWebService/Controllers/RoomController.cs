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

        [HttpGet("{textBoxSearch?}")]
        public IActionResult Get(string textBoxSearch)
        {
            return Ok(_roomService.GetRoomsByRoomLabelorRoomUse(textBoxSearch.ToLower().Trim()));
        }
    }
}
