using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using MedbayTech.Rooms.Domain.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Rooms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomEventController : ControllerBase
    {
        private readonly IRoomEventService _roomEventService;

        public RoomEventController(IRoomEventService roomEventService)
        {
            _roomEventService = roomEventService;
        }

        [HttpPost]
        public IActionResult SaveEvent(RoomEvent room)
        {
            return Ok(_roomEventService.SaveNewRoomEvent(room));
        }

        [HttpGet("getMostEntered")]
        public IActionResult getMostEntered()
        {
            return Ok(_roomEventService.GetMostEnteredRoom());
        }
    }
}
