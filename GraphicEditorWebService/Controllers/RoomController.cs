using Backend.Rooms.Service;
using Backend.Rooms.Service.Enum;
using Microsoft.AspNetCore.Mvc;
using Model.Rooms;
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

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{textBoxSearch?}/{roomSearch?}")]
        public IActionResult Get(string textBoxSearch, RoomSearch roomSearch)
        {
            if (roomSearch == RoomSearch.ByRoomLabelorRoomUse)
            {
                return Ok(_roomService.GetRoomsByRoomLabelorRoomUse(textBoxSearch.ToLower().Trim()));
            }
            else if (roomSearch == RoomSearch.ByRoomId)
            {
                if (Int32.TryParse(textBoxSearch, out int id))
                {
                    return Ok(_roomService.GetRoomById(id));
                }
                else return Ok();
            }
            else return Ok();
        }

        [HttpPost]
        public IActionResult Post(Room room)
        {
            return Ok(_roomService.UpdateRoomDataBase(room));
        }
    }
}
