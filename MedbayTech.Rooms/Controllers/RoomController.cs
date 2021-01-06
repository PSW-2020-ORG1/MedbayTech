
using MedbayTech.Rooms.Application.Common.Service;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedbayTech.Rooms.Controllers
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
        [HttpGet("{id}")]

        public IActionResult GetRoom(int id)
        {
            return Ok(_roomService.GetRoomById(id));
        }

        [HttpGet("{textBoxSearch?}/{roomSearch?}")]
        public IActionResult Get(string textBoxSearch, RoomSearch roomSearch)
        {
            if(textBoxSearch == null)
            {
                return Ok();
            }

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
